using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTopdown : MonoBehaviour
{

    [SerializeField] private float camSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //get correct forward vector
        Vector3 fwVector = Vector3.Cross(transform.right, new Vector3(.0f, 1.0f, .0f));
        transform.position += (horizontalAxis * transform.right + verticalAxis * fwVector) * Time.deltaTime * camSpeed;
    }
}
