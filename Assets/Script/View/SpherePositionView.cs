using UnityEngine;

public class SpherePositionView : MonoBehaviour
{
    SpherePositionModel model;

    private void Start()
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

