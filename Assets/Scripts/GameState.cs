using UnityEngine;

public class GameState : MonoBehaviour
{
    public bool inTopdown = true;

    [SerializeField] private GameObject character;

    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Camera topdownCamera;

    public void Start()
    {
        character.SetActive(false);
        thirdPersonCamera.enabled = false;
        topdownCamera.enabled = true;
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
            character.transform.position = spawnLocation.transform.position;
        }
    }
}
