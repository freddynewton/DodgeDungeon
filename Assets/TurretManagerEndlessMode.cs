using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class TurretManagerEndlessMode : MonoBehaviour
{
    public float Offset;
    public int Phases;
    public int CollectObjectAmount;
    public GameObject TurretPF;
    public CollectableManager CollectableManager;

    private int currentPhase { get; set; }
    private int currentCollectedObjectAmount { get; set; }

    private List<GameObject> basicBulletTowers = new List<GameObject>();

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position + transform.right * Offset, 1);
    }

    public void IncreaseCollectObjectAmount(int amount)
    {
        currentCollectedObjectAmount += amount;

        if (currentCollectedObjectAmount >= CollectObjectAmount)
        {
            currentCollectedObjectAmount = 0;
            SetUpNewPhase();
            CollectableManager.EndlessModeCollectable.gameObject.SetActive(false);
        }
    }

    public void ResetCurrentObjectAmount()
    {
        // Reset Points
        currentCollectedObjectAmount = 0;

        // Disable Bullets
        BulletPoolManager.Instance.ReleaseAllBasicBullets();

        // Disable all turrets
        basicBulletTowers.ForEach(turret => turret.SetActive(false));
    }

    public void StartRound()
    {
        if (currentPhase == 0)
        {
            SetUpNewPhase();
        }
        else
        {
            basicBulletTowers.ForEach(turret => turret.SetActive(false));
            basicBulletTowers.ForEach(turret => RotateBulletTowers(turret));
        }
    }

    private void RotateBulletTowers(GameObject turret)
    {
        LeanTween.rotateZ(turret, Random.Range(-360f, 360f), 3f).setOnComplete(() =>
        {
            RotateBulletTowers(turret);
        });
    }

    private void SetUpNewPhase()
    {
        // Increase Phase amount
        currentPhase++;

        // Initialize new turret parent
        GameObject bulletParent = new GameObject("BulletTowerParent " + currentPhase);
        bulletParent.transform.parent = gameObject.transform;
        basicBulletTowers.Add(bulletParent);

        // Initialize new turret 
        GameObject turret = Instantiate(TurretPF, transform.position + transform.right * Offset, Quaternion.identity, bulletParent.transform);
        BasicBulletTower basicBulletTower = turret.GetComponent<BasicBulletTower>();
        basicBulletTower.isLookingAtPlayer = true;
        basicBulletTower.SetRandomBulletBehaviour();

        // RotateTowers
        foreach (GameObject turretParent in basicBulletTowers)
        {
            RotateBulletTowers(turretParent);
        }

        // Check win condition
        if (currentPhase >= Phases)
        {
            Debug.Log("You won");
        }
    }
}
