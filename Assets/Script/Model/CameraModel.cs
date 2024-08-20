using UnityEngine;

public class CameraModel
{
    public const float RESET_TIME = 3f;
    public const float CAMERA_MOVE_SPEED = 3f;

    public readonly Vector2 MaxCameraFollowXOnZoomOut = new(3.5f, 20.5f);
    public readonly Vector2 MaxCameraFollowYOnZoomOut = new(4.5f, 9.5f);
    public readonly Vector2 MaxCameraFollowZOnZoomOut = new(-25, -5);

    public Vector2 MaxCameraFollowX = new(3.5f, 20.5f);
    public Vector2 MaxCameraFollowY = new(4.5f, 9.5f);
    public Vector2 MaxCameraFollowZ = new(-25, -5);

    public Camera camera;

    public Transform currentSphere;
    public Transform oldSphere;

    private bool follow;
    private bool isSphereOnMovement;

    public bool IsSphereOnMovement 
    {
        get
        {
            return isSphereOnMovement;
        }
        set
        {
            isSphereOnMovement = value;
        }
    }

    public bool Follow
    {
        get
        {
            return follow;
        }
        set
        {
            follow = value;
        }
    }
}