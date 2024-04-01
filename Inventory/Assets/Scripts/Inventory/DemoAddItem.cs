using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 思路：传一个Item的配置数据到UI里
/// </summary>
public class DemoAddItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickUpItem(int index)
    {
        inventoryManager.AddItem(itemsToPickUp[index]);
    }

    public void GetSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(false);
        if (receivedItem != null)
            Debug.Log(receivedItem.name);
        else
            Debug.Log("No item selected");
    }

    public void UseSelectedItem()
    {
        Item receivedItem = inventoryManager.GetSelectedItem(true);
        if (receivedItem != null)
            Debug.Log(receivedItem.name);
        else
            Debug.Log("No item selected");
    }
}
