using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Slider movementSlider = null;
    public GameManager game = null;
    bool paused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (game.wasdMovement != (movementSlider.value == 0)) {
            game.changeMovementButton(movementSlider.value == 0);
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            var child = this.transform.GetChild(0);
            if (child.gameObject.activeSelf && !paused)
            {
                paused = true;
                child.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                paused = false;
                child.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
