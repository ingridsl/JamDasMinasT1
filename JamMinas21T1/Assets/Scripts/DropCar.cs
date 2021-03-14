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
    {   
        if (other.tag == "Player")
        {   
            if (Input.GetMouseButtonDown(0))
            {   
                //InventoryManager.RemoveObject();
                inventory.ReceiveObject(InventoryManager.RemoveObject());                
            }
        }
    }
}
