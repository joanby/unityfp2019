using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
 
    public void ShowOnly(int itemType){
        for (int i = 0; i < this.transform.childCount; i++){
            InventoryItemButton item = transform.GetChild(i).
                                          GetComponent<InventoryItemButton>();
            item.gameObject.SetActive(item.typeIndex == itemType);
        }
    }


    public void ShowAll(){
        for (int i = 0; i < this.transform.childCount; i++)
        {
            InventoryItemButton item = transform.GetChild(i).
                                          GetComponent<InventoryItemButton>();
            item.gameObject.SetActive(true);
        }
    }
}
