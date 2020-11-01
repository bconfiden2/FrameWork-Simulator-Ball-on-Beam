using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LowerArmRotate : MonoBehaviour
{
    public Slider values;

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f,0f, values.value - 180f);
    }
}
