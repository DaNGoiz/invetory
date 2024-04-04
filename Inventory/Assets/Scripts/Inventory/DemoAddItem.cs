using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 思路：传一个Item的配置数据到UI里
/// 
/// TODO:
/// 1. 鼠标选中哪个slot，哪个slot也要标为被选中，这个slot的颜色要变化，其他slot的颜色要恢复（已完成）
///     1.1. 拿起物体放下也要更改选中（已完成）
///         1.1.1. 只有inventory里的slot才能被选中，箱子里的slot不行（已完成）
///         1.1.2. 1.1 这个效果不要了（已完成）
///     1.2. Slot要重新标注index，不再依赖transform的顺序，还要标上是哪个inventory的（已完成）
///     1.3. 打开箱子以后color要消失，关闭箱子以后color要恢复
/// 2. 鼠标上有一个item，拖动到有相同item的slot上，数量堆叠，其他情况对调slot里的item和鼠标上的item
/// 3. 当箱子关闭时，鼠标上的item要放回原来的slot，并且箱子的index不再算入当前inventory的index
/// 4. 每个箱子有一个数组，记录每个slot的item，打开箱子时，根据这个数组生成slot的item，关闭箱子时，根据slot的item更新这个数组
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
