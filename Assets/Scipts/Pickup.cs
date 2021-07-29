using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private float MoveSpeed = 4;
    public enum ePickUpType
    {
        Multiball,
        Extralife
    }

    public ePickUpType PickUpType = ePickUpType.Extralife;

    private void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * MoveSpeed);
    }
}
