using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDegree : MonoBehaviour
{
    Text tx;
    public Slider sd;

    private void Start()
    {
        tx = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        tx.text = Mathf.Round(sd.value).ToString() + "도";
    }
}
