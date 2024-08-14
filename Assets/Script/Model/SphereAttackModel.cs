using UnityEngine;
using UnityEngine.Events;

public class SphereAttackModel
{
    public UnityAction<bool> IsDraggedChanged;

    public Vector2 initialVelocity = Vector2.zero;
    public bool isDragged = false;
}
