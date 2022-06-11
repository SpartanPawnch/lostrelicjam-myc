using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool inTopdown = true;

    [SerializeField] private GameObject character;

    [SerializeField] private GameObject initialSpawnLocation;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Camera topdownCamera;

    private Vector3 respawnLocation;
    private CameraFollow thirdPersonAccessor;
    private AudioSource topdownSound;

    public void Start()
    {
        character.SetActive(false);
        thirdPersonCamera.enabled = false;
        topdownCamera.enabled = true;
        respawnLocation = initialSpawnLocation.transform.position;
        thirdPersonAccessor = thirdPersonCamera.GetComponent<CameraFollow>();
        topdownSound = topdownCamera.GetComponent<AudioSource>();
    }

    public void Update()
    {
        if (Input.GetButtonDown("Swap"))
            switchPerspective();
    }


    public void switchPerspective()
    {

        //change display
        inTopdown = !inTopdown;

        if (inTopdown)
        {
            character.SetActive(false);
            thirdPersonCamera.enabled = false;
            topdownCamera.enabled = true;
            topdownSound.UnPause();
        }
        else
        {
            character.SetActive(true);
            //change active camera
            thirdPersonCamera.enabled = true;
            //setup camera transition
            Vector3 initialPos = topdownCamera.transform.position;//character.transform.InverseTransformPoint(topdownCamera.transform.position);
            thirdPersonAccessor?.beginTransition(initialPos);
            topdownCamera.enabled = false;
            character.transform.position = respawnLocation;
            topdownSound.Pause();

        }
    }

    public void setRespawnLoc(Vector3 location)
    {
        respawnLocation = location;
    }
}
