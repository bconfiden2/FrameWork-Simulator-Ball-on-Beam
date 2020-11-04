using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_point : MonoBehaviour
{
    // 적용 버튼이 눌려질 때 PointManager 에서 호출. A + B 의 값을 받아 레일과 어퍼암의 접합부 위치를 적용.
    public void SetPosition(float Z)
    {
        transform.localPosition = new Vector3(0f, 0f, 50.0f - Z);
    }
}
