using UnityEngine;

public class SphereAttackView : MonoBehaviour
{
    SphereAttackModel model;
    public SphereAttackController Controller { get; private set; }

    private void Start()
    {
        model = new();
        Controller = new(model);
    }

    void IsHoldChanged()
    {

    }
}
