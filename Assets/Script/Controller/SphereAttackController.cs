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
        SetInitialVelocity(direction* SphereAttackModel.SPEED);
    }

    public void OnDragExit()
    {
        model.IsDragged = false;
    }

    public void SetInitialVelocity(Vector2 initialVelocity)
    {
        model.InitialVelocity = initialVelocity;
    }
}
