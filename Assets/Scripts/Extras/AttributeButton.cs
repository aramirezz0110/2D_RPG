using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeButton : MonoBehaviour
{
    public static Action<AttributeType> AddAttributeEvent;

    [SerializeField] private AttributeType type;

    public void AddAttribute() => AddAttributeEvent?.Invoke(type);
}
