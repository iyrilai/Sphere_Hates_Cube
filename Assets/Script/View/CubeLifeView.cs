using UnityEngine;

[RequireComponent(typeof(CubeLifeController))]
public class CubeLifeView : MonoBehaviour
{
    CubeLifeModel model;

    private void Start()
    {
        model = new CubeLifeModel();
        model.OnAliveUpdate += OnAliveUpdate;

        GetComponent<CubeLifeController>().Model = model;
    }

    void OnAliveUpdate(bool alive)
    {
        if (alive)
            return;

        Destroy(gameObject);
    }
}