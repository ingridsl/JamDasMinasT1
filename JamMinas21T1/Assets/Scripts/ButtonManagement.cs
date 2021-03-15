using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public PauseManager pauseManager = null;
    public GameObject panel = null;
    public Goal goal = null;
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
        if(goal == null)
        {
            var goals = GameObject.FindGameObjectsWithTag("Goal");
            foreach (var goal in goals)
            {
                goal.GetComponent<Goal>().SetGoal();
                return;
            }
        }
        goal.SetGoal();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("InitialMap");
    }

    public void OpenClosePause()
    {
        pauseManager.OpenClosePause();
    }
    
    public void OpenClosePanel()
    {
        var panelCanvas = panel.transform.GetChild(0);
        if (panelCanvas.gameObject.activeSelf)
        {
            panelCanvas.gameObject.SetActive(false);
        }
        else
        {
            panelCanvas.gameObject.SetActive(true);
        }
    }
}
