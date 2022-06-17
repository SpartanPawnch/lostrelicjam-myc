using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] private Rigidbody activeRigidbody;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float maxVelocity = 10.0f;
    [SerializeField] private float drag = .1f;

    [SerializeField] private float rotateSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        //apply drag
        if (verticalAxis == 0)
        {
            activeRigidbody.velocity = Vector3.ClampMagnitude(activeRigidbody.velocity,
                activeRigidbody.velocity.magnitude - drag * Time.deltaTime);   
        }

        //rotate playeer
        transform.Rotate(new Vector3(0, horizontalAxis * rotateSpeed * Time.deltaTime, 0));

        //apply accelleration

        activeRigidbody.velocity += acceleration * transform.forward * verticalAxis * Time.deltaTime;

        activeRigidbody.velocity = Vector3.ClampMagnitude(activeRigidbody.velocity, maxVelocity);



    }

}
