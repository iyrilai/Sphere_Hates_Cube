using UnityEngine;

public class SphereAttackController
{
    readonly SphereAttackModel model;

    public SphereAttackController(SphereAttackModel sphereAttackModel)
    {
        model = sphereAttackModel;
    }

    public void OnDrag(Vector3 home, Vector3 current)
    {
        model.IsDragged = true;

        Vector3 difference = home - current;
        model.initialVelocity = difference * SphereAttackModel.SPEED;
    }

    public void OnDragExit()
    {
        model.IsDragged = false;
    }
}
