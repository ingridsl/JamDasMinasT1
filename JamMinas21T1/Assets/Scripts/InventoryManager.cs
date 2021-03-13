using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    Sprite obj1;
    Sprite obj2;
    Sprite obj3;
    Sprite obj4;

    int inventoryAmout = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddInventoryImage()
    {
        var canvas = transform.GetChild(0);
        var panel = canvas.GetChild(0);
        foreach (Transform child in panel.transform)
        {
            switch (inventoryAmout)
            {
                case 0:
                    //N�o entra nesse caso
                    break;
                case 1:
                    if (child.gameObject.name == "Obj1" && obj1 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj1;
                    }
                    break;
                case 2:
                    if (child.gameObject.name == "Obj2" && obj2 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj2;
                    }
                    break;
                case 3:
                    if (child.gameObject.name == "Obj3" && obj3 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj3;
                    }
                    break;
                case 4:
                    if (child.gameObject.name == "Obj4" && obj4 != null)
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj4;
                    }
                    break;
            }
        }
    }

    public void RemoveObject()
    {
        //PROVISORIO: por enquanto, retirar na ordem q colocou. depois, poder retirar qualquer um
        var canvas = transform.GetChild(0);
        var panel = canvas.GetChild(0);
        foreach (Transform child in panel.transform)
        {
            switch (inventoryAmout)
            {
                case 0:
                    //N�o entra nesse caso
                    break;
                case 1:
                    if (child.gameObject.name == "Obj1")
                    {
                        inventoryAmout--;
                        child.gameObject.GetComponent<Image>().sprite = null;
                    }
                    break;
                case 2:
                    if (child.gameObject.name == "Obj1")
                    {
                        inventoryAmout--;
                        child.gameObject.GetComponent<Image>().sprite = obj2;
                    }
                    if (child.gameObject.name == "Obj2")
                    {
                        child.gameObject.GetComponent<Image>().sprite = null;
                    }
                    break;
                case 3:
                    if (child.gameObject.name == "Obj1")
                    {
                        inventoryAmout--;
                        child.gameObject.GetComponent<Image>().sprite = obj2;
                    }
                    if (child.gameObject.name == "Obj2")
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj3;
                    }
                    if (child.gameObject.name == "Obj3")
                    {
                        child.gameObject.GetComponent<Image>().sprite = null;
                    }
                    break;
                case 4:
                    if (child.gameObject.name == "Obj1")
                    {
                        inventoryAmout--;
                        child.gameObject.GetComponent<Image>().sprite = obj2;
                    }
                    if (child.gameObject.name == "Obj2")
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj3;
                    }
                    if (child.gameObject.name == "Obj3")
                    {
                        child.gameObject.GetComponent<Image>().sprite = obj4;
                    }
                    if (child.gameObject.name == "Obj4")
                    {
                        child.gameObject.GetComponent<Image>().sprite = null;
                    }
                    break;
            }
        }
    }

    public void ReceiveObject(Sprite newObj)
    {
        switch (inventoryAmout)
        {
            case 0:
                obj1 = newObj;
                inventoryAmout++;
                AddInventoryImage();
                break;
            case 1:
                obj2 = newObj;
                inventoryAmout++;
                AddInventoryImage();
                break;
            case 2:
                obj3 = newObj;
                inventoryAmout++;
                AddInventoryImage();
                break;
            case 3:
                obj4 = newObj;
                inventoryAmout++;
                AddInventoryImage();
                break;
            case 4:
                //N�o fazer nada ou barulhinho de erro
                break;
        }
    }
}