using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfinerZone : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _camera;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.Player))
        {
            _camera.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.Player))
        {
            _camera.gameObject.SetActive(false);
        }
    }
}
