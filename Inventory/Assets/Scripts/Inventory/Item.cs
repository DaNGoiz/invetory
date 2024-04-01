using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject
{
    [Header("Gameplay")]
    public ItemType type;
    public ActionType actionType;
    public int maxStack = 20;
    public Vector2Int size = new Vector2Int(5, 4);

    [Header("UI")]
    public Sprite image;
    public bool stackable = true;

    public enum ItemType
    {
        Plant,
        Seed,
        Tool,
        Fertilizer
    }

    public enum ActionType
    {
        Dig,
        Plant,
        Water,
        Fertilize
    }
}
