using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : Singleton<InventoryUI>
{
    [Header("INVENTORY PANEL DESCRIPTION")]
    [SerializeField] private GameObject inventoryPanelDescription;
    [SerializeField] private Image itemIcon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemDescription;
    
    [Header("PREFAB REFERENCES")]
    [SerializeField] private InventorySlot slotPrefab;
    [SerializeField] private Transform container;

    private List<InventorySlot> availableSlots = new List<InventorySlot>();

    public int selectedItem;

    #region UNITY METHODS
    private void Start()
    {
        InitializeInventory();
    }
    private void OnEnable()
    {
        InventorySlot.SlotInteractionEvent += SlotInteractionResponse;
    }
    private void OnDisable()
    {
        InventorySlot.SlotInteractionEvent -= SlotInteractionResponse;
    }

    private void SlotInteractionResponse(InteractionType interactionType, int index)
    {
        switch (interactionType)
        {
            case InteractionType.Click:
                UpdateInventoryDescription(index);
                selectedItem= index;
                break;
            case InteractionType.Use:
                break;
            case InteractionType.Equip:
                break;
            case InteractionType.Remove:
                break;
            default: break;
        }
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
    private void UpdateInventoryDescription(int index)
    {
        InventoryItem inventoryItem = Inventory.Instance.InventoryItems[index];

        if (inventoryItem)
        {
            inventoryPanelDescription.SetActive(true);
            itemIcon.sprite = inventoryItem.Icon;
            itemName.text = inventoryItem.Name;
            itemDescription.text = inventoryItem.Description;
        }
        else
        {
            inventoryPanelDescription.SetActive(false);
        }
        
    }
    #endregion
    #region PUBLIC METHODS
    public void DrawItemOnInventary(InventoryItem itemToAdd, int amount, int itemIndex)
    {
        InventorySlot slot = availableSlots[itemIndex];
        if (itemToAdd)
        {
            slot.ActivateSlotUI(true);
            slot.UpdateSlot(itemToAdd, amount);
        }
        else
        {
            slot.ActivateSlotUI(false);
        }
    }
    public void EquipButtonPressed()
    {
        
    }
    #endregion
}
