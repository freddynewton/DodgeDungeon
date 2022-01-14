using UnityEngine;

public abstract class UnitMovementBehaviour : ScriptableObject
{
    public abstract Vector3 GetMovementDirectionVector(UnitMovement unitMovement);
}
