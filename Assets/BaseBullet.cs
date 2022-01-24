using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public abstract class BaseBullet : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed = 20f;

    public virtual void OnGetBullet()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnReleaseBullet()
    {
        gameObject.SetActive(false);
    }

    public abstract void Shoot(Vector3 direction);
}
