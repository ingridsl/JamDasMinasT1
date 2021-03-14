using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    public PauseManager pauseManager = null;
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
    
}
