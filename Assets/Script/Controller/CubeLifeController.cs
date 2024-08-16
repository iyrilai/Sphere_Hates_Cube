using UnityEngine;

[RequireComponent (typeof(CubeLifeView))]
public class CubeLifeController : MonoBehaviour
{
    public CubeLifeModel Model { private get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"{gameObject.name} to {collision.gameObject.name} - {collision.relativeVelocity.magnitude}");
        SetDamage(collision.relativeVelocity.magnitude);
    }

    void SetDamage(float damage)
    {
        Model.health -= damage;

        if (Model.health < 0)
            Kill();
    }

    void Kill()
    {
        Model.IsAlive = false;
    }
}
