
using UnityEngine.Events;

public class ObstacleModel
{
    public UnityAction<float> OnHealthUpdate;

    public ObstacleType type;
    public float halfHealth;
    public bool halfBroken;

    private float health;

    public float Health 
    { 
        get => health; 
        set
        {
            health = value;
            OnHealthUpdate.Invoke(health);
        }
    }

    public void SetHealth()
    {
        // balance this
        health = type switch
        {
            ObstacleType.Wood => 50,
            ObstacleType.Glass => 35,
            ObstacleType.Stone => 100,
            _ => throw new System.NotImplementedException()
        };

        halfHealth = health / 2;
    }
}
