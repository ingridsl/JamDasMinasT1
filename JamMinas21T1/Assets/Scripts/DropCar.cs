using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCar : MonoBehaviour
{
    //public Sprite dropItemCar = null;
    public InventoryCar inventory = null;
    public InventoryManager InventoryManager = null;

    bool isInside = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isInside)
        {

        }
    }
    
    private void OnTriggerGeneral(Collider2D other)
    {

        var aux = InventoryManager.RemoveObject(); ;
        if (aux != null)
        {
            inventory.ReceiveObject(aux);
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnTriggerGeneral(other);
            }
        }
    }
}
