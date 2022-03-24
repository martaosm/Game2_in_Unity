using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public Vector3[] point;
    void Start()
    {

        point[1] = point[0] + (point[2] - point[0]) / 2 + Vector3.up * 5.0f;
    }

    
    void Update()
    {
        float count = 0.0f;
        if (count < 1.0f) {
            count += 1.0f *Time.deltaTime;
     
            Vector3 m1 = Vector3.Lerp( point[0], point[1], count );
            Vector3 m2 = Vector3.Lerp( point[1], point[2], count );
            transform.position = Vector3.Lerp(m1, m2, count);
        }
        /*Vector3 point = new Vector3(1,0,0);
        Vector3 axis = new Vector3(0,0,1);
        transform.RotateAround(point, axis, Time.deltaTime * 10);*/
    }
}
