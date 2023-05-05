using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : Singleton<Inventory>
{
    [SerializeField] private int slotsAmount;

    [Header("ITEMS")]
    [SerializeField] private InventoryItem[] inventoryItems;
    public int SlotsAmount => slotsAmount;
    #region UNITY METHODS
    private void Start()
    {
        inventoryItems= new InventoryItem[slotsAmount];
    }
    #endregion
}
