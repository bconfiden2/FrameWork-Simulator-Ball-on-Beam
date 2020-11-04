using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Positioner_Arms : MonoBehaviour
{
    public Transform target_tr;

    // 로워암은 서보의 위치를 따라가고, 어퍼암은 로워암과의 접합부 위치를 따라간다.
    void Update()
    {
        transform.position = target_tr.transform.position;
    }

    // 사용자가 적용 버튼을 누를 때 마다 PointManager 에서 호출. 로워암과 어퍼암의 사이즈를 받아서 적용한다.
    public void SetSize(float Y)
    {
        transform.localScale = new Vector3(0.3f, Y, 0.1f);
    }
}
