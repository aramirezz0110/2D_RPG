using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] private Transform newPosition;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.Player))
        {
            collision.transform.localPosition = newPosition.position;
        }
    }
}
