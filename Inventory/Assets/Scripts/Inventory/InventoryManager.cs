using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    int selectedSlotIndex = -1;

    private void Start()
    {
        ChangeSelectedSlot(0);
    }

    private void Update()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber)
            {
                if (number > 0 && number < 10) ChangeSelectedSlot(number - 1);
                if (number == 0) ChangeSelectedSlot(9);
            }
        }
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlotIndex >= 0)
            inventorySlots[selectedSlotIndex].Deselect();
        inventorySlots[newValue].Select();
        selectedSlotIndex = newValue;
    }

    public bool AddItem(Item item)
    {
        // find stackable
        foreach (InventorySlot slot in inventorySlots)
        {
            InventoryItem inventoryItem = slot.GetComponentInChildren<InventoryItem>();
            if (inventoryItem != null &&
                inventoryItem.item == item &&
                item.stackable &&
                inventoryItem.count < item.maxStack)
            {
                inventoryItem.count++;
                inventoryItem.RefreshCount();
                return true;
            }
        }

        // find empty
        foreach (InventorySlot slot in inventorySlots)
        {
            if (slot.GetComponentInChildren<InventoryItem>() == null)
            {
                SpawnItem(item, slot);
                return true;
            }
        }
        Debug.Log("Inventory is full, but still trying to add item");
        return false;
    }

    void SpawnItem(Item item, InventorySlot slot)
    {
        GameObject newItem = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItem.GetComponent<InventoryItem>();
        inventoryItem.InitializeItem(item);
    }
}
