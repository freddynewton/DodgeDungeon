using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    public float CollectableMoveRange;
    public EndlessModeCollectable EndlessModeCollectable;
    public EndlessModeButton EndlessModeButton;


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, CollectableMoveRange);
    }
}
