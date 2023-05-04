using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
    [Header("CONFIG")]
    [SerializeField] private float speed=5f;
    
    [Header("REFERENCES")]
    [SerializeField] private PlayerInputReader inputReader;

    public Vector2 MovementDirection => inputReader.MovementValue;
    public bool IsMoving => inputReader.MovementValue.magnitude > 0f;

    private Rigidbody2D _rigidbody2D;

    #region UNITY METHODS
    private void Awake()
    {
        _rigidbody2D= GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        Move();
    }
    #endregion
    #region PRIVATE METHODS
    private void Move()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position+inputReader.MovementValue*speed*Time.fixedDeltaTime);
    }
    #endregion
}
