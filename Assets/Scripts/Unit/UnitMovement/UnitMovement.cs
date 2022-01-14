using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D Rigidbody;
    public Transform UnitMovementTarget;

    [Space]
    [Header("Value settings")]
    public float MovementSpeed = 5;
    public List<UnitMovementBehaviourContainer> MovementBehaviours = new List<UnitMovementBehaviourContainer>();

    private Vector3 directionVector = default;

    private void Update()
    {
        this.GetDirectionVector();
        ApplyDirectionVector();
    }

    private void ApplyDirectionVector()
    {
        Rigidbody.velocity = directionVector.normalized * MovementSpeed * Time.deltaTime;
    }

    private void GetDirectionVector()
    {
        directionVector = Vector3.zero;
        foreach (var behaviour in MovementBehaviours)
        {
            directionVector += behaviour.unitMovementBehaviour.GetMovementDirectionVector(this) * behaviour.weight;
        }
        directionVector /= -MovementBehaviours.Count;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, Rigidbody.velocity.normalized * 1.5f);
    }
}
