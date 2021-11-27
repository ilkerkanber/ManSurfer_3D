using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector: MonoBehaviour
{
    Bag _bag;
    float bugTimer,stayTimer;

    void Awake()
    {
        _bag = GetComponentInChildren<Bag>();
    }
    void OnTriggerEnter(Collider collider) 
    {
        if (Time.time < bugTimer + 0.2f)
        {
            return;
        }
        switch (collider.tag)
        {
            case "FinishLine":
                GameManager.Instance.Win();
                break;
        }

        if (collider.transform.parent != null)
        {
            if (collider.transform.parent.TryGetComponent<ObstacleCreater>(out ObstacleCreater _obs))
            {
                if (!_obs.IsEntered)
                {
                    _bag.RemoveCube(_obs.BoxCount);
                    _obs.IsEntered = true;
                }
            }
        }
    }
    void OnTriggerStay(Collider collider)
    {
        if (Time.time < stayTimer + 0.3f)
        {
            return;
        }
        if (collider.CompareTag("ObsSpace"))
        {
            _bag.RemoveCube(1);
            stayTimer = Time.time;
        }
    }
}
