using UnityEngine;


public class SpherePositionController : MonoBehaviour
{
    SpherePositionModel spherePositionModel;
    SphereAttackController attackController;

#if UNITY_EDITOR
    [SerializeField] bool setActive;
#endif

    private void Start()
    {
        spherePositionModel = new SpherePositionModel();
        GetComponent<SpherePositionView>().SpherePositionModel = spherePositionModel;

        attackController = GetComponent<SphereAttackView>().Controller;
        spherePositionModel.homeTransformPosition = transform.position;

#if UNITY_EDITOR
        spherePositionModel.isActive = setActive;
#endif
    }

    public void UpdateQueuePosition(int queuePos, Vector3 position)
    {
        if (queuePos == 0)
            SetActive();

        spherePositionModel.queuePosition = queuePos;
        spherePositionModel.updateTransformPosition = position;
        spherePositionModel.homeTransformPosition = position;
    }

    void SetActive()
    {
        spherePositionModel.isActive = true;
    }

    private void OnMouseUp()
    {
        if (!spherePositionModel.isActive)
            return;

        OnDragExit();
    }

    private void OnMouseDrag()
    {
        if (!spherePositionModel.isActive)
            return;

        OnDrag();
    }

    void OnDrag()
    {
        Camera cam = Camera.main;
        Vector3 mousePos = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
             spherePositionModel.updateTransformPosition.z - cam.transform.position.z));
        float distance = Vector3.Distance(spherePositionModel.homeTransformPosition, mousePos);

        Vector3 maxPos = mousePos;

        if (distance > SpherePositionModel.MAX_DRAG_RADIUS)
        {
            Vector3 difference = mousePos - spherePositionModel.homeTransformPosition;
            maxPos = spherePositionModel.homeTransformPosition + difference.normalized * SpherePositionModel.MAX_DRAG_RADIUS;
        }

        spherePositionModel.updateTransformPosition = maxPos;
        attackController.OnDrag(spherePositionModel.homeTransformPosition, spherePositionModel.updateTransformPosition);
    }

    public void OnDragExit()
    {
        float distance = Vector3.Distance(spherePositionModel.homeTransformPosition, spherePositionModel.updateTransformPosition);
        
        if(distance > 0.1f)
        {
            spherePositionModel.updateTransformPosition = spherePositionModel.homeTransformPosition;
            return;
        }

        attackController.OnDragExit();
    }
}
