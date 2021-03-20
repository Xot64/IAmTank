using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_MF : MonoBehaviour
{
    public static float toRotation(float begin, float end)
    {
        begin %= 360;
        end %= 360;
        begin += begin< 0? 360 : 0;
        end += (end< 0 || end < begin) ? 360 : 0;
        return end - begin - (end - begin <= 180 ? 0 : 360);
    }

    public static float round(float v, byte d = 0)
    {
        return Mathf.Floor(v* Mathf.Pow(10,d) +0.5f)/ Mathf.Pow(10, d);
    }
    public static float R2G (float rad)
    {
        return rad / Mathf.PI * 180.0f;
    }
    public static float G2R(float grad)
    {
        return grad * Mathf.PI / 180.0f;
    }
}
