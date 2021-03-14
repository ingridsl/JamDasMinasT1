using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    float currentTime = 0f;
    public float startingTime = Constants.BASIC_COUNTDOWN_TIME;
    [SerializeField] Text countDownText;

    public MoneyCalculator moneyCalculator = null;

    bool timeIsUp = false;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    public void Restart(float newTime)
    {
        timeIsUp = false;
        currentTime = newTime;
        countDownText.color = Color.black;
        countDownText.fontSize = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (!timeIsUp) {
            CountDownTime();
        }
    }

    void CountDownTime()
    {
        currentTime -= 1 * Time.deltaTime;
        countDownText.text = currentTime.ToString("0");
        if (currentTime <= 10)
        {
            countDownText.color = Color.red;
            countDownText.fontSize = 35;
        }
        if (currentTime <= 5)
        {
            countDownText.color = Color.red;
            countDownText.fontSize = 40;
        }

        if (currentTime <= 0)
        {
            timeIsUp = true;
            countDownText.fontSize = 50;
            currentTime = 0;
            moneyCalculator.OpenMoneyCalculator();
            //gameOverObject.SetActive(true);
        }
    }
}