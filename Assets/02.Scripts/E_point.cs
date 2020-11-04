using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_point : MonoBehaviour
{
    // 적용 버튼이 눌려질 때 PointManager 에서 호출. E 값을 받아서 맞는 위치로 변경
    public void SetPosition(float E)
    {
        transform.localPosition = new Vector3(13.49f - E, transform.localPosition.y, transform.localPosition.z);
    }
}
