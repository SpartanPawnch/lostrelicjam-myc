using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableShroom : MonoBehaviour
{
    [SerializeField] GameState gameState;

    [SerializeField] GameObject character;
    [SerializeField] GameObject ShroomModel;
    [SerializeField] MeshRenderer markerRenderer;

    private enum State
    {
        Inactive,
        Planting,
        Planted
    }
    private State state = State.Inactive;
    // Start is called before the first frame update
    void Start()
    {
        state = State.Inactive;
        markerRenderer.enabled = false;
        ShroomModel.SetActive(false);
    }

    public void EnableSpot()
    {
        state = State.Planting;
        markerRenderer.enabled = true;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (state == State.Planting && collider.gameObject == character && gameState.MushroomsHeld > 0)
        {
            gameState.MushroomsHeld--;
            markerRenderer.enabled = false;
            // note: make sure child shroom's collider is inactive or removed so it can not be picked up
            ShroomModel.SetActive(true);
            state = State.Planted;
        }
    }
}
