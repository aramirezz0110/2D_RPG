using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI REFERENCES")]
    [SerializeField] private Image itemIcon;
    [SerializeField] private GameObject backgroungAmount;
    [SerializeField] private TMP_Text amountText;

    public static Action<InteractionType, int> SlotInteractionEvent;

    public int Index { get; set; }

    #region PUBLIC METHODS
    public void UpdateSlot(InventoryItem item, int amount)
    {
        itemIcon.sprite = item.Icon;
        amountText.text = amount.ToString();
    }
    public void ActivateSlotUI(bool state)
    {
        itemIcon.gameObject.SetActive(state);
        backgroungAmount.gameObject.SetActive(state);
    }
    public void ClickSlot() => SlotInteractionEvent?.Invoke(InteractionType.Click, Index);
    public void UseSlot() => SlotInteractionEvent?.Invoke(InteractionType.Use, Index);
    public void EquipSlot() => SlotInteractionEvent?.Invoke(InteractionType.Equip, Index);
    public void RemoveSlot() => SlotInteractionEvent?.Invoke(InteractionType.Remove, Index);
    #endregion
}
