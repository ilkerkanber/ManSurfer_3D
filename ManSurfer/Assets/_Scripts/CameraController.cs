using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float distanceY, distanceZ;
    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }
    }
    void LateUpdate()
    {
        if (target != null)
        {
            WatchTarget();
        }
    }
    void WatchTarget()
    {
        transform.position = new Vector3(0, distanceY, target.transform.position.z+distanceZ);
    }
}