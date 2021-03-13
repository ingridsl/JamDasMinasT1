using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public Sprite dropItem = null;
    public InventoryManager inventory = null;
    // Start is called before the first frame update
    void Start()
    {
        if(inventory == null)
        {
            inventory = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        }
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
                if (this.GetComponent<SpriteRenderer>().sprite != dropItem) {
                    this.GetComponent<SpriteRenderer>().sprite = dropItem;
                }
                else
                {
                    inventory.ReceiveObject(dropItem);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
