using UnityEngine;


public class CameraView : MonoBehaviour
{
    CameraModel model;

    private void Start()
    {
        model = new();
        model.camera = GetComponent<Camera>();
    }

    private void Update()
    {
        //model.MaxCameraFollowX = new Vector3( model.MaxCameraFollowXOnZoomOut.x

        // Protect camera from existing limits

        // Z axis
        if (transform.position.z < model.MaxCameraFollowZ.x)
            transform.position = new(transform.position.x, transform.position.y, model.MaxCameraFollowZ.x);
        if (transform.position.z > model.MaxCameraFollowZ.y)
            transform.position = new(transform.position.x, transform.position.y, model.MaxCameraFollowZ.y);

        // Y axis
        // if (heightSize.x < model.MaxCameraFollowY.x)
        // transform.position = new(transform.position.x, model.MaxCameraFollowY.x, transform.position.z);
        //if (heightSize.y > model.MaxCameraFollowY.y)
        //   transform.position = new(transform.position.x, model.MaxCameraFollowY.y, transform.position.z);

        // X axis
        //if (widhtSize.x < model.MaxCameraFollowX.x)
        //   transform.position = new(model.MaxCameraFollowX.x, transform.position.y, transform.position.z);
        // if (widhtSize.y > model.MaxCameraFollowX.y)
        //   transform.position = new(model.MaxCameraFollowX.y, transform.position.y, transform.position.z);


    }

    // Does not worked. Time for plan B
    /*private void Update()
    {
        var camera = model.camera;
        var distance = Mathf.Abs(transform.position.z);

        var height = 2 * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        var widht = height * camera.aspect;

        height /= 2;

        Vector2 widhtSize = new Vector2(widht - transform.position.x, widht + transform.position.x);
        Vector2 heightSize = new Vector2(height - transform.position.y, height + transform.position.y);

        Debug.Log(heightSize);
        Debug.Log(widhtSize);
        // Protect camera from existing limits
        
        // Y axis
        if (heightSize.x < model.MaxCameraFollowY.x)
            transform.position = new(transform.position.x, model.MaxCameraFollowY.x, transform.position.z);
        if (heightSize.y > model.MaxCameraFollowY.y)
            transform.position = new(transform.position.x, model.MaxCameraFollowY.y, transform.position.z);
        
        return;
        // X axis
        if (widhtSize.x < model.MaxCameraFollowX.x)
            transform.position = new(model.MaxCameraFollowX.x, transform.position.y, transform.position.z);
        if (widhtSize.y > model.MaxCameraFollowX.y)
            transform.position = new(model.MaxCameraFollowX.y, transform.position.y, transform.position.z);

        // Z axis
        if (transform.position.z < model.MaxCameraFollowZ.x)
            transform.position = new(transform.position.x, transform.position.y, model.MaxCameraFollowZ.x);
        if (transform.position.z > model.MaxCameraFollowZ.y)
            transform.position = new(transform.position.x, transform.position.y, model.MaxCameraFollowZ.y);

    }*/
}