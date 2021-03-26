using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{

    public int oreType;

    public Sprite originalStone;

    public Sprite[] dropItem;
    public bool isBroken = false;

   // public AudioSource hitAudio;

    public InventoryManager inventory = null;
    public GameObject inventoryFullHUD;

    bool isInside = false;
    PlayerManager playerManager;
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
        if (isInside && Input.GetMouseButtonDown(0) && playerManager != null)
        {
            BreakGetOre();
        }
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

    private void BreakGetOre()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!this.isBroken)
            {
                playerManager.isHitingOre = true;
                playerManager.ActivateMiningAnim(true);

               // hitAudio.Play();

                this.GetComponent<SpriteRenderer>().sprite = dropItem[(int)oreType];
                StartCoroutine(ForceClickFalse(playerManager, 0.7f));
                isBroken = true;
            }
            else
            {
                if (!inventory.inventoryFull)
                {
                    inventory.ReceiveObject(dropItem[(int)oreType]);
                    //StartCoroutine(playerManager.ForceClickFalse(0.5f));
                    //playerManager.isHitingOre = false;

                    //playerManager.ActivateMiningAnim(false);
                    isInside = false;
                    this.gameObject.SetActive(false);
                }
                else
                {
                    var inventoryFullPanel = inventoryFullHUD.transform.GetChild(0);
                    StartCoroutine(CloseInventoryFullHUD(inventoryFullPanel.gameObject));
                    StartCoroutine(ForceClickFalse(playerManager, 0.5f));
                    inventoryFullPanel.gameObject.SetActive(true);
                }
            }
        }
    }

    IEnumerator CloseInventoryFullHUD(GameObject inventoryFullPanel)
    {
        yield return new WaitForSeconds(2);
        inventoryFullPanel.SetActive(false);
    }

    IEnumerator ForceClickFalse(PlayerManager playerManager, float waitSeconds)
    {
        yield return new WaitForSeconds(waitSeconds);
        playerManager.isHitingOre = false;
        playerManager.ActivateMiningAnim(false);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "PlayerTrigger")
        {
            StartCoroutine(ExitCountDown());
            var playerManager = other.transform.parent.transform.GetComponent<PlayerManager>();
            playerManager.isHitingOre = false;
        }
    }

    IEnumerator ExitCountDown()
    {
        yield return new WaitForSeconds(0.2f);
        isInside = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PlayerTrigger")
        {
            isInside = true;
            playerManager = other.transform.parent.transform.GetComponent<PlayerManager>();
            //OnTriggerGeneral(other);
        }
    }
}
