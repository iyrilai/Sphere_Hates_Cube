using UnityEngine;

[RequireComponent(typeof(SphereLifeController))]
public class SphereLifeView : MonoBehaviour
{
    SphereLifeModel sphereLifeModel;

    private void Awake()
    {
        sphereLifeModel = new SphereLifeModel();
        GetComponent<SphereLifeController>().Init(sphereLifeModel);
        sphereLifeModel.IsDestroyChanged += IsDestroyChanged;
    }

    private void IsDestroyChanged(bool destory)
    {
        if (!destory)
            return;

        Destroy(gameObject);
    }
}