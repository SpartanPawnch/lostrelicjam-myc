using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float transitionMult = 1.0f;

    //positions for transtion
    private Vector3 offset;

    private Vector3 initialPosition = new Vector3(.0f, .0f, .0f);

    //transition timing
    private float transitionSpeed = 1.0f;
    private float transitionDelta = .0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {

        transitionDelta = Mathf.Clamp(transitionDelta - (Time.deltaTime / transitionSpeed), .0f, 1.0f);
        Vector3 targetPosition = offset;
        transform.localPosition = transitionDelta * initialPosition + (1.0f - transitionDelta) * targetPosition;


    }

    public void beginTransition(Vector3 initialPos)
    {
        transitionDelta = 1.0f;
        initialPosition = initialPos;
        transitionSpeed = transitionMult * Vector3.Distance(offset, initialPos);
    }


}
