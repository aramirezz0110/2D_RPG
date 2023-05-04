using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private Image playerHealth;
    [SerializeField] private TMP_Text healthText;

    private float currentHealth;
    private float maxHealth;

    #region UNITY METHODS    
    private void Start()
    {
        
    }
    private void Update()
    {
        UpdateCharacterUI();
    }
    #endregion
    #region PRIVATE METHODS
    private void UpdateCharacterUI()
    {
        playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, currentHealth/maxHealth, 10*Time.deltaTime);
        healthText.text = $"{currentHealth}/{maxHealth}";
    }
    #endregion
    #region PUBLIC METHODS
    public void UpdateCharacterHealth(float pCurrentHealth, float pMaxHealth)
    {
        currentHealth= pCurrentHealth;
        maxHealth= pMaxHealth;
    }    
    #endregion
}