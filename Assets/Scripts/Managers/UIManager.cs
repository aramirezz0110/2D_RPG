using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [Header("HEATH BAR REFERENCES")]
    [SerializeField] private Image playerHealth;
    [SerializeField] private TMP_Text healthText;

    [Header("MANA BAR REFERENCES")]
    [SerializeField] private Image playerMana;
    [SerializeField] private TMP_Text manaText;

    [Header("EXPERIENCE BAR REFERENCES")]
    [SerializeField] private Image playerExperience;
    [SerializeField] private TMP_Text experienceText;

    private float currentHealth;
    private float maxHealth;

    private float currentMana;
    private float maxMana;

    private float currentExperience;
    private float expRequiredNewLevel;

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
        //HEALTH
        playerHealth.fillAmount = Mathf.Lerp(playerHealth.fillAmount, currentHealth/maxHealth, 10*Time.deltaTime);
        healthText.text = $"{currentHealth}/{maxHealth}";

        //MANA
        playerMana.fillAmount = Mathf.Lerp(playerMana.fillAmount, currentMana / maxMana, 10 * Time.deltaTime);
        manaText.text = $"{currentMana}/{maxMana}";

        //EXPERIENCE
        playerExperience.fillAmount = Mathf.Lerp(playerExperience.fillAmount, currentExperience / expRequiredNewLevel, 10 * Time.deltaTime);
        experienceText.text = $"{((currentExperience/expRequiredNewLevel)*100):F2}%";
    }
    #endregion
    #region PUBLIC METHODS
    public void UpdateCharacterHealth(float pCurrentHealth, float pMaxHealth)
    {
        currentHealth= pCurrentHealth;
        maxHealth= pMaxHealth;
    } 
    public void UpdateCharacterMana(float pCurrentMana, float pMaxMana)
    {
        currentMana= pCurrentMana;
        maxMana= pMaxMana;
    }    
    public void UpdateCharacterExperience(float pCurrentExp, float pExperienceRequired)
    {
        currentExperience= pCurrentExp;
        expRequiredNewLevel= pExperienceRequired;
    }
    #endregion
}