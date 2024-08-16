using UnityEngine;

public class SphereAttackController
{
    readonly SphereAttackModel model;

    public SphereAttackController(SphereAttackModel sphereAttackModel)
    {
        model = sphereAttackModel;
    }

    public void OnDrag(Vector3 direction)
    {
        model.IsDragged = true;
        model.initialVelocity = direction * SphereAttackModel.SPEED;
    }

    public void OnDragExit()
    {
        model.IsDragged = false;
    }
}
