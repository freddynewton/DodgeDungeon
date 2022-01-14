using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolManager : Singleton<BulletPoolManager>
{
    [Header("Bullet pool general settings")]
    public int DefaultCapacity = 20;
    public int MaxCapacity = 150;

    [Space]
    [Header("Bullet pools")]
    [SerializeField] private BasicBullet BasicBullet;
    public LinkedPool<BasicBullet> BasicBulletPool;

    public void Start()
    {
        InitializeBasicBulletPool();
    }

    private void InitializeBasicBulletPool()
    {
        BasicBulletPool = new LinkedPool<BasicBullet>(
            () =>
            {
                // create the BulletObject
                return Instantiate(BasicBullet, transform);
            }, bullet =>
            {
                bullet.OnGetBullet();
            }, bullet =>
            {
                bullet.OnReleaseBullet();
            }, bullet =>
            {
                Destroy(bullet.gameObject);
            }, false, MaxCapacity);
    }
}
