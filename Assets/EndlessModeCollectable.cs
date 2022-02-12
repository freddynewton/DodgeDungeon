using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndlessModeCollectable : MonoBehaviour
{
    public CollectableManager CollectableManager;

    public UnityEvent OnCollectEvent;
    private CircleCollider2D collider2D;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnCollectEvent.Invoke();
            MoveToNextPoint();
        }
    }

    private void Awake()
    {
        collider2D = GetComponent<CircleCollider2D>();
    }

    private void MoveToNextPoint()
    {
        collider2D.enabled = false;

        LeanTween.move(gameObject, CollectableManager.transform.position + Random.insideUnitSphere * CollectableManager.CollectableMoveRange, 2f).setOnComplete(() =>
        {
            collider2D.enabled = true;
        }).setEaseOutQuint();
    }
}
