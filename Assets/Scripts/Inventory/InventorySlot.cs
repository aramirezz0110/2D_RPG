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
    #endregion
}
