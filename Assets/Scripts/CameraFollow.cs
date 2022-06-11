using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float transitionMult = 1.0f;

    //positions for transtion
    private Vector3 initialPosition = new Vector3(.0f, .0f, .0f);

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
        transform.localPosition = customOffset.x * target.transform.forward; // horizontal offset
        transform.LookAt(target.transform); // look at player

        //execute transition
        transitionDelta = Mathf.Clamp(transitionDelta - (Time.deltaTime / transitionSpeed), .0f, 1.0f);
        Vector3 targetPosition = transform.localPosition;
        transform.localPosition = transitionDelta * initialPosition + (1.0f - transitionDelta) * targetPosition;
    }

    public void beginTransition(Vector3 initialPos)
    {
        transitionDelta = 1.0f;
        initialPosition = initialPos;
        transitionSpeed = transitionMult * Vector3.Distance(customOffset.x * target.transform.forward, initialPos);
    }


}
