using System.Collections;
using UnityEngine;

[RequireComponent(typeof(SphereLifeView))]
public class SphereLifeController : MonoBehaviour
{
    readonly WaitForSeconds waitFor10Sec = new(10);
    SphereLifeModel model;

    public void Init(SphereLifeModel model)
    {
        this.model = model;
    }

    public void IsUsed()
    {
        model.isUsed = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (model is null || !model.isUsed)
            return;

        StartCoroutine(EndLifeCoroutine());
    }

    IEnumerator EndLifeCoroutine()
    {
        yield return waitFor10Sec;
        model.Destroy = true;
    }
}
