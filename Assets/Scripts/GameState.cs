using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using UnityEngine.SceneManagement;
public class GameState : MonoBehaviour
{
    public bool inTopdown = true;

    public uint MushroomsHeld { get; set; } // for collecting and planting

    [SerializeField] private GameObject character;
    private CharacterControl characterControl;

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

    [HideInInspector] public int plantedCount = 0;
    [HideInInspector] public int plantedMax = 0;

    public void Start()
    {
        characterControl = character.GetComponent<CharacterControl>();
        MushroomsHeld = 0;
        respawnTransition = thirdPersonCamera.GetComponent<RespawnTransition>();
        respawnLocation = initialSpawnLocation.transform.position;
        respawnRotation = character.transform.rotation;

        foreach (var obj in GameObject.FindGameObjectsWithTag("PlantableShroom"))
        {
            plantableShrooms.Add(obj.GetComponent<PlantableShroom>());
        }

        plantedCount = 0;
        plantedMax = plantableShrooms.Count;

        // Debug.Log(plantableShrooms);
    }

    public void Update()
    {
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

        characterControl.ModifySpeed((float)plantedCount / plantedMax);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene(0);
        }
    }

    public void TriggerRespawn()
    {
        musicController.OnRespawn();
        state = State.Respawning;
        respawnProgress = 0.0F;
    }

    public void OnCollectShroom(Shroom shroom)
    {
        if (MushroomsHeld != 0)
            return;

        MushroomsHeld++;

        shroom.gameObject.SetActive(false);
        shroom.enabled = false;

        // choose PlantableShroom
        plantableShrooms.First().EnableSpot();
        plantableShrooms.First().ShroomModel = shroom.gameObject.transform.GetChild(
                shroom.gameObject.transform.childCount - 1
            ).gameObject;
        plantableShrooms.RemoveAt(0);

        TriggerRespawn();
    }
    public void setRespawnLoc(Vector3 location)
    {
        respawnLocation = location;
    }
}
