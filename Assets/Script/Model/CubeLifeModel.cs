using UnityEngine.Events;

public class CubeLifeModel
{
    public UnityAction<bool> OnAliveUpdate;

    public float health = 4;
    bool isAlive = true;

    public float maxZPos;
    public float minZPos;

    public bool IsAlive
    {
        get
        {
            return isAlive;
        }
        set
        {
            isAlive = value;
            OnAliveUpdate.Invoke(isAlive);
        }
    }
}