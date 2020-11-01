using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Railplate : MonoBehaviour
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
        my_tr.LookAt(target_tr.transform.position);
    }
}
