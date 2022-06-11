using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantableShroom : MonoBehaviour
{
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

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == character)
        {
            markerRenderer.enabled = false;
            ShroomModel.SetActive(true);
            planted = true;
        }
    }
}
