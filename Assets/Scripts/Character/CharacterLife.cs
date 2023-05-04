using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLife : LifeBase
{
    public static Action CharacterDefeatedEvent;
    public bool CanBeHealed => Health < maxHealth;
    public bool IsDefeated { get; private set; }

    private BoxCollider2D boxCollider2D;

    #region UNITY METHODS
    private void Awake()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }
    protected override void Start()
    {
        base.Start();
        UpdateHealthBar(Health, maxHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            ReceiveDamage(10);
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            RestoreHealth(10);
        }
    }
    #endregion
    public void RestoreHealth(float amount)
    {
        if (IsDefeated) return;

        if (!CanBeHealed) return;

        Health += amount;
        if (Health > maxHealth)
        {
            Health= maxHealth;
        }
        UpdateHealthBar(Health, maxHealth);
    }
    protected override void UpdateHealthBar(float currentHealth, float maxHealth)
    {
        UIManager.Instance?.UpdateCharacterHealth(currentHealth, maxHealth);
    }
    public void RestoreCharacter()
    {
        boxCollider2D.enabled = true;
        IsDefeated= false;
        Health = initHealth;
        UpdateHealthBar(Health, maxHealth);
    }
    protected override void CharacterDefeated()
    {
        boxCollider2D.enabled = false;
        IsDefeated = true;        
        CharacterDefeatedEvent?.Invoke();
    }

}
