using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterLife), typeof(CharacterAnimations))]
public class Character : MonoBehaviour
{
    public CharacterLife CharacterLife { get; private set; }
    public CharacterAnimations CharacterAnimations { get; private set; }

    private void Awake()
    {
        CharacterLife= GetComponent<CharacterLife>();
        CharacterAnimations= GetComponent<CharacterAnimations>();
    }
    public void RestoreCharacter()
    {
        CharacterLife.RestoreCharacter();
        CharacterAnimations.ReviveCharacter();
    }
}
