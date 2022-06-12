using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseIntensifier : MonoBehaviour
{

    [SerializeField] private EffectStackController effectStackController;

    [SerializeField] private float nearRadius;
    [SerializeField] private float effectRadius;
    [SerializeField] private Transform player;
    [SerializeField] private MushroomAreas mushroomArea;
    [SerializeField] private MusicController musicController;

    // Start is called before the first frame update
    void Start()
    {
        
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,
            player.position);
        
        
        if (distance <= nearRadius) // play the peaceful music and remove shaders
        {
            musicController.OnEnterMushroomNear(mushroomArea);


            effectStackController.MushroomArea = MushroomAreas.None;
            
        }
        else if (distance >= nearRadius && distance <= effectRadius) // play the high intensity music and shaders increasing in intensity as you get closer 
        {
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
