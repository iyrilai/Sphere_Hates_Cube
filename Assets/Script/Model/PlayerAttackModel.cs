using UnityEngine;
using UnityEngine.Events;

public class PlayerAttackModel
{
    public UnityAction<bool> OnHoldChanged;
    public UnityAction SetActive;

    public float elastic = 0.0f;
    public Vector2 initialVelocity = Vector2.zero;
    public bool isHold = false;
    public bool isActive = false;
}
