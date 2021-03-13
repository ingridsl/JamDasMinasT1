using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{

    float currentTime = 0f;
    readonly float startingTime = 15;
    [SerializeField] Text countDownText;
    public GameObject gameOverObject = null;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
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
            countDownText.fontSize = 50;
            currentTime = 0;
            //gameOverObject.SetActive(true);
        }
    }
}