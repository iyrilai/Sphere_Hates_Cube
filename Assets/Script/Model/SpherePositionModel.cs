using UnityEngine;
using UnityEngine.Events;

public class SpherePositionModel
{
    public UnityAction<Vector3> OnTransformUpdate;

    public const float MAX_DRAG_RADIUS = 2.0f;

    public int queuePosition = 1;

    public Vector3 homeTransformPosition;
    Vector3 updateTransformPosition;

    public bool isActive = false;

    public Vector3 UpdateTransformPosition
    {
        get
        {
            return updateTransformPosition;
        }

        set
        {
            updateTransformPosition = value;
            OnTransformUpdate.Invoke(updateTransformPosition);
        }
    }
}