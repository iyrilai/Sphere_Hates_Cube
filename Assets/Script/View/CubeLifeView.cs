using UnityEngine;

[RequireComponent(typeof(CubeLifeController))]
public class CubeLifeView : MonoBehaviour
{
    CubeLifeModel model;

    private void Start()
    {
        model = new CubeLifeModel();
        model.OnAliveUpdate += OnAliveUpdate;

        model.maxZPos = transform.position.z + 0.5f;
        model.minZPos = transform.position.z - 0.5f;

        GetComponent<CubeLifeController>().Model = model;
    }

    void OnAliveUpdate(bool alive)
    {
        if (alive)
            return;

        Destroy(gameObject);
    }
}