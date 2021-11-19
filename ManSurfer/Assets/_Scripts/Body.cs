using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    Bag _bag;
    void Awake()
    {
        _bag = GetComponentInParent<Bag>();
    }
    void FixedUpdate()
    {
        transform.position = _bag.bag[0].gameObject.transform.position - Vector3.up * 0.2f;
    }
}
