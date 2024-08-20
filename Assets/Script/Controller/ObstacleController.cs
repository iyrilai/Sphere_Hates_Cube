using UnityEngine;

[RequireComponent(typeof(ObstacleView))]
public class ObstacleController : MonoBehaviour
{
    public ObstacleModel Model { private get; set; }

    private void OnCollisionEnter(Collision collision)
    {
        SetDamageBasedOnSphere(collision.relativeVelocity.magnitude, SphereType.Red);
    }

    void SetDamageBasedOnSphere(float damage, SphereType sphereType)
    {
        if (sphereType == SphereType.Yellow && Model.type == ObstacleType.Wood)
            damage += 35; // balance this

        if (sphereType == SphereType.Blue && Model.type == ObstacleType.Glass)
            damage += 20; // balance this

        if (sphereType == SphereType.Black && Model.type == ObstacleType.Stone)
            damage += 70; // balance this

        SetDamage(damage);
    }

    void SetDamage(float damage)
    {
        Model.Health -= damage;
    }
}
