using UnityEngine;

public class SphereAttackController
{
    readonly SphereAttackModel model;

    public SphereAttackController(SphereAttackModel sphereAttackModel)
    {
        model = sphereAttackModel;
    }

    public void OnDrag(Vector3 start, Vector3 current)
    {
        model.IsDragged = true;

        /*
         * Calculate the initial velocity and modify model.initialVelocity value
         */

        Debug.Log(start + " " + current);
    }

    public void OnDragExit()
    {
        model.IsDragged = false;
    }
}
