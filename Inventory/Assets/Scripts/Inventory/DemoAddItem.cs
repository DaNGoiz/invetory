using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAddItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickUp;

    public void PickUpItem(int index)
    {
        inventoryManager.AddItem(itemsToPickUp[index]);
    }
}
