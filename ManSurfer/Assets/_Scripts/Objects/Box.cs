using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject target;
    public float speed;
    public bool IsBag;

    PlayerController pl;
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
            switch (pl.directionBound)
            {
                case "X":
                    LerpX();
                    break;

                case "Z":
                    LerpZ();
                    break;
            }
            transform.rotation = target.transform.rotation;
        }
    }
    void LerpX()
    {
        float x = Mathf.Lerp(transform.position.x, target.transform.position.x, Time.deltaTime * speed);
        transform.position = new Vector3(x, transform.position.y, target.transform.position.z);
    }
    void LerpZ()
    {
        float z= Mathf.Lerp(transform.position.z, target.transform.position.z, Time.deltaTime * speed);
        transform.position = new Vector3(target.transform.position.x, transform.position.y, z);
    }
    void FindPlayer()
    {
        pl = FindObjectOfType<PlayerController>();
        target = pl.gameObject;
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
