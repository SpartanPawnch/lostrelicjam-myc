using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnArea : MonoBehaviour
{
    [SerializeField] private GameObject mainChar;
    [SerializeField] private EffectStackController effectStackController;
    [SerializeField] private MusicController musicController;

    [SerializeField] private float radius;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position,
            mainChar.transform.position);

        if (distance < radius)
        {
            musicController.OnEnterSpawn();
            effectStackController.MushroomArea = MushroomAreas.None;
        }
    }
}
