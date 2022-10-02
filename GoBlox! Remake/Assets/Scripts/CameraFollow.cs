using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [HideInInspector]
    private float currentBox;
    public float totalBox;

    public void CameraGoUp()
    {
        if (totalBox > currentBox)
        {
            Vector3 temp = transform.position;
            temp.y += 0.5f;
            transform.position = temp;
            totalBox = currentBox;
        }
    }
}
