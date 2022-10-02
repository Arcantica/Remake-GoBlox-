using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject box_Prefab;

    public void SpawnBox()
    {
        GameObject box_Object = Instantiate(box_Prefab);
        Vector3 temp = transform.position;
        temp.z = 0f;
        box_Object.transform.position = temp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
