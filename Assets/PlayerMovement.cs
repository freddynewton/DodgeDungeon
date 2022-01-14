using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Vector2 DirectionVector { get; set; }
    [SerializeField] private Rigidbody2D rigidbody;

    private void Update()
    {
        ApplyMovementVector();
    }

    private void ApplyMovementVector()
    {
        rigidbody.velocity = GetDirectionVector() * PlayerManager.Instance.BaseMovementSpeed * Time.deltaTime;
    }

    private Vector2 GetDirectionVector()
    {
        return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

}
