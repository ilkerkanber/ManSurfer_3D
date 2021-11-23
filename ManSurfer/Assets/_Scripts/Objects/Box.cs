using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float speed;
    public bool IsBag;

    void Start()
    {
        FindPlayer();    
    }
    void Update()
    {
        if (target == null)
        {
            FindPlayer();
        }
    }
    void FixedUpdate()
    {
        if (IsBag)
        {
            float x = Mathf.Lerp(transform.position.x, target.transform.position.x, Time.deltaTime * speed);
            transform.position = new Vector3(x, transform.position.y, target.transform.position.z);
            transform.rotation = target.transform.rotation;
        }
    }
    void FindPlayer()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
    }
    void OnTriggerEnter(Collider collider)
    {
        if (!IsBag)
        {
            if (collider.GetComponentInChildren<Bag>())
            {
                Bag bag= collider.GetComponentInChildren<Bag>();
                bag.AddCube(GetComponent<Box>());
            }
        }
    }
}
