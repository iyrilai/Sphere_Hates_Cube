using UnityEngine;

public class SpherePositionView : MonoBehaviour
{
    SpherePositionModel model;

    private void Awake()
    {
        model = new SpherePositionModel();
        
        var controller = GetComponent<SpherePositionController>();
        controller.Model = model;
        controller.Init();

        model.OnTransformUpdate += OnTransformUpdate;
    }

    void OnTransformUpdate(Vector3 position)
    {
        transform.position = position;
    }
}

