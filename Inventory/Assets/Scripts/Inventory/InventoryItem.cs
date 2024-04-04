using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [Header("UI")]
    public Image image;
    public Text countText;

    [HideInInspector] public Item item;
    [HideInInspector] public int count = 1;
    [HideInInspector] public Transform parentAfterDrag;

    public void InitializeItem(Item newItem) // 目前UI只接收贴图
    {
        item = newItem;
        image.sprite = newItem.image;
        RefreshCount();
    }
    public void RefreshCount()
    {
        countText.text = count.ToString();
        bool isActive = count > 1;
        countText.gameObject.SetActive(isActive);
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        image.raycastTarget = false;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        image.raycastTarget = true;
        transform.SetParent(parentAfterDrag);
        // if (parentAfterDrag.GetComponent<InventorySlot>().isInventorySlot)
        //     Messenger.Broadcast<int>(MsgType.MouseSelectSlotIndex, parentAfterDrag.GetComponent<InventorySlot>().index);
    }
}
