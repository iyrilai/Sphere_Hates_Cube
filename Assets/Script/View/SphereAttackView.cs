using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SphereAttackView : MonoBehaviour
{
    SphereAttackModel model;
    Rigidbody rb;
    
    public SphereAttackController Controller { get; private set; }

    private void Awake()
    {
        model = new();
        Controller = new(model);

        rb = GetComponent<Rigidbody>();

        model.IsDraggedChanged += IsDraggedChanged;
    }

    void IsDraggedChanged(bool isDragged)
    {
        if (isDragged)
            return;

        rb.velocity = model.InitialVelocity;
        rb.useGravity = true;

        Debug.Log($"The sphere's initial velocity is set to {model.InitialVelocity}.");
    }
}
