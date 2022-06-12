using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MusicController : MonoBehaviour
{
    private enum MusicTracks
    {
        Spawn,
        Mushroom,
        MushroomNear
    };

    private MushroomAreas mushroomArea = MushroomAreas.None;
    private MusicTracks musicTrack = MusicTracks.Spawn;
    private bool changed = true;
    
    private AudioSource[] audioSources;
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    private void changeTrack(MusicTracks newTrack, MushroomAreas newMushroomArea)
    {
        if (newTrack != musicTrack)
        {
            changed = true;
            musicTrack = newTrack;
            mushroomArea = newMushroomArea;
        }
        else if (
            (newTrack == MusicTracks.Mushroom || newTrack == MusicTracks.MushroomNear) &&
            newMushroomArea != mushroomArea
        )
        {
            changed = true;
            musicTrack = newTrack;
            mushroomArea = newMushroomArea;
        }
    }
    
    public void OnEnterSpawn()
    {
        changeTrack(MusicTracks.Spawn, MushroomAreas.None);
    }

    public void OnExitSpawn()
    {
        changeTrack(MusicTracks.Spawn, MushroomAreas.None);
    }

    public void OnEnterMushroomArea(MushroomAreas newArea)
    {
        changeTrack(MusicTracks.Mushroom, newArea);
    }

    public void OnEnterMushroomNear(MushroomAreas newArea)
    {
        changeTrack(MusicTracks.MushroomNear, newArea);
    }

    public void OnExitMushroom()
    {
        changeTrack(MusicTracks.Spawn, MushroomAreas.None);
    }

    void Update()
    {
        if (changed)
        {
            changed = false;
            
            if (musicTrack == MusicTracks.Spawn)
            {
                audioSources[0].clip = Resources.Load("Real_mycelium_Spawn_loop_80bpm") as AudioClip;
                audioSources[0].loop = true;
                audioSources[0].Play();
            }
            else if (musicTrack == MusicTracks.Mushroom)
            {
                if (mushroomArea == MushroomAreas.Mushroom2)
                {
                    audioSources[0].clip = Resources.Load("Real_mycelium_effect_loop_1") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
                else if (mushroomArea == MushroomAreas.Mushroom3)
                {
                    audioSources[0].clip = Resources.Load("Real_mycelium_effect_loop_2") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
                else if (mushroomArea == MushroomAreas.Mushroom4)
                {                
                    audioSources[0].clip = Resources.Load("Real_mycelium_effect_loop_3") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
                else if (mushroomArea == MushroomAreas.Mushroom5)
                {
                    audioSources[0].clip = Resources.Load("Real_mycelium_effect_loop_4") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
            }
            else if (musicTrack == MusicTracks.MushroomNear)
            {
                if (mushroomArea == MushroomAreas.Mushroom2)
                {
                    audioSources[0].clip = Resources.Load("Real_mycelium_Peaceful_loop_1_80bpm") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
                else if (mushroomArea == MushroomAreas.Mushroom3)
                {
                    audioSources[0].clip = Resources.Load("Real_mycelium_Peaceful_loop_2_80bpm") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
                else if (mushroomArea == MushroomAreas.Mushroom4)
                {                
                    audioSources[0].clip = Resources.Load("Real_mycelium_Peaceful_loop_3_80bpm") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
                else if (mushroomArea == MushroomAreas.Mushroom5)
                {
                    audioSources[0].clip = Resources.Load("Real_mycelium_Peaceful_loop_4_80bpm") as AudioClip;
                    audioSources[0].loop = true;
                    audioSources[0].Play();
                }
            }
        }
    }
}
