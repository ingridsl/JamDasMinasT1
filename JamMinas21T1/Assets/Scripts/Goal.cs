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
    Countdown contdown = null;

    GameManager gameManager = null;

    public Text enemyGoldText;

    public GameObject victory;
    public GameObject gameover;
    public MoneyCalculator moneyCalculator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (achieved)
        {
            SetGoal();
        }        
    }

    public void CalculateWinOrLose()
    {

        string valueText = Regex.Replace(enemyGoldText.text, "[^0-9]", "");

        if (int.Parse(moneyCalculator.totalMoney.text) < int.Parse(valueText))
        {
            //gameover
            gameover.SetActive(false);
        }
        else
        {
            //win
            victory.SetActive(true);
        }
    }

    void SetGoal()
    {
        //PROVISORIO : AVALIAR DIFICULDADE
        enemyGold *= (int) 1.5f;
        int playerGold = enemyGold; //PROVISORIO: valor provisorio pegar o dinheiro do player
        float extraTime = playerGold / enemyGold > 1.5 ? -10 : 10;

        contdown.startingTime += extraTime;
        contdown.Restart(contdown.startingTime);

        randomStones = randomStones > 10 ? randomStones - 2 : 10;

        gameManager.RestartStones(randomStones);
    }

}
