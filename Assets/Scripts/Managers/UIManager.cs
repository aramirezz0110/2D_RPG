using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    #region UI REFERENCES
    [Header("STATS SO")]
    [SerializeField] private CharacterStats stats;

    [Header("PANELS")]
    [SerializeField] private GameObject panelStats;

    [Header("HEATH BAR REFERENCES")]
    [SerializeField] private Image playerHealth;
    [SerializeField] private TMP_Text healthText;

    [Header("MANA BAR REFERENCES")]
    [SerializeField] private Image playerMana;
    [SerializeField] private TMP_Text manaText;

    [Header("EXPERIENCE BAR REFERENCES")]
    [SerializeField] private Image playerExperience;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private TMP_Text currentLevelText;

    [Header("STATS UI REFERENCES")]
    [SerializeField] private TMP_Text statDamageText;
    [SerializeField] private TMP_Text statDefenseText;
    [SerializeField] private TMP_Text statCriticText;
    [SerializeField] private TMP_Text statBlockText;
    [SerializeField] private TMP_Text statSpeedText;
    [SerializeField] private TMP_Text statLevelText;
    [SerializeField] private TMP_Text statExperienceText;
    [SerializeField] private TMP_Text statExpRequiredText;

    [Header("ATTRIBUTES UI REFERENCES")]
    [SerializeField] private TMP_Text attributeAvailableText;
    [SerializeField] private TMP_Text attributeStrengthText;
    [SerializeField] private TMP_Text availableIntelligenceText;
    [SerializeField] private TMP_Text availableDexterityText;
    
    #endregion

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
        UpdateStatsPanel();
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
        currentLevelText.text = $"Level {stats.Level}";
    }
    private void UpdateStatsPanel()
    {
        if (!panelStats.activeSelf) return;

        //STATS
        statDamageText.text = stats.Damage.ToString();
        statDefenseText.text = stats.Defense.ToString();
        statCriticText.text = $"{stats.CriticPercentaje}%";
        statBlockText.text = $"{stats.BlockPercentaje}%";
        statSpeedText.text = stats.Speed.ToString();
        statLevelText.text = stats.Level.ToString();
        statExperienceText.text = stats.CurrentExperience.ToString();
        statExpRequiredText.text = stats.ExperienceRequiredNextLevel.ToString();

        //ATTRIBUTES
        attributeAvailableText.text=stats.AvailablePoints.ToString();
        attributeStrengthText.text=stats.Strength.ToString();
        availableIntelligenceText.text=stats.Intelligence.ToString();
        availableDexterityText.text=stats.Dexterity.ToString();
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