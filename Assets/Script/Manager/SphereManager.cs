using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] GameObject spherePrefabs;

    WaitForSeconds waitFor3Sec = new(3);

    readonly List<SpherePositionController> spherePositions = new();


    public static SphereManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        SpawnSphere();
    }

    void SpawnSphere()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            var controller = Instantiate(spherePrefabs, child).GetComponent<SpherePositionController>();
            
            controller.UpdateQueuePosition(i == 0, child.position);
            spherePositions.Add(controller);
        }
    }

    public void RemoveSphere()
    {
        StartCoroutine(RemoveSphereCoroutines());
    }


    IEnumerator RemoveSphereCoroutines()
    {
        yield return waitFor3Sec;
        
        if (spherePositions.Count <= 0)
            yield break;

        var attackingSphere = spherePositions[0];
        attackingSphere.transform.parent = null;
        spherePositions.RemoveAt(0);

        RearangeSphere();
    }
    

    void RearangeSphere()
    {
        for (int i = 0; i < spherePositions.Count; i++)
        {
            var child = transform.GetChild(i);
            var controller = spherePositions[i];

            controller.transform.parent = child;
            controller.UpdateQueuePosition(i == 0, child.position);
        }
    }
}