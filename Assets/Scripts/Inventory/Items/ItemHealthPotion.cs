using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1, fileName = "ItemHealthPotion", menuName = "Items/Health Potion")]
public class ItemHealthPotion : InventoryItem
{
    [Header("POTION INFO")]
    public float HealthPointRestoration;
}
