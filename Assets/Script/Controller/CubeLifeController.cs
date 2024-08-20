using UnityEngine;

[RequireComponent(typeof(CubeLifeView))]
public class CubeLifeController : MonoBehaviour
{
    public CubeLifeModel Model { private get; set; }


    private void Update()
    {
        if (transform.position.z > Model.maxZPos || transform.position.z < Model.minZPos)
            Kill();
    }

    private void OnCollisionEnter(Collision collision)
    {
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
