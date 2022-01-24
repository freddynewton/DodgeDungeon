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
        if (collision.gameObject.tag == "Bullet")
        {
            return;
        }


        BulletPoolManager.Instance.BasicBulletPool.Release(this);

        if (collision.gameObject.tag == "Player")
        {
            PlayerManager.Instance.OnHealthPointsReduced(1);
        }
    }
}
