using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeBase : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] protected float initHealth;
    [SerializeField] protected float maxHealth;

    [field:SerializeField] public float Health { get; protected set; }

    #region UNITY METHODS
    protected virtual void Start()
    {
        Health = initHealth;
    }
    #endregion
    #region PUBLIC METHODS
    public void ReceiveDamage(float amount)
    {
        if (amount <= 0) return;

        if (Health > 0f)
        {
            Health -= amount;
            UpdateHealthBar(Health, maxHealth);
            if(Health<= 0f)
            {
                UpdateHealthBar(Health, maxHealth);
                CharacterDefeated();
            }
        }
    }
    #endregion
    #region PROTECTED METHODS
    protected virtual void UpdateHealthBar(float currentHealth, float maxHealth)
    {

    }
    protected virtual void CharacterDefeated()
    {

    }
    #endregion
}
