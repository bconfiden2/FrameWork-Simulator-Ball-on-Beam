using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManager : MonoBehaviour
{
    public Text[] texts = new Text[5];
    public float[] val = new float[6];

    public Positioner_Arms UpperArm;
    public Positioner_Arms LowerArm;
    public A_point RailJoint;
    public Rotater_RailPlate RailPlate;
    public E_point ServoSupporter;

    float p, q;         // T경첩 위치
    float sv_x, sv_y;   //  서보 위치
    public float degree_max;
    public float degree_min;
    public float degree = 0f;

    public Slider values;
    public Transform ball;
    public Text railDegree;


    // 처음 시작할 때 A,B,C,D,E 값 초기화 및 각종 값들 적용
    void Awake()
    {
        val[1] = 5;
        val[2] = 9;
        val[3] = 10;
        val[4] = 9;
        val[5] = 3.7f;

        RailJoint.SetPosition(val[1] + val[2]);

        Calculation();
    }

    // 매 프레임마다 레일과 어퍼암의 접합부가 위치할 좌표를 계산
    private void Update()
    {
        degree = 90 - values.value;

        float k = 50 - val[1] - val[2];
        float m = sv_x + val[4] * Mathf.Cos(Mathf.Deg2Rad * degree);
        float n = sv_y + val[4] * Mathf.Sin(Mathf.Deg2Rad * degree) * -1;

        float a = (p - m) / (n - q);
        float b = (- p * p - q * q + k * k + m * m + n * n - val[3] * val[3]) / (2 * n - 2 * q);

        float aa = (a * a + 1);
        float bb = -2 * (p - a * b + a * q);
        float cc = p * p + q * q + b * b - k * k - 2 * b * q;

        float x1 = (-1 * bb + Mathf.Sqrt(bb * bb - 4 * aa * cc)) / (2 * aa);
        float x2 = (-1 * bb - Mathf.Sqrt(bb * bb - 4 * aa * cc)) / (2 * aa);

        float y1 = a * x1 + b;
        float y2 = a * x2 + b;

        float x = 0f;
        float y = 0f;

        if (y1 > y2)
        {
            x = x1;
            y = y1;
        }
        else
        {
            x = x2;
            y = y2;
        }

        transform.position = new Vector3(x, y, transform.position.z);

        railDegree.text = (180 - Mathf.Round(Mathf.Rad2Deg * Mathf.Atan2(x - p, y - q))).ToString() + "도";
    }

    // 계산을 위한 서보의 위치와 T경첩의 위치를 갱신
    void Calculation()
    {
        p = RailPlate.transform.position.x;
        q = RailPlate.transform.position.y;
        sv_x = LowerArm.GetComponent<Positioner_Arms>().target_tr.transform.position.x;
        sv_y = LowerArm.GetComponent<Positioner_Arms>().target_tr.transform.position.y;
    }

    // 적용 버튼을 눌렀을 때 호출되는 함수. Apply 의 버튼 컴포넌트에 연결되어있음.
    public void ValueChanged()
    {
        // A,B,C,D,E 각각에 들어있는 값들을 확인해서
        for (int i = 0; i < 5; i++)
        {
            if (texts[i].text != "") val[i+1] = float.Parse(texts[i].text);
        }
        
        // 각각에 알맞게 위치 변경을 해준다.
        RailJoint.SetPosition(val[1] + val[2]); // 레일과 어퍼암의 접합부 위치 적용 (A)
        UpperArm.SetSize(val[3]);   // 어퍼암 길이 적용 (C)
        LowerArm.SetSize(val[4]);   // 로워암 길이 적용 (D)
        ServoSupporter.SetPosition(val[5]); // 서보 위치 적용 (E)
        Calculation();
        Reset_Ball();
    }
    
    // 종료 버튼을 눌렀을 때 실행되는 함수. Exit 버튼 컴포넌트에 이벤트가 연결되어 있음.
    public void Exit()
    {
        Application.Quit();
    }

    // 적용 버튼 누를 시 볼의 위치 초기화
    public void Reset_Ball()
    {
        ball.transform.position = new Vector3(-6.36f, 26.25f, 0.3f);
    }
}
