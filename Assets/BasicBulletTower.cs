using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicBulletTower : MonoBehaviour
{
    [SerializeField] private BasicBullet BulletType;
    [SerializeField] private int FireRateMS;

    private void Awake()
    {
        _ = ShootTask();
    }

    private async UniTaskVoid ShootTask()
    {
        var bullet = BulletPoolManager.Instance.BasicBulletPool.Get();
        bullet.transform.position = transform.right;

        bullet.Shoot(transform.right);

        await UniTask.Delay(FireRateMS);

        _ = ShootTask();
    }
}
