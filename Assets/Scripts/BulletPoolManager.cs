using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPoolManager : Singleton<BulletPoolManager>
{
    [Header("Bullet pool general settings")]
    public int DefaultCapacity = 20;
    public int MaxCapacity = 150;

    [Space]
    [Header("Bullet pools")]
    [SerializeField] private GameObject BasicBullet;

    private ObjectPool<BasicBullet> m_basicBulletPool;
    public ObjectPool<BasicBullet> BasicBulletPool
    {
        get
        {
            if (m_basicBulletPool == null)
            {
                m_basicBulletPool = new ObjectPool<BasicBullet>(() =>
                {
                    var go = Instantiate(BasicBullet, transform);
                    var bullet = go.GetComponent<BasicBullet>();

                    return bullet;
                }, bullet =>
                {
                    bullet.OnGetBullet();
                }, bullet =>
                {
                    bullet.OnReleaseBullet();
                }, bullet =>
                {
                    Destroy(bullet.gameObject);
                }, false, DefaultCapacity, MaxCapacity);
            }
            return m_basicBulletPool;
        }
    }

    public void ReleaseAllBasicBullets()
    {
        foreach (BasicBullet bullet in gameObject.GetComponentsInChildren<BasicBullet>())
        {
            BasicBulletPool.Release(bullet);
        }
    }
}
