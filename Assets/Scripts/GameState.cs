using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool inTopdown = true;

    [SerializeField] private GameObject character;

    [SerializeField] private GameObject initialSpawnLocation;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Camera topdownCamera;

    private Vector3 respawnLocation;

    public void Start()
    {
        character.SetActive(false);
        thirdPersonCamera.enabled = false;
        topdownCamera.enabled = true;
        respawnLocation = initialSpawnLocation.transform.position;
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
        }
        else
        {
            character.SetActive(true);
            thirdPersonCamera.enabled = true;
            topdownCamera.enabled = false;
            character.transform.position = respawnLocation;
        }
    }

    public void setRespawnLoc(Vector3 location)
    {
        respawnLocation = location;
    }
}
