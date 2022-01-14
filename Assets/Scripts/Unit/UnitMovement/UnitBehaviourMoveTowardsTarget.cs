using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitBehaviourMoveTowardsTarget", menuName = "Unit/UnitMovement/UnitBehaviourMoveTowardsTarget")]
public class UnitBehaviourMoveTowardsTarget : UnitMovementBehaviour
{
    public override Vector3 GetMovementDirectionVector(UnitMovement unitMovement)
    {
        return unitMovement.transform.position - unitMovement.UnitMovementTarget.transform.position;
    }
}
