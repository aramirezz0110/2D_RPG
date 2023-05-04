using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;

    #region UNITY METHODS
    private void Awake()
    {
        _rigidbody2D= GetComponent<Rigidbody2D>();
    }
    #endregion
}
