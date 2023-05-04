using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private Transform respawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (character.CharacterLife.IsDefeated)
            {
                character.transform.localPosition = respawnPoint.position;
                character.RestoreCharacter();
            }
        }
    }
}
