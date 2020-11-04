using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater_RailPlate : MonoBehaviour
{
    public Transform target_tr;

   // 레일플레이트가 A_point (접합부) 를 향하도록 각도를 갱신.
    void Update()
    {
        transform.LookAt(target_tr.transform.position);
    }
}
