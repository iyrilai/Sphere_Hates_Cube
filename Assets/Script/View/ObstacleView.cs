using UnityEngine;

[RequireComponent(typeof(ObstacleController))]
public class ObstacleView : MonoBehaviour
{
    [SerializeField] ObstacleType type;

    ObstacleModel model;

    private void Start()
    {
        model = new ObstacleModel();
        model.type = type;
        model.OnHealthUpdate += OnHealthUpdate;
        model.SetHealth();

        GetComponent<ObstacleController>().Model = model;
    }

    void OnHealthUpdate(float health)
    {
        if (!model.halfBroken && model.halfHealth > health)
        {
            Debug.Log($"{gameObject.name} is having half health. best for broken effects");
            model.halfBroken = true;
        }

        if (health <= 0)
            Destroy(gameObject);
    }
}