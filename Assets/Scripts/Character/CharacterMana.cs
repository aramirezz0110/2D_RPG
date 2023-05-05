using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterLife))]
public class CharacterMana : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private float initMana;
    [SerializeField] private float maxMana;
    [SerializeField] private float regenerationPerSecond;

    public float CurrentMana{ get; private set; }

    private CharacterLife characterLife;

    #region UNITY METHODS
    private void Awake()
    {
        characterLife= GetComponent<CharacterLife>();
    }
    private void Start()
    {
        CurrentMana = initMana;
        UpdateManaBar();

        InvokeRepeating(nameof(RegenerateMana), 1, 1f);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            UseMana(10);
        }
    }
    #endregion
    #region PRIVATE METHODS
    private void UpdateManaBar()
    {
        UIManager.Instance?.UpdateCharacterMana(CurrentMana, maxMana);
    }
    private void RegenerateMana()
    {
        if(characterLife.Health >0f && CurrentMana < maxMana)
        {
            CurrentMana += regenerationPerSecond;
            UpdateManaBar();
        }
        if (characterLife.Health <= 0)
        {
            CurrentMana = 0;
            UpdateManaBar();
        }
    }
    #endregion
    #region PUBLIC METHODS
    public void UseMana(float amount)
    {
        if (CurrentMana >= amount)
        {
            CurrentMana -= amount;
            UpdateManaBar();
        }
    }
    public void RestoreMana()
    {
        CurrentMana = initMana;
        UpdateManaBar();
    }
    #endregion
}
