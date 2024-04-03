using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour, IDropHandler, IPointerClickHandler
{
    public Image image;
    public Color selectedColor, normalColor;
    public int index;
    public bool isInventorySlot;

    // public void Awake()
    // {
    //     Deselect();
    // }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = normalColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            InventoryItem item = eventData.pointerDrag.GetComponent<InventoryItem>();
            item.parentAfterDrag = transform;
            item.transform.SetParent(transform);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isInventorySlot)
            Messenger.Broadcast<int>(MsgType.MouseSelectSlotIndex, index);
    }
}
