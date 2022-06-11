using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    [SerializeField] private Rigidbody activeRigidbody;
    [SerializeField] private float acceleration = 2.0f;
    [SerializeField] private float maxVelocity = 10.0f;
    [SerializeField] private float drag = .1f;

    private Vector3 initialPosition;

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
        activeRigidbody.velocity = Vector3.ClampMagnitude(activeRigidbody.velocity,
            activeRigidbody.velocity.magnitude - drag * Time.deltaTime);


        //apply accelleration
        Vector3 directionalForce = new Vector3(horizontalAxis, 0.0f, verticalAxis);

        activeRigidbody.velocity += acceleration * directionalForce * Time.deltaTime;

        activeRigidbody.velocity = Vector3.ClampMagnitude(activeRigidbody.velocity, maxVelocity);

    }

    void Awake()
    {
        initialPosition = transform.localPosition;
    }

    void OnEnable()
    {
        transform.localPosition = initialPosition;
    }
}
