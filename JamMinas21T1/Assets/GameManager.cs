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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeMovementButton(bool isWASD)
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
