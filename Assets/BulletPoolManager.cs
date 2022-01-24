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
    [SerializeField] private BasicBullet BasicBullet;
    public ObjectPool<BasicBullet> BasicBulletPool;

    public void Start()
    {
        InitializeBasicBulletPool();
    }

    private void InitializeBasicBulletPool()
    {
        BasicBulletPool = new ObjectPool<BasicBullet>(
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
      }, false, DefaultCapacity, MaxCapacity);
    }

    private static void recursiveCombination(int[] array, int n)
    {
        if (n > array.Length) return;

        string printString = string.Empty;

        int index = 0;
        int _n = 0;

        while (index < array.Length)
        {
            if (_n <= n && _n < array.Length & index < array.Length)
            {
                printString += array[index + _n].ToString() + " ";
                _n++;
            }
            else
            {
                print(printString);
                index++;
                _n = 0;
            }
        }

        recursiveCombination(array.Where((val, idx) => idx != 0).ToArray(), n);
    }
}
