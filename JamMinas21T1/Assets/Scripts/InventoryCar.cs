using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCar : MonoBehaviour
{   
    Sprite obj1;
    Sprite obj2;
    Sprite obj3;
    Sprite obj4;

    int[] pontos = new int[]{0,0,0,0};

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
                        //inventoryFull = true;
                    }
                    break;
            }
        }
    }

    public void AddPoints(Sprite newObj){
        if (newObj == obj1){
            pontos[0]++;
        }
        else if(newObj == obj2){
            pontos[1]++;
        }
        else if(newObj == obj3){
            pontos[2]++;
        }
        else if(newObj == obj4){
            pontos[2]++;
        }
    }

    public void ReceiveObject(Sprite newObj)
    {
        switch (inventoryAmout)
        {
            case 0:
                obj1 = newObj;
                inventoryAmout++;
                pontos[0]++;
                AddInventoryImage();
                break;
            case 1:
                if(newObj != obj1){
                    obj2 = newObj;
                    pontos[1]++;
                    inventoryAmout++;
                    AddInventoryImage();
                }
                else{
                    pontos[0]++;
                }
                break;
            case 2:
                if(newObj != obj2 && newObj != obj1){
                    obj3 = newObj;
                    pontos[2]++;
                    inventoryAmout++;
                    AddInventoryImage();
                }
                else if(newObj == obj1){   
                    pontos[0]++;
                }
                else if(newObj == obj2){
                    pontos[1]++;
                }
                break;
            case 3:
                if(newObj != obj3 && newObj != obj2 && newObj != obj1){
                    obj4 = newObj;
                    inventoryAmout++;
                    pontos[3]++;
                    AddInventoryImage();
                }
                else if(newObj == obj1){   
                    pontos[0]++;
                }
                else if(newObj == obj2){
                    pontos[1]++;
                }
                else if(newObj == obj3){
                    pontos[2]++;
                }
                break;
            case 4:
                AddPoints(newObj);
                //N�o fazer nada ou barulhinho de erro
                break;
        }
    }
}
