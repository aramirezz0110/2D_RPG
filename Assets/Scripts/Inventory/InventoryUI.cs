using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    private List<InventorySlot> availableSlots = new List<InventorySlot>();

    #region UNITY METHODS
    private void Start()
    {
        InitializeInventory();
    }
    #endregion
    #region PRIVATE METHODS
    private void InitializeInventory()
    {
        for (int i=0; i<Inventory.Instance.SlotsAmount;i++)
        {
            InventorySlot newSlot = Instantiate(slotPrefab, container);
            newSlot.Index= i;
            availableSlots.Add(newSlot);
        }
    }

    #endregion
}
