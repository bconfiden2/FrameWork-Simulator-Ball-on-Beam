using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_point : MonoBehaviour
{
    public void SetPosition(float Z)
    {
        GetComponent<Transform>().localPosition = new Vector3(0f, 0f, 50.0f - Z);
    }
}
