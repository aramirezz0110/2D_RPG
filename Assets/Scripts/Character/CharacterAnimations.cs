using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class CharacterAnimations : MonoBehaviour
{    
    private Animator _animator;
    private CharacterMovement characterMovement;

    #region UNITY METHODS
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        characterMovement = GetComponent<CharacterMovement>();
    }
    private void Update()
    {
        MoveAnimation();
    }
    private void OnEnable()
    {
        CharacterLife.CharacterDefeatedEvent += CharacterDefeatedResponse;
    }
    private void OnDisable()
    {
        CharacterLife.CharacterDefeatedEvent -= CharacterDefeatedResponse;
    }
    #endregion
    #region PRIVATE METHODS
    private void MoveAnimation()
    {
        UpdateLayers();

        if (!characterMovement.IsMoving) return;

        Vector2 moveValue = characterMovement.MovementDirection;
        _animator.SetFloat(CharacterAnimParams.X_Axis, moveValue.x);
        _animator.SetFloat(CharacterAnimParams.Y_Axis, moveValue.y);

    }
    private void ActivateLayer(string layerName)
    {
        for (int i = 0; i < _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        int layerIndex = _animator.GetLayerIndex(layerName);
        _animator.SetLayerWeight(layerIndex, 1);
    }
    private void UpdateLayers()
    {
        if (characterMovement.IsMoving)
            ActivateLayer(CharacterAnimParams.WalkLayer);
        else
            ActivateLayer(CharacterAnimParams.IdleLayer);
    }

    private void CharacterDefeatedResponse()
    {
        if (_animator.GetLayerWeight(_animator.GetLayerIndex(CharacterAnimParams.IdleLayer)) == 1)
        {
            _animator.SetBool(CharacterAnimParams.Defeated, true);
        }
        else
        {
            ActivateLayer(CharacterAnimParams.IdleLayer);
            _animator.SetBool(CharacterAnimParams.Defeated, true);
        }
    }
    #endregion
    #region PUBLIC METHODS
    public void ReviveCharacter()
    {
        ActivateLayer(CharacterAnimParams.IdleLayer);
        _animator.SetBool(CharacterAnimParams.Defeated, false);
    }
    #endregion
}
