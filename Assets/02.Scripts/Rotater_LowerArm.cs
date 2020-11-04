using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotater_LowerArm : MonoBehaviour
{
    public Slider values;

    // 사용자가 조절하는 슬라이더 값을 받아와서 서보를 돌려줌. 실제로는 로워암을 돌려준다.
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f,0f, values.value - 180f);
    }
}
