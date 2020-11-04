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

    // 사용자가 조절하는 슬라이더 값을 받아와서 UI 로 표시.
    void Update()
    {
        tx.text = Mathf.Round(sd.value).ToString() + "도";
    }
}
