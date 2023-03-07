using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject GameObject;

    [Range(0,1)]
    public float test;

    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;
    public Vector3 P4;

    private void Update()
    {
        GameObject.transform.position = BezierTest(P1, P2, P3, P4, test);
    }
    public Vector3 BezierTest(
        Vector3 P_1,
        Vector3 P_2,
        Vector3 P_3,
        Vector3 P_4,
        float Value)
    {
        Vector3 A = Vector3.Lerp(P_1, P_2, Value);
        Vector3 B = Vector3.Lerp(P_2, P_3, Value);
        Vector3 C = Vector3.Lerp(P_3, P_4, Value);

        Vector3 D = Vector3.Lerp(A, B, Value);
        Vector3 E = Vector3.Lerp(B, C, Value);

        Vector3 F = Vector3.Lerp(D, E, Value);

        return F;
    }
}
