using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGround : MonoBehaviour
{
    [SerializeField] private float _RotateSpeed = 1;

    void Update()
    {
        transform.Rotate(Vector3.up * _RotateSpeed * Time.deltaTime);
    }
}
