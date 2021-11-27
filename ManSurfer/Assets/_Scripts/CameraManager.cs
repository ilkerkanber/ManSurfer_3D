using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] List<CinemachineVirtualCamera> virtualCams;
    GameObject target;
    Bag targetBag;
    Transform body, root;

    void OnEnable()
    {
        GameManager.OnWin += WinCameraMod;    
        GameManager.OnGameOver+= LoseCameraMod;
    }
    void OnDisable()
    {
        GameManager.OnWin -= WinCameraMod;
        GameManager.OnGameOver-= LoseCameraMod;
    }
    void Update()
    {
        FindTarget();
        UseControl();
    }
    void UseControl()
    {
        if (target && !GameManager.Instance.IsFinished)
        {
            if (targetBag.bag.Count < 5)
            {
                NearCameraMod();
            }
            else
            {
                FarCameraMod();
            }
        }
    }
    void FindTarget()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player");
            root = target.GetComponentInChildren<PlayerRoot>().transform;
            body = target.GetComponentInChildren<Body>().transform;
            targetBag = target.GetComponentInChildren<Bag>();
        }
    }
    void NearCameraMod()
    {
        SetupCamera(0, root);
        SetActiveCamera(0);
    }
    void FarCameraMod()
    {
        SetupCamera(1, root);
        SetActiveCamera(1);
    }
    void WinCameraMod()
    {
        SetupCamera(2, body);
        SetActiveCamera(2);
    }
    void LoseCameraMod()
    {
        SetupCamera(3, body);
        SetActiveCamera(3);
    }
    void SetupCamera(int i, Transform targetTransform)
    {
        virtualCams[i].Follow = targetTransform;
        virtualCams[i].LookAt = targetTransform;
    }
    void SetActiveCamera(int index)
    {
        for (int i= 0; i < virtualCams.Count; i++)
        {
            virtualCams[i].Priority = 1;
        }
        virtualCams[index].Priority = 2;
    }

}
