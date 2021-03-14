using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public int oreType;
    public Sprite[] dropItem;
    bool isInside = false;

    public InventoryManager inventory = null;
    // Start is called before the first frame update
    void Start()
    {
        if (inventory == null)
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
        if (valorAleatorio < 0.45) //45% MIN�RIO MENOS VALIOSO
        {
            oreType = (int)Constants.Ore.Dolerito;
        }
        else if (0.45 < valorAleatorio && valorAleatorio < 0.75) //30%
        {
            oreType = (int)Constants.Ore.Granada;
        }
        else if (0.75 < valorAleatorio && valorAleatorio < 0.92) //17%
        {
            oreType = (int)Constants.Ore.Esmeralda;
        }
        else //8% MIN�RIO MAIS VALIOSO
        {
            oreType = (int)Constants.Ore.Turmalina;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = true;
            if (Input.GetMouseButtonDown(0))
            {
                OnTriggerGeneral(other);
            }
        }
    }   

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            isInside = false;
            var playerManager = other.transform.GetComponent<PlayerManager>();
            playerManager.isHitingOre = false;
        }
    }

    private void OnTriggerGeneral(Collider2D other)
    {
        var playerManager = other.transform.GetComponent<PlayerManager>();
        playerManager.isHitingOre = true;
        playerManager.ActivateMiningAnim();

        if (this.GetComponent<SpriteRenderer>().sprite != dropItem[(int)oreType])
        {
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
