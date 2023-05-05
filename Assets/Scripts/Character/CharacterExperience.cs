using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterExperience : MonoBehaviour
{
    [SerializeField] private int maxLevel; //20
    [SerializeField] private int expBase; //2
    [SerializeField] private int incrementalValue; //2

    public int Level { get; private set; }

    private float expCurrentTemp;
    private float expRequiredNextLevel;

    #region UNITY METHODS
    private void Start()
    {
        Level= 1;
        expRequiredNextLevel = expBase;
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
        if(Level < maxLevel)
        {
            Level++;
            expCurrentTemp = 0;
            expRequiredNextLevel *= incrementalValue;
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
                UpdateLevel();
                AddExperience(expObtained);
            }
            else
            {
                expCurrentTemp += expObtained;
                if (expCurrentTemp == expRequiredNextLevel)
                {
                    UpdateLevel();
                }
            }
        }
        UpdateExperienceBar();
    }
    #endregion
}
