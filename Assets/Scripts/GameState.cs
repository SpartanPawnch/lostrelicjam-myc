using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool inTopdown = true;

    public uint MushroomsHeld { get; set; } // for collecting and planting

    [SerializeField] private GameObject character;

    [SerializeField] private GameObject initialSpawnLocation;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Camera topdownCamera;

    private Vector3 respawnLocation;
    private Quaternion respawnRotation;
    private CameraFollow thirdPersonAccessor;
    private AudioSource topdownSound;
    private CameraTopdown topdownControls;

    private enum State
    {
        Normal,
        Respawning
    };

    private State state = State.Normal;
    private float respawnProgress = 0.0F;
    private RespawnTransition respawnTransition;
    
    public void Start()
    {
        MushroomsHeld = 0;
        character.SetActive(false);
        thirdPersonCamera.enabled = false;
        topdownCamera.enabled = true;
        respawnLocation = initialSpawnLocation.transform.position;
        respawnRotation = character.transform.rotation;
        thirdPersonAccessor = thirdPersonCamera.GetComponent<CameraFollow>();
        topdownSound = topdownCamera.GetComponent<AudioSource>();
        topdownControls = topdownCamera.GetComponent<CameraTopdown>();
        respawnTransition = thirdPersonCamera.GetComponent<RespawnTransition>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Swap"))
            switchPerspective();

        if (state == State.Respawning)
        {

            if (respawnProgress == 0.0F)
            {
                respawnTransition.enabled = true;
            }
            else if (respawnProgress < 0.4F)
            {
                respawnTransition.Completion = respawnProgress / 0.4F;
            }
            else if (respawnProgress >= 0.4F && respawnProgress <= 0.6F)
            {
                character.transform.position = respawnLocation;
                // set position
            }
            else if (respawnProgress <= 1.0F)
            {
                respawnTransition.Completion = 1.0F - (respawnProgress - 0.6F) / 0.4F;
            }
            else
            {
                respawnTransition.enabled = false;
                state = State.Normal;
            }
            

            respawnProgress += Time.deltaTime * 0.5F;
        }
    }

    public void TriggerRespawn()
    {
        state = State.Respawning;
        respawnProgress = 0.0F;
    }
    
    public void switchPerspective()
    {

        //change display
        inTopdown = !inTopdown;

        if (inTopdown)
        {
            character.SetActive(false);
            topdownControls.enabled = true;
            thirdPersonCamera.enabled = false;
            topdownCamera.enabled = true;
            topdownSound.UnPause();
        }
        else
        {
            character.SetActive(true);
            //lock topdown view
            topdownControls.enabled = false;
            //change active camera
            thirdPersonCamera.enabled = true;
            //setup camera transition
            Vector3 initialPos = topdownCamera.transform.position;
            thirdPersonAccessor?.beginTransition(initialPos, topdownCamera.transform.rotation);
            topdownCamera.enabled = false;
            character.transform.position = respawnLocation;
            character.transform.rotation = respawnRotation;
            topdownSound.Pause();

        }
    }

    public void setRespawnLoc(Vector3 location)
    {
        respawnLocation = location;
    }
}
