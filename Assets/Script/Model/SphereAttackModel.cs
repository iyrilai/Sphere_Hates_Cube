using UnityEngine;
using UnityEngine.Events;

public class SphereAttackModel
{
    public UnityAction<bool> IsDraggedChanged;

    public const float SPEED = 5.0f;

    public Vector2 initialVelocity = Vector2.zero;
    bool isDragged = false;

    public bool IsDragged
    {
        get
        {
            return isDragged;
        }

        set
        {
            isDragged = value;
            IsDraggedChanged.Invoke(isDragged);
        }
    }
}
