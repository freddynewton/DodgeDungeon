using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicBulletTower : MonoBehaviour
{
    [SerializeField] private BasicBullet BulletType;
    [SerializeField] private int FireRateMS;
    [SerializeField] private int releaseTimer;

    private void Awake()
    {
        _ = ShootTask();
    }

    private async UniTaskVoid ShootTask()
    {
        if (BulletPoolManager.Instance.BasicBulletPool != null)
        {
            var bullet = BulletPoolManager.Instance.BasicBulletPool.Get();
            bullet.transform.position = transform.TransformPoint(Vector3.right);

            bullet.Shoot(gameObject.transform.right);
            releaseBulletAfterTime(bullet);
        }

        await UniTask.Delay(FireRateMS);

        _ = ShootTask();
    }

    private async UniTaskVoid releaseBulletAfterTime(BasicBullet bullet)
    {
        await UniTask.Delay(releaseTimer);

        BulletPoolManager.Instance.BasicBulletPool.Release(bullet);

    }
}
