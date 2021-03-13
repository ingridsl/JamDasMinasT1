using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCar : MonoBehaviour
{
    //public Sprite dropItemCar = null;
    public InventoryCar inventory = null;
    public InventoryManager InventoryManager = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerStay2D(Collider2D other)
    {   Debug.Log("iiiii");
        if (other.tag == "car")
        {   
            if (Input.GetMouseButtonDown(0))
            {   Debug.Log("foi");
                InventoryManager.RemoveObject();
               //OpenCloseCar();
            }
        }
    }

    /*public void OpenCloseCar()
    {
        var child = this.transform.GetChild(0);
        if (child.gameObject.activeSelf)
        {
            child.gameObject.SetActive(false);
            //Time.timeScale = 1;
        }
        else
        {
            child.gameObject.SetActive(true);
            //Time.timeScale = 0;
        }
    }*/
}
