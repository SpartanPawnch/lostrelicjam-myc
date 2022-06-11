using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    private List<AudioSource> audioSources;
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    public void OnEnterSpawn()
    {
        
    }

    public void OnExitSpawn()
    {
        
    }

    public void OnEnterMushroomArea(MushroomAreas mushroomArea)
    {
        
    }

    public void OnEnterMushroomNear(MushroomAreas mushroomArea)
    {
        
    }

    public void OnExitMushroom()
    {
        
    }

    void Update()
    {
        
    }
}
