using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicBulletTower : MonoBehaviour
{
    [SerializeField] private BasicBullet BulletType;
    [SerializeField] private int FireRateMS;
    [HideInInspector] public bool isLookingAtPlayer;

    private void Awake()
    {
        _ = ShootTask();
    }

    public void SetRandomBulletBehaviour()
    {

    }

    private void Update()
    {
        if (isLookingAtPlayer)
        {
            transform.LookAt(PlayerManager.Instance.PlayerCharacter.transform.position, Vector3.forward);
        }
    }

    private async UniTaskVoid ShootTask()
    {
        if (BulletPoolManager.Instance.BasicBulletPool != null)
        {
            var bullet = BulletPoolManager.Instance.BasicBulletPool.Get();
            bullet.transform.position = transform.TransformPoint(Vector3.right);

            bullet.Shoot(gameObject.transform.right);
        }

        await UniTask.Delay(FireRateMS);

        _ = ShootTask();
    }
}
