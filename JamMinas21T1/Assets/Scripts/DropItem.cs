using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public int oreType;

    public Sprite originalStone;

    public Sprite[] dropItem;
    public bool isBroken = false;

    public AudioSource audio;

    public InventoryManager inventory = null;
    public GameObject inventoryFullHUD;
    // Start is called before the first frame update
    void Start()
    {
        if (inventory == null)
        {
            inventory = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        }
        if (inventoryFullHUD == null)
        {
            inventoryFullHUD = GameObject.FindGameObjectsWithTag("InventoryFull")[0];
        }
        ChooseOreType();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = originalStone;
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

    private void OnTriggerGeneral(Collider2D other)
    {
        var playerManager = other.transform.GetComponent<PlayerManager>();
        if (Input.GetMouseButtonDown(0))
        {
            if (!isBroken)
            {
                playerManager.isHitingOre = true;
                playerManager.ActivateMiningAnim();

                audio.Play();

                this.GetComponent<SpriteRenderer>().sprite = dropItem[(int)oreType];
                isBroken = true;
                StartCoroutine(ForceClickFalse(playerManager));
            }
            else
            {
                if (!inventory.inventoryFull)
                {
                    inventory.ReceiveObject(dropItem[(int)oreType]);
                    this.gameObject.SetActive(false);
                    playerManager.isHitingOre = false;
                }
                else
                {
                    var inventoryFullPanel = inventoryFullHUD.transform.GetChild(0);
                    inventoryFullPanel.gameObject.SetActive(true);
                    StartCoroutine(CloseInventoryFullHUD(inventoryFullPanel.gameObject));
                }
            }
        }
    }

    IEnumerator CloseInventoryFullHUD(GameObject inventoryFullPanel)
    {
        yield return new WaitForSeconds(2);
        inventoryFullPanel.SetActive(false);
    }

    IEnumerator ForceClickFalse(PlayerManager playerManager)
    {
        yield return new WaitForSeconds(1);
        playerManager.isHitingOre = false;
        playerManager.ActivateMiningAnim();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var playerManager = other.transform.GetComponent<PlayerManager>();
            playerManager.isHitingOre = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            OnTriggerGeneral(other);
        }
    }
}
