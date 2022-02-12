using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndlessModeButton : MonoBehaviour
{
    public CollectableManager CollectableManager;
    [HideInInspector] public CircleCollider2D CircleCollider2D;

    public UnityEvent SetOnActivate;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SetOnActivate.Invoke();
            CircleCollider2D.enabled = false;
        }
    }

    private void Awake()
    {
        CircleCollider2D = gameObject.GetComponent<CircleCollider2D>();
    }
}
