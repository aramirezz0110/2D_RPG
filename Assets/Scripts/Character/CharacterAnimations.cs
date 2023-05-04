using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator), typeof(CharacterMovement))]
public class CharacterAnimations : MonoBehaviour
{    
    private Animator _animator;
    private CharacterMovement characterMovement;


    private void Awake()
    {
        _animator= GetComponent<Animator>();
        characterMovement= GetComponent<CharacterMovement>();
    }
    private void Update()
    {
        MoveAnimation();
    }
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
        for(int i=0; i< _animator.layerCount; i++)
        {
            _animator.SetLayerWeight(i, 0);
        }
        int layerIndex = _animator.GetLayerIndex(layerName);
        _animator.SetLayerWeight(layerIndex, 1);
    }
    private void UpdateLayers()
    {
        if (characterMovement.IsMoving)
            ActivateLayer(CharacterAnimParams.LayerWalk);
        else
            ActivateLayer(CharacterAnimParams.LayerIdle);
    }
}
