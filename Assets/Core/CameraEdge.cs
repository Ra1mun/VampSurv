using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEdge : MonoBehaviour
{
    [SerializeField]
      private float distance;

      private void OnDrawGizmosSelected()
      {
          var camera = Camera.main;
          Vector3 p1 = camera.ScreenToWorldPoint(new Vector3 (0f, 0f, distance));
          Vector3 p2 = camera.ScreenToWorldPoint(new Vector3(0f, camera.pixelHeight, distance));
          Vector3 p3 = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, camera.pixelHeight, distance));
          Vector3 p4 = camera.ScreenToWorldPoint(new Vector3(camera.pixelWidth, 0f, distance));
          Gizmos.color = Color.red;
          Gizmos.DrawLine(p1, p2);
          Gizmos.DrawLine(p2, p3);
          Gizmos.DrawLine(p3, p4);
          Gizmos.DrawLine(p4, p1);
      }
}
