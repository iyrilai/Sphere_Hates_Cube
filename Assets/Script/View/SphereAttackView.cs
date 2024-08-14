using UnityEngine;

public class SphereAttackView : MonoBehaviour
{
    SphereAttackModel model;
    Rigidbody rb;
    
    public SphereAttackController Controller { get; private set; }

    private void Start()
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

        rb.velocity = model.initialVelocity;
        rb.useGravity = true;

        Debug.Log($"Sphere is to be set {model.initialVelocity} as initial velocity");
    }
}
