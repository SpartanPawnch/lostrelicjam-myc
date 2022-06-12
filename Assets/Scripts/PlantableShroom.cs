using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableShroom : MonoBehaviour
{
    [SerializeField] GameState gameState;

    [SerializeField] GameObject character;
    [SerializeField] GameObject ShroomModel;
    [SerializeField] MeshRenderer markerRenderer;
    private bool planted;
    // Start is called before the first frame update
    void Start()
    {
        planted = false;
        markerRenderer.enabled = true;
        ShroomModel.SetActive(false);
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == character && gameState.MushroomsHeld > 0)
        {
            gameState.MushroomsHeld--;
            markerRenderer.enabled = false;
            // note: make sure child shroom's collider is inactive or removed so it can not be picked up
            ShroomModel.SetActive(true);
            planted = true;
        }
    }
}
