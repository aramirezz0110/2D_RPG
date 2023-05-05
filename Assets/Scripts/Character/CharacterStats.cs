using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order =1, fileName ="New Stats", menuName ="Stats")]
public class CharacterStats : ScriptableObject
{
    [Header("STATS")]
    [SerializeField] public float Damage=5f;
    [SerializeField] public float Defense=2f;
    [SerializeField] public float Speed=5f;
    [SerializeField] public float Level;
    [SerializeField] public float CurrentExperience;
    [SerializeField] public float ExperienceRequiredNextLevel;
    [SerializeField, Range(0f, 100f)] public float CriticPercentaje;
    [SerializeField, Range(0f, 100f)] public float BlockPercentaje;

    [Header("ATTRIBUTES")]
    [SerializeField] public int Strength;
    [SerializeField] public int Intelligence;
    [SerializeField] public int Dexterity;

    [HideInInspector] public int AvailablePoints;

    public void AddBonusToStrengthAttribute()
    {
        Damage += 2f;
        Defense += 1f;
        BlockPercentaje += 0.03f;
        Strength++;
    }
    public void AddBonusToIntelligenceAttribute()
    {
        Damage += 3f;
        CriticPercentaje += 0.2f;
        Intelligence++;
    }
    public void AddBonusToDexterityAttribute()
    {
        Speed += 0.1f;
        BlockPercentaje += 0.05f;
        Dexterity++;
    }
    public void ResetValues()
    {
        //STATS
        Damage = 5f;
        Defense= 5f;
        Speed = 0f;
        Level= 1f;
        CurrentExperience= 0f;
        ExperienceRequiredNextLevel= 0f;
        CriticPercentaje= 0f;
        BlockPercentaje= 0f;

        //ATTRIBUTES
        Strength = 0;
        Intelligence= 0;
        Dexterity= 0;

        AvailablePoints= 0;
    }
}
