using UnityEngine;

[System.Serializable]
public class UnitMovementBehaviourContainer
{
    [Range(0, 2)] public float weight;
    public UnitMovementBehaviour unitMovementBehaviour;
}
