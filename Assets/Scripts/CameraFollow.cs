using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            
            transform.position = target.transform.position - (offset.x * target.transform.forward); // horizontal offset
            transform.LookAt(target.transform); // look at player
        }
    }
}
