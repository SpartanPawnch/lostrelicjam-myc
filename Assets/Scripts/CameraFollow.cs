using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float rotateSpeedY = 5;
    [SerializeField] private float lookLimit = 1.0f;

    //positions for transtion
    private Vector3 initialPosition = new Vector3(.0f, .0f, .0f);
    private float angle = .0f;

    //transition timing
    [SerializeField] private Vector2 customOffset;
    [SerializeField] private float castDelta = .1f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        angle = .0f;
    }

    // Update is called once per frame
    void Update()
    {
        //modify angle
        float mouseY = Input.GetAxis("Mouse Y");
        angle = Mathf.Clamp(angle + mouseY * Time.deltaTime * rotateSpeedY, -lookLimit, lookLimit);

        //rotate offset
        float newX = Mathf.Cos(angle) * customOffset.x - Mathf.Sin(angle) * customOffset.y;
        float newY = Mathf.Sin(angle) * customOffset.x + Mathf.Cos(angle) * customOffset.y;

        //apply new offset
        transform.position = target.transform.position - newX * target.transform.forward + new Vector3(.0f, newY, .0f); // horizontal offset
        transform.LookAt(target.transform); // look at player


        //resolve clipping
        RaycastHit hit;
        const int layerMask = 1 << 3;
        if (Physics.Raycast(target.transform.position, -transform.forward, out hit, customOffset.magnitude, layerMask))
        {
            transform.position = Vector3.Lerp(hit.point, target.transform.position, castDelta);
        }
    }
}
