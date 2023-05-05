using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class InventoryItem : ScriptableObject
{
    [Header("PARAMETERS")]
    public string ID;
    public string Name;
    public Sprite Icon;
    [TextArea] public string Description;

    [Header("INFORMATION")]
    public ItemType type;
    public bool IsConsumable;
    public bool IsCumulative;
    public int MaxCumulative;

    [HideInInspector] public int Amount;

    public InventoryItem CopyItem()
    {
        InventoryItem newInstance = Instantiate(this);
        return newInstance;
    }
}
