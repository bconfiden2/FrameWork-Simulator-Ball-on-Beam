using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChecker : MonoBehaviour
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
        my_tr.transform.position = target_tr.transform.position;
    }

    public void SetSize(float Y)
    {
        my_tr.localScale = new Vector3(0.3f, Y, 0.1f);
    }
}
