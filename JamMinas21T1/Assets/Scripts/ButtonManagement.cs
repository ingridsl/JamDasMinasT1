using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public PauseManager pauseManager = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HarderGame()
    {

    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("InitialMap");
    }

    public void OpenClosePause()
    {
        pauseManager.OpenClosePause();
    }
}
