using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMove: MonoBehaviour
{

    public float radius = 2f;
    public float speed = 2f;
    private float angle = 0f;


    void Start()
    {

    }


    private void Update()
    {

        angle += speed * Time.deltaTime;


        float x = Mathf.Sin(angle) * radius;
        float y = Mathf.Cos(angle) * radius;


        transform.position = new Vector3(x, y, 0f);
    }
}