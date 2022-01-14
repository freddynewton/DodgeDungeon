using UnityEngine;

public class PlayerManager : Singleton<PlayerManager>
{
    [Header("Player values")]
    public float BaseMovementSpeed = 20;
    public int BaseHealthPoints = 3;
    public int BaseStaminaPoints = 3;
}
