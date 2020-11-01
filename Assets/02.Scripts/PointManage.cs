using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointManage : MonoBehaviour
{
    public Text[] texts = new Text[5];
    public float[] val = new float[6];
    public PositionChecker UpperArm;
    public PositionChecker LowerArm;
    public A_point RailJoint;
    public Railplate RailPlate;
    public E_point ServoSupporter;

    float p, q;         // T경첩 위치
    float sv_x, sv_y;   //  서보 위치
    public float degree_max;
    public float degree_min;
    public float degree = 0f;

    public Slider values;

    public Transform tmtest;

    // Start is called before the first frame update
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

    private void Update()
    {
        degree = 90 - values.value;

        float k = 50 - val[1] - val[2];
        float m = sv_x + val[4] * Mathf.Cos(Mathf.Deg2Rad * degree);
        float n = sv_y + val[4] * Mathf.Sin(Mathf.Deg2Rad * degree) * -1;

        tmtest.position = new Vector3(m, n, transform.position.z);

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
    }

    void Calculation()
    {
        p = RailPlate.transform.position.x;
        q = RailPlate.transform.position.y;
        sv_x = LowerArm.GetComponent<PositionChecker>().target_tr.transform.position.x;
        sv_y = LowerArm.GetComponent<PositionChecker>().target_tr.transform.position.y;
    }

    public void ValueChanged()
    {
        for (int i = 0; i < 5; i++)
        {
            if (texts[i].text != "") val[i+1] = float.Parse(texts[i].text);
        }
        
        RailJoint.SetPosition(val[1] + val[2]);
        UpperArm.SetSize(val[3]);
        LowerArm.SetSize(val[4]);
        ServoSupporter.SetPosition(val[5]);

        Calculation();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
