using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool wasdMovement = true;

    public KeyCode left = KeyCode.A;
    public KeyCode right = KeyCode.D;
    public KeyCode up = KeyCode.W;
    public KeyCode down = KeyCode.S;

    public GameObject[] randomGenerators;

    public GameObject permanentStones;

    // Start is called before the first frame update
    void Start()
    {
        randomGenerators = GameObject.FindGameObjectsWithTag("RandomGenerator");
        RestartStones(Constants.BASIC_RANDOM_STONES);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    public void RestartStones(int quantity)
    {
        foreach (var randomGenerator in randomGenerators)
        {
            foreach (Transform child in randomGenerator.transform)
            {
                Destroy(child.gameObject);
            }
            randomGenerator.GetComponent<RandomGenerator>().GenerateStones(quantity);
        }
    }

    public void RestartPermanentStones()
    {
        foreach (Transform child in permanentStones.transform)
        {
            if (!child.gameObject.activeSelf && child.gameObject.name != "TutorialStone")
            {
                child.gameObject.SetActive(true);
                var dropItem = child.gameObject.GetComponent<DropItem>();
                dropItem.isBroken = false;
                dropItem.ResetSprite();
            }
        }
    }

    public void ChangeMovementButton(bool isWASD)
    {
        if (wasdMovement != isWASD)
        {
            if (isWASD)
            {
                left = KeyCode.A;
                right = KeyCode.D;
                up = KeyCode.W;
                down = KeyCode.S;
            }
            else
            {
                left = KeyCode.LeftArrow;
                right = KeyCode.RightArrow;
                up = KeyCode.UpArrow;
                down = KeyCode.DownArrow;
            }
        }
    }
}
