using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExperience : MonoBehaviour
{
    [Header("STATS")]
    [SerializeField] private CharacterStats stats;

    [SerializeField] private int maxLevel; //20
    [SerializeField] private int expBase; //2
    [SerializeField] private int incrementalValue; //2

    private float currentExperience;
    private float expCurrentTemp;
    private float expRequiredNextLevel;

    #region UNITY METHODS
    private void Start()
    {
        stats.Level= 1;
        expRequiredNextLevel = expBase;
        stats.ExperienceRequiredNextLevel = expRequiredNextLevel;
        UpdateExperienceBar();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AddExperience(2f);
        }
    }
    #endregion
    #region PRIVATE METHODS
    private void UpdateLevel()
    {
        if(stats.Level < maxLevel)
        {
            stats.Level++;
            expCurrentTemp = 0;
            expRequiredNextLevel *= incrementalValue;
            stats.ExperienceRequiredNextLevel = expRequiredNextLevel;
            stats.AvailablePoints += 3;
        }
    }
    private void UpdateExperienceBar()
    {
        UIManager.Instance?.UpdateCharacterExperience(expCurrentTemp, expRequiredNextLevel);
    }
    #endregion
    #region PUBLIC METHODS
    public void AddExperience(float expObtained)
    {
        if (expObtained > 0)
        {
            float expRemainingNewLevel = expRequiredNextLevel - expCurrentTemp;
            if (expObtained >= expRemainingNewLevel)
            {
                expObtained -= expRemainingNewLevel;
                currentExperience += expObtained;
                UpdateLevel();
                AddExperience(expObtained);
            }
            else
            {
                currentExperience += expObtained;
                expCurrentTemp += expObtained;
                if (expCurrentTemp == expRequiredNextLevel)
                {
                    UpdateLevel();
                }
            }
        }

        stats.CurrentExperience = currentExperience;
        UpdateExperienceBar();
    }
    #endregion
}
