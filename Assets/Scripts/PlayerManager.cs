using UnityEngine;

/// <summary>
/// A Singleton which manage the Stats from the current Player model.
/// </summary>
public class PlayerManager : Singleton<PlayerManager>
{
    [Header("Player values")]
    public float BaseMovementSpeed = 20;
    private float m_movementSpeed;

    public int BaseHealthPoints = 3;
    private int m_healthPoints;

    public int BaseStaminaPoints = 3;
    private int m_staminaPoints;

    [Header("Dash")]
    public float BaseDashSpeed;
    public float DashTime;

    private GameObject m_playerCharacter;
    [HideInInspector]
    public GameObject PlayerCharacter
    {
        get
        {
            if (m_playerCharacter == null)
            {
                m_playerCharacter = GameObject.FindGameObjectWithTag("Player");

                return m_playerCharacter;
            }
            else
            {
                return m_playerCharacter;
            }
        }
    }

    /// <summary>
    /// This will reduce the Healthamount by the amount
    /// </summary>
    /// <param name="amount">The amount that will reduce the health points</param>
    public void OnHealthPointsReduced(int amount = 1)
    {
        m_healthPoints -= amount;

        if (m_healthPoints == 0)
        {
            Debug.Log("Player is dead");
        }
    }

    public void ResetPoints()
    {
        m_movementSpeed = BaseMovementSpeed;
        m_healthPoints = BaseHealthPoints;
        m_staminaPoints = BaseStaminaPoints;
    }

    private void Start()
    {
        ResetPoints();
    }
}
