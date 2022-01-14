using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour
{
    public virtual void OnGetBullet()
    {
        gameObject.SetActive(true);
    }

    public virtual void OnReleaseBullet()
    {
        gameObject.SetActive(false);
    }
}
