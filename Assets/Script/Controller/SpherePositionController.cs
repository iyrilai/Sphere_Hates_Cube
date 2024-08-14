using UnityEngine;


public class SpherePositionController : MonoBehaviour
{
    public SpherePositionModel Model { private get; set; }
    SphereAttackController attackController;

    SphereAttackController AttackController
    {
        get
        {
            if (attackController == null)
                attackController = GetComponent<SphereAttackView>().Controller;

            return attackController;
        }
    }

#if UNITY_EDITOR
    [SerializeField] bool setActive;
#endif

    public void Init()
    {
        Model.homeTransformPosition = transform.position;

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
        Camera cam = Camera.main; //Change to Camera refeneces to improve performance

        var mousePos = Input.mousePosition;
        mousePos.z = Model.UpdateTransformPosition.z - cam.transform.position.z;
        mousePos = cam.ScreenToWorldPoint(mousePos);

        var distance = Vector3.Distance(Model.homeTransformPosition, mousePos);

        var maxPos = mousePos;
        if (distance > SpherePositionModel.MAX_DRAG_RADIUS)
        {
            Vector3 difference = mousePos - Model.homeTransformPosition;
            maxPos = Model.homeTransformPosition + difference.normalized * SpherePositionModel.MAX_DRAG_RADIUS;
        }

        maxPos.z = Model.homeTransformPosition.z;
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

        AttackController.OnDragExit();
    }
}
