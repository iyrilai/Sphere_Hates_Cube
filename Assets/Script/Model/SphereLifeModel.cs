
using UnityEngine.Events;

public class SphereLifeModel
{
    public UnityAction<bool> IsDestroyChanged;

    public bool isUsed = false;
    bool destroy = false; 

    public bool Destroy
    {
        get
        {
            return destroy;
        }

        set
        {
            destroy = value;
            IsDestroyChanged.Invoke(destroy);
        }
    }
}