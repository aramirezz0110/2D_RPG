using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterLife), typeof(CharacterAnimations))]
public class Character : MonoBehaviour
{
    [SerializeField] private CharacterStats stats;
    public CharacterLife CharacterLife { get; private set; }
    public CharacterAnimations CharacterAnimations { get; private set; }
    public CharacterMana CharacterMana { get; private set; }

    private void Awake()
    {
        CharacterLife= GetComponent<CharacterLife>();
        CharacterAnimations= GetComponent<CharacterAnimations>();
        CharacterMana= GetComponent<CharacterMana>();
    }
    private void OnEnable()
    {
        AttributeButton.AddAttributeEvent += AttributeResponse;
    }
    private void OnDisable()
    {
        AttributeButton.AddAttributeEvent -= AttributeResponse;
    }

    private void AttributeResponse(AttributeType type)
    {
        if(stats.AvailablePoints <= 0) return;

        switch (type)
        {
            case AttributeType.Strength:
                stats.AddBonusToStrengthAttribute();
                break;
            case AttributeType.Intelligence:
                stats.AddBonusToIntelligenceAttribute();
                break;
            case AttributeType.Dexterity:
                stats.AddBonusToDexterityAttribute();
                break;
            default: break;
        }
        stats.AvailablePoints-=1;
    }

    public void RestoreCharacter()
    {
        CharacterLife.RestoreCharacter();
        CharacterAnimations.ReviveCharacter();
        CharacterMana.RestoreMana();
    }
}
