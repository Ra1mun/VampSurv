using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private bool isInsideCam;
    public bool IsInsideCam => isInsideCam;
    void Start()
    {
        

    }

    void Update()
    {
        Camera cam = Camera.main;
        Vector3 pos = cam.WorldToViewportPoint(transform.position);
        if (pos.x >= 0 && pos.y >= 0 && pos.x <= 1 && pos.y <= 1)
            isInsideCam = true;
        else
            isInsideCam = false;
    }
}
