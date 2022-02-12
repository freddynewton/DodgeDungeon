using Cysharp.Threading.Tasks;
using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] private int spikeTimeMS = 2500;
    [SerializeField] private Animator animator;
    [SerializeField] private BoxCollider2D boxCollider2D;

    [Space]
    [Header("AnimatorTime")]
    [SerializeField] private int ActivateTriggerBoxTimer;
    [SerializeField] private int DeactivateTriggerBoxTimer;

    private void Awake()
    {
        boxCollider2D.enabled = false;

        ActivateTrap();
    }

    public void ActivateTrap()
    {
        animator.SetTrigger("Activate");
    }

    public void SetBoxCollider(int active)
    {
        boxCollider2D.enabled = active == 0 ? false : true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.OnHealthPointsReduced();
        }
    }
}
