using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_point : MonoBehaviour
{
    public void SetPosition(float E)
    {
        transform.localPosition = new Vector3(13.49f - E, transform.localPosition.y, transform.localPosition.z);
    }
}
