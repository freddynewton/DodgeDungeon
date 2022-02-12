using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Pool;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed = 20f;
    [SerializeField] protected int ReleaseBulletTimeMS = 4000;

    protected UniTask ReleaseTask;
    protected Action ReleaseAction;
    protected CancellationTokenSource ReleaseCancelTokenSource = new CancellationTokenSource();

    public virtual void OnGetBullet()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnReleaseBullet()
    {
        ReleaseCancelTokenSource.Cancel();
        gameObject.SetActive(false);
    }

    protected virtual async UniTask ReleaseBulletAfterTimeTask()
    {
        await UniTask.Delay(ReleaseBulletTimeMS, cancellationToken: ReleaseCancelTokenSource.Token);
        ReleaseAction.Invoke();
    }

    public abstract void Shoot(Vector3 direction);

    private void OnEnable()
    {
        if (ReleaseCancelTokenSource != null)
        {
            ReleaseCancelTokenSource.Dispose();
        }
        ReleaseCancelTokenSource = new CancellationTokenSource();
    }
}
