using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyCalculator : MonoBehaviour
{
    public InventoryCar inventoryCar = null;

    public Text doleritoMoney;
    public Text granadaMoney;
    public Text esmeraldaMoney;
    public Text turmalinaMoney;

    public Text totalMoney;

    bool timeIsUp = false;
    bool canClose = false;
    
    int moneyDolerito = 0;
    int moneyGranada = 0;
    int moneyEsmeralda = 0;
    int moneyTurmalina = 0;

    public Goal goal = null;
    public PlayerManager player;

    public int total = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timeIsUp && canClose &&(Input.GetMouseButton(0) || Input.GetKeyDown(KeyCode.Space) ) )
        {
            OpenMoneyCalculator();
            goal.CalculateWinOrLose();
        }
    }
    
    public void ResetCalculator()
    {
        total = 0;

        timeIsUp = false;
        canClose = false;

        moneyDolerito = 0;
        moneyGranada = 0;
        moneyEsmeralda = 0;
        moneyTurmalina = 0;
    }

    public void Calculate()
    {
        var collectedOres = inventoryCar.collectedOres;
        moneyDolerito = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Dolerito);
        moneyGranada = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Granada);
        moneyEsmeralda = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Esmeralda);
        moneyTurmalina = CalculateOre(inventoryCar.collectedOres, Constants.Ore.Turmalina);

        Text(inventoryCar.collectedOres);
    }

    public void Text(InventoryCar.CollectedOre[] ores)
    {
        foreach (var ore in ores)
        {
            switch (ore.oreType)
            {
                case (int)Constants.Ore.Dolerito:
                    doleritoMoney.text = ore.amount + " x 1 gold = " + moneyDolerito;
                    break;
                case (int)Constants.Ore.Granada:
                    granadaMoney.text = ore.amount + " x 2 gold = " + moneyGranada;
                    break;
                case (int)Constants.Ore.Esmeralda:
                    esmeraldaMoney.text = ore.amount + " x 4 gold = " + moneyEsmeralda;
                    break;
                case (int)Constants.Ore.Turmalina:
                    turmalinaMoney.text = ore.amount + " x 10 gold = " + moneyTurmalina;
                    break;
            }
        }
        total = moneyDolerito + moneyGranada + moneyEsmeralda + moneyTurmalina;
        totalMoney.text = total + " gold";
    }

    public int CalculateOre(InventoryCar.CollectedOre[] ores, Constants.Ore oreType)
    {
        int total = 0;
        foreach (var ore in ores)
        {
            if (ore.oreType == (int)oreType)
            {
                switch (oreType)
                {
                    case Constants.Ore.Dolerito:
                        total = ore.amount * 1;
                        break;
                    case Constants.Ore.Granada:
                        total = ore.amount * 2;
                        break;
                    case Constants.Ore.Esmeralda:
                        total = ore.amount * 4;
                        break;
                    case Constants.Ore.Turmalina:
                        total = ore.amount * 10;
                        break;
                }
            }
        }
        return total;
    }

    public void OpenMoneyCalculator()
    {
        player.canMove = false;
        var child = this.transform.GetChild(0);
        if (child.gameObject.activeSelf)
        {
            child.gameObject.SetActive(false);
            Time.timeScale = 1;
            timeIsUp = false;
        }
        else
        {
            child.gameObject.SetActive(true);
            timeIsUp = true;
            Calculate();
            StartCoroutine(CanClose());
            StartCoroutine(AutomaticGoal());
        }
    }

    IEnumerator CanClose()
    {
        yield return new WaitForSeconds(2);
        canClose = true;
    }

    IEnumerator AutomaticGoal()
    {
        yield return new WaitForSeconds(10);

        if (timeIsUp) {
            player.canMove = true;
            OpenMoneyCalculator();
            goal.CalculateWinOrLose();
        }
    }
}
