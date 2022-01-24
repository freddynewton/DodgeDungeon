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
    }

    private void Update()
    {
        transform.Translate(directionVector * MovementSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BulletPoolManager.Instance.BasicBulletPool.Release(this);
    }
}
