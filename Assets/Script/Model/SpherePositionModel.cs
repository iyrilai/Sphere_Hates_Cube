using UnityEngine;
using UnityEngine.Events;

public class SpherePositionModel
{
    public UnityAction<Vector3> OnTransformUpdate;

    public const float MAX_DRAG_RADIUS = 4.0f;

    public int queuePosition = 1;

    public Vector3 homeTransformPosition;
    public Vector3 updateTransformPosition;

    public bool isActive = false;
}