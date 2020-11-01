using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateChecker : MonoBehaviour
{
    public Transform target_tr;
    Transform my_tr;

    // Start is called before the first frame update
    void Start()
    {
        my_tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        my_tr.transform.eulerAngles = new Vector3(0f, 0f, -Mathf.Rad2Deg * Mathf.Atan2(target_tr.position.x - my_tr.position.x, target_tr.position.y - my_tr.position.y));
    }
}
