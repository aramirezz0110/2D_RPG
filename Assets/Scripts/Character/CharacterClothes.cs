using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterClothes : MonoBehaviour
{
    public ItemClothes ClothEquiped { get; private set; }

    private Image playerImage;
    private void Awake()
    {
        playerImage= GetComponent<Image>();
    }
    public void EquipClothes(ItemClothes clothesToEquip)
    {
        playerImage.color = clothesToEquip.clothesColor;
    }
}
