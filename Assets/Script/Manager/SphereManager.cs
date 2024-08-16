using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SphereManager : MonoBehaviour
{
    [SerializeField] GameObject spherePrefabs;

    readonly WaitForSeconds waitFor2Sec = new(2);
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
            
            controller.UpdatePosition(i == 0, child.position);
            spherePositions.Add(controller);
        }
    }

    public void RemoveSphere()
    {
        StartCoroutine(RemoveSphereCoroutines());
    }


    IEnumerator RemoveSphereCoroutines()
    {
        yield return waitFor2Sec;
        
        if (spherePositions.Count <= 0)
            yield break;

        var attackingSphere = spherePositions[0];
        attackingSphere.transform.parent = null;
        spherePositions.RemoveAt(0);

        RearrangeSphere();
    }
    

    void RearrangeSphere()
    {
        for (int i = 0; i < spherePositions.Count; i++)
        {
            var child = transform.GetChild(i);
            var controller = spherePositions[i];

            controller.transform.parent = child;
            controller.UpdatePosition(i == 0, child.position);
        }
    }
}