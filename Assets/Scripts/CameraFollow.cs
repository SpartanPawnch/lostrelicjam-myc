using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float transitionMult = 1.0f;

    //positions for transtion
    private Vector3 initialPosition = new Vector3(.0f, .0f, .0f);
    private Quaternion initialRotation;

    //transition timing
    private float transitionSpeed = 1.0f;
    private float transitionDelta = .0f;
    [SerializeField] private Vector2 customOffset;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position - customOffset.x * target.transform.forward + new Vector3(.0f, customOffset.y, .0f); // horizontal offset
        transform.LookAt(target.transform); // look at player

        //execute transition
        transitionDelta = Mathf.Clamp(transitionDelta - (Time.deltaTime / transitionSpeed), .0f, 1.0f);

        transform.position = Vector3.Lerp(transform.position, initialPosition, transitionDelta);
        transform.rotation = Quaternion.Lerp(transform.rotation, initialRotation, transitionDelta);
    }

    public void beginTransition(Vector3 initialPos, Quaternion initialRot)
    {
        transitionDelta = 1.0f;
        initialPosition = initialPos;
        initialRotation = initialRot;
        transitionSpeed = transitionMult * Vector3.Distance(target.transform.position - (customOffset.x *
            target.transform.forward), initialPos);
    }


}
