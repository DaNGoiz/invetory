using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public void AddItem(Item item)
    {
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.GetComponentInChildren<InventoryItem>() == null)
            {
                SpawnItem(item, slot);
                return;
            }
        }
    }

    void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
}
