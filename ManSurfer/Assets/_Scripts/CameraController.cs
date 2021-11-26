using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineVirtualCamera cam;
    void Awake()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
    }
    void LateUpdate()
    {
        if (cam.Follow == null || cam.LookAt == null)
        {
            Transform playerRoot = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<PlayerRoot>().transform;
            cam.Follow = playerRoot;
            cam.LookAt = playerRoot;
        }
    }

}