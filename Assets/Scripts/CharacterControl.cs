using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] private Rigidbody activeRigidbody;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float maxVelocity = 10.0f;
    [SerializeField] private float drag = .1f;

    [SerializeField] private float rotateSpeedX = 5;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");

        Vector2 horizontalVelocity = new Vector2(activeRigidbody.velocity.x, activeRigidbody.velocity.z);

        //apply drag
        if (verticalAxis == 0 && horizontalAxis == 0)
        {
            horizontalVelocity = Vector2.ClampMagnitude(horizontalVelocity,
                horizontalVelocity.magnitude - drag * Time.deltaTime);
        }

        float mouseX = Input.GetAxis("Mouse X"), mouseY = Input.GetAxis("Mouse Y");

        //rotate playeer
        transform.Rotate(new Vector3(0, 360 * mouseX * rotateSpeedX * Time.deltaTime, 0));

        //apply accelleration

        float velocityMult = acceleration * Time.deltaTime;
        Vector2 forwardVec = new Vector2(transform.forward.x, transform.forward.z);
        Vector2 rightVec = new Vector2(transform.right.x, transform.right.z);
        horizontalVelocity += velocityMult * verticalAxis * forwardVec + velocityMult * horizontalAxis * rightVec;
        horizontalVelocity = Vector2.ClampMagnitude(horizontalVelocity, maxVelocity);
        activeRigidbody.velocity = new Vector3(horizontalVelocity.x, activeRigidbody.velocity.y, horizontalVelocity.y);



    }

}
