using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterLife), typeof(CharacterAnimations))]
public class Character : MonoBehaviour
{
    public CharacterLife CharacterLife { get; private set; }
    public CharacterAnimations CharacterAnimations { get; private set; }
    public CharacterMana CharacterMana { get; private set; }

    private void Awake()
    {
        CharacterLife= GetComponent<CharacterLife>();
        CharacterAnimations= GetComponent<CharacterAnimations>();
        CharacterMana= GetComponent<CharacterMana>();
    }
    public void RestoreCharacter()
    {
        CharacterLife.RestoreCharacter();
        CharacterAnimations.ReviveCharacter();
        CharacterMana.RestoreMana();
    }
}
