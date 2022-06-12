using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shroom : MonoBehaviour
{
    [SerializeField] private GameObject mainChar;
    [SerializeField] private EffectStackController effectStackController;
    [SerializeField] private float nearRadius;
    [SerializeField] private float effectRadius;
    [SerializeField] private MusicController musicController;
    public MushroomAreas Mushroom;
    void Start()
    {

    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position,
            mainChar.transform.position);

        if (distance > nearRadius + effectRadius)
        {
            return;
        }

        if (distance <= nearRadius) // play the peaceful music and remove shaders
        {
            MushroomAreas mushroomArea = Mushroom;

            musicController.OnEnterMushroomNear(mushroomArea);
            effectStackController.MushroomArea = MushroomAreas.None;
        }
        else if (distance >= nearRadius && distance <= effectRadius) // play the high intensity music and shaders increasing in intensity as you get closer 
        {
            MushroomAreas mushroomArea = Mushroom;
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
