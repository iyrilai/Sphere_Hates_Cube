using UnityEngine;

public class SphereAttackController
{
    SphereAttackModel sphereAttackModel;

    public SphereAttackController(SphereAttackModel sphereAttackModel)
    {
        this.sphereAttackModel = sphereAttackModel;
    }

    public void OnDrag(Vector3 start, Vector3 current)
    {
        Debug.Log(start + " " + current);
    }

    public void OnDragExit()
    {
        Debug.Log("Exit");
    }
}
