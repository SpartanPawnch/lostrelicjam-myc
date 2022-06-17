using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameState : MonoBehaviour
{
    public bool inTopdown = true;

    public uint MushroomsHeld { get; set; } // for collecting and planting

    [SerializeField] private GameObject character;

    [SerializeField] private GameObject initialSpawnLocation;
    [SerializeField] private Camera thirdPersonCamera;
    [SerializeField] private Camera topdownCamera;

    [SerializeField] private MusicController musicController;

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

    private List<PlantableShroom> plantableShrooms = new List<PlantableShroom>();


    public void Start()
    {
        MushroomsHeld = 0;
        respawnTransition = thirdPersonCamera.GetComponent<RespawnTransition>();
        // character.SetActive(false);
        // thirdPersonCamera.enabled = false;
        // topdownCamera.enabled = true;
        respawnLocation = initialSpawnLocation.transform.position;
        respawnRotation = character.transform.rotation;
        // thirdPersonAccessor = thirdPersonCamera.GetComponent<CameraFollow>();
        //topdownSound = topdownCamera.GetComponent<AudioSource>();
        //topdownControls = topdownCamera.GetComponent<CameraTopdown>();

        foreach (var obj in GameObject.FindGameObjectsWithTag("PlantableShroom"))
        {
            plantableShrooms.Add(obj.GetComponent<PlantableShroom>());
        }

        Debug.Log(plantableShrooms);
    }

    public void Update()
    {
        // if (Input.GetButtonDown("Swap"))
        //     switchPerspective();

        if (state == State.Respawning)
        {

            if (respawnProgress == 0.0F)
            {
                respawnTransition.enabled = true;
            }
            else if (respawnProgress < 0.35F)
            {
                respawnTransition.Completion = respawnProgress / 0.35F;
            }
            else if (respawnProgress >= 0.35F && respawnProgress <= 0.6F)
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


            respawnProgress += Time.deltaTime / 4.0F;
        }
    }

    public void TriggerRespawn()
    {
        musicController.OnRespawn();
        state = State.Respawning;
        respawnProgress = 0.0F;
    }

    public void OnCollectShroom(SwitchableObj shroom)
    {
        if (MushroomsHeld != 0)
            return;
        
        MushroomsHeld++;
        shroom.DisableShroom();

        Debug.Log("activating spot");
        Debug.Log(plantableShrooms.First());
        // choose PlantableShroom
        plantableShrooms.First().EnableSpot();
        plantableShrooms.RemoveAt(0);
        
        TriggerRespawn();
    }

    public void switchPerspective()
    {

        //change display
        inTopdown = !inTopdown;

        if (inTopdown)
        {
            character.SetActive(false);
            //topdownControls.enabled = true;
            thirdPersonCamera.enabled = false;
            topdownCamera.enabled = true;
            //topdownSound.UnPause();
        }
        else
        {
            character.SetActive(true);
            //lock topdown view
            //topdownControls.enabled = false;
            //change active camera
            thirdPersonCamera.enabled = true;
            //setup camera transition
            Vector3 initialPos = topdownCamera.transform.position;
            thirdPersonAccessor?.beginTransition(initialPos, topdownCamera.transform.rotation);
            topdownCamera.enabled = false;
            character.transform.position = respawnLocation;
            character.transform.rotation = respawnRotation;
            //topdownSound.Pause();

        }
    }

    public void setRespawnLoc(Vector3 location)
    {
        respawnLocation = location;
    }
}
