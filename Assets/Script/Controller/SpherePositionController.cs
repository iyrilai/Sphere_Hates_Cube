using UnityEngine;


public class SpherePositionController : MonoBehaviour
{
    public SpherePositionModel Model { private get; set; }
    SphereAttackController attackController;
    Camera mainCamera;

    SphereAttackController AttackController
    {
        get
        {
            if (attackController == null)
                attackController = GetComponent<SphereAttackView>().Controller;

            return attackController;
        }
    }

    // for debugging
#if UNITY_EDITOR
    [SerializeField] bool setActive;
#endif

    public void Init()
    {
        Model.homeTransformPosition = transform.position;
        mainCamera = Camera.main;

        // for debugging
#if UNITY_EDITOR
        Model.isActive = setActive;
#endif
    }

    public void UpdateQueuePosition(bool isActive, Vector3 position)
    {
        Model.isActive = isActive;

        Model.UpdateTransformPosition = position;
        Model.homeTransformPosition = position;
    }

    private void OnMouseUp()
    {
        if (!Model.isActive)
            return;

        OnDragExit();
    }

    private void OnMouseDrag()
    {
        if (!Model.isActive)
            return;

        OnDrag();
    }

    void OnDrag()
    {
        Camera cam = mainCamera;

        //Mouse position based on current transform z value
        var mousePos = Input.mousePosition;
        mousePos.z = Model.UpdateTransformPosition.z - cam.transform.position.z;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        // Used values calculation
        var distance = Vector3.Distance(Model.homeTransformPosition, mousePos);
        var difference = mousePos - Model.homeTransformPosition;

        // Ajust sphere to move around radius 
        var maxPos = mousePos;
        if (distance > SpherePositionModel.MAX_DRAG_RADIUS)
            maxPos = Model.homeTransformPosition + difference.normalized * SpherePositionModel.MAX_DRAG_RADIUS;

        maxPos.z = Model.homeTransformPosition.z;

        // Angle calulation to avoid collision between sphere and stick
        var angle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (angle > -116 && angle < -73 && distance > 1.5f) 
            return;

        Model.UpdateTransformPosition = maxPos;
        AttackController.OnDrag(Model.homeTransformPosition, Model.UpdateTransformPosition);
    }

    public void OnDragExit()
    {
        float distance = Vector3.Distance(Model.homeTransformPosition, Model.UpdateTransformPosition);

        if (distance < 0.1f)
        {
            Model.UpdateTransformPosition = Model.homeTransformPosition;
            return;
        }

        Model.isActive = false;
        SphereManager.Instance.RemoveSphere();
        AttackController.OnDragExit();
    }
}
