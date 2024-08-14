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

    public void UpdateQueuePosition(int queuePos, Vector3 position)
    {
        if (queuePos == 0)
            SetActive();

        Model.queuePosition = queuePos;
        Model.UpdateTransformPosition = position;
        Model.homeTransformPosition = position;
    }

    void SetActive()
    {
        Model.isActive = true;
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
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
             Model.UpdateTransformPosition.z - cam.transform.position.z));
        float distance = Vector3.Distance(Model.homeTransformPosition, mousePos);

        Vector3 maxPos = mousePos;

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
