using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NoiseIntensifier : MonoBehaviour
{

    [SerializeField] private EffectStackController effectStackController;

    [SerializeField] private float nearRadius;
    [SerializeField] private float effectRadius;
    [SerializeField] private MusicController musicController;
    
    private GameObject[] shrooms;

    // Start is called before the first frame update
    void Start()
    {
        shrooms = GameObject.FindGameObjectsWithTag("Shroom");
    }

    // Update is called once per frame
    void Update()
    {
        GameObject eatenShroom = null;

        foreach (var shroom in shrooms)
        {
            if (
                Vector3.Distance(transform.position, shroom.transform.position) <= 
                nearRadius + effectRadius
                )
            {
                eatenShroom = shroom;
            }
        }

        if (!eatenShroom)
        {
            return;
        }
        
        float distance = Vector3.Distance(transform.position,
            eatenShroom.transform.position);
        
        if (distance <= nearRadius) // play the peaceful music and remove shaders
        {
            var mushroomArea = eatenShroom.GetComponent<Shroom>()?.Mushroom ??
                               MushroomAreas.Mushroom2;
            
            musicController.OnEnterMushroomNear(mushroomArea);
            effectStackController.MushroomArea = MushroomAreas.None;
        }
        else if (distance >= nearRadius && distance <= effectRadius) // play the high intensity music and shaders increasing in intensity as you get closer 
        {
            var mushroomArea = eatenShroom.GetComponent<Shroom>()?.Mushroom ??
                               MushroomAreas.Mushroom2;
            musicController.OnEnterMushroomArea(mushroomArea);

            float effectPercentage = 1 - (distance - nearRadius) / (effectRadius - nearRadius);
            effectStackController.MushroomArea = mushroomArea;
            effectStackController.Intensity = effectPercentage;
        }
        else
        {
            musicController.OnExitMushroom();
            effectStackController.MushroomArea = MushroomAreas.None;
        }
    }
}
