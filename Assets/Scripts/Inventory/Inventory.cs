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
    #region PRIVATE METHODS
    public void AddItem(InventoryItem itemToAdd, int amount)
    {
        if(!itemToAdd) return;

        //Check if the inventory has this item
        List<int> indexes = CheckExistences(itemToAdd.ID);
        if (itemToAdd.IsCumulative)
        {
            if(indexes.Count > 0)
            {
                for (int i=0; i<indexes.Count;i++)
                {
                    if (inventoryItems[indexes[i]].Amount < itemToAdd.MaxCumulative)
                    {
                        inventoryItems[indexes[i]].Amount += amount;
                        if (inventoryItems[indexes[i]].Amount > itemToAdd.MaxCumulative)
                        {
                            int diff = inventoryItems[indexes[i]].Amount - itemToAdd.MaxCumulative;
                            inventoryItems[indexes[i]].Amount = itemToAdd.MaxCumulative;
                            AddItem(itemToAdd, diff);
                        }

                        InventoryUI.Instance?.DrawItemOnInventary(itemToAdd, inventoryItems[indexes[i]].Amount, indexes[i]);
                        return;
                    }
                }
            }
        }

        if (amount <= 0) return;

        if (amount > itemToAdd.MaxCumulative)
        {
            AddItemInAvailableSlot(itemToAdd, itemToAdd.MaxCumulative);
            amount-= itemToAdd.MaxCumulative;
            AddItem(itemToAdd, amount);
        }
        else
        {
            AddItemInAvailableSlot(itemToAdd, amount);
        }
    }

    private void AddItemInAvailableSlot(InventoryItem item, int amount)
    {
        for (int i=0; i<inventoryItems.Length;i++)
        {
            if (!inventoryItems[i])
            {
                inventoryItems[i] = item.CopyItem();
                inventoryItems[i].Amount = amount;
                InventoryUI.Instance?.DrawItemOnInventary(item, amount, i);
                return;
            }
        }
    }

    private List<int> CheckExistences(string itemID)
    {
        List<int> itemIndexes = new List<int>();
        for (int i=0; i< inventoryItems.Length; i++)
        {
            if (inventoryItems[i])
            {
                if (inventoryItems[i].ID == itemID)
                {
                    itemIndexes.Add(i);
                }
            }
        }
        return itemIndexes;
    }    
    #endregion
}
