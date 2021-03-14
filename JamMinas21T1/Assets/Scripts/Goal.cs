using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{

    int enemyGold = Constants.BASIC_ENEMY_GOLD;
    int randomStones = Constants.BASIC_RANDOM_STONES;

    public bool achieved = false;
    public Countdown contdown = null;

    public GameManager gameManager = null;
    public PlayerManager player;

    public Text enemyGoldText;

    public GameObject victory;
    public GameObject gameover;
    public MoneyCalculator moneyCalculator;

    public InventoryCar inventoryCar;
    public InventoryManager inventoryPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CalculateWinOrLose()
    {

        string enemyGold = Regex.Replace(enemyGoldText.text, "[^0-9]", "");
        string playerGold = Regex.Replace(moneyCalculator.totalMoney.text, "[^0-9]", "");

        if (int.Parse(playerGold) < int.Parse(enemyGold))
        {
            //gameover
            gameover.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            //win
            victory.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void SetGoal()
    {
        //win
        victory.gameObject.transform.GetChild(0).gameObject.SetActive(false);
        player.canMove = true;

        //PROVISORIO : AVALIAR DIFICULDADE
        int playerGold = enemyGold; //PROVISORIO: valor provisorio pegar o dinheiro do player
        float extraTime = playerGold / enemyGold > 1.5 ? 0 : 5;

        var aux = enemyGold * 1.5f;
        enemyGold = (int)aux;
        enemyGoldText.text = enemyGold.ToString() + " g";

        contdown.startingTime += extraTime;
        contdown.Restart(contdown.startingTime);

        randomStones = randomStones > 10 ? randomStones - 2 : 10;

        inventoryCar.CleanCar();
        moneyCalculator.ResetCalculator();

        inventoryPlayer.CleanInventory();
        

        gameManager.RestartStones(randomStones);
    }

}
