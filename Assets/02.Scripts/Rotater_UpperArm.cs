using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater_UpperArm : MonoBehaviour
{
    public Transform target_tr;

    // 어퍼암이 PointManager 에서 매 프레임 구하는 최종 위치값을 향하도록 각도를 조절.
    void Update()
    {
        transform.eulerAngles = new Vector3(0f, 0f, -Mathf.Rad2Deg * Mathf.Atan2(target_tr.position.x - transform.position.x, target_tr.position.y - transform.position.y));
    }
}
