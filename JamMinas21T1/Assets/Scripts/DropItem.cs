using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public enum Ore {
        Dolerito,
        Granada,
        Esmeralda,
        Turmalina
    };

    public int oreType;
    public Sprite[] dropItem;

    public InventoryManager inventory = null;
    // Start is called before the first frame update
    void Start()
    {
        if(inventory == null)
        {
            inventory = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        }
        ChooseOreType();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChooseOreType()
    {
        var valorAleatorio = UnityEngine.Random.Range(0f, 1f);
        if (valorAleatorio < 0.55) //55% MINÉRIO MENOS VALIOSO
        {
            oreType = (int)Ore.Dolerito;
        }
        else if(0.55 < valorAleatorio && valorAleatorio < 0.8) //25%
        {
            oreType = (int)Ore.Granada;
        }
        else if (0.8 < valorAleatorio && valorAleatorio < 0.95) //15%
        {
            oreType = (int)Ore.Esmeralda;
        }
        else //5% MINÉRIO MAIS VALIOSO
        {
            oreType = (int)Ore.Turmalina;
        }
    }


    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (this.GetComponent<SpriteRenderer>().sprite != dropItem[(int) oreType]) {
                    this.GetComponent<SpriteRenderer>().sprite = dropItem[(int)oreType];
                }
                else
                {
                    if (!inventory.inventoryFull)
                    {
                        inventory.ReceiveObject(dropItem[(int)oreType]);
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }
}
