using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : BaseBullet
{
    private Vector3 directionVector;

    public override void OnGetBullet()
    {
        base.OnGetBullet();
    }

    public override void OnReleaseBullet()
    {
        base.OnReleaseBullet();
    }

    public override void Shoot(Vector3 direction)
    {
        directionVector = direction;
        _ = shootMovementTask();
    }

    private async UniTaskVoid shootMovementTask()
    {
        transform.Translate(directionVector * MovementSpeed * Time.deltaTime);
        _ = shootMovementTask();
    }
}
