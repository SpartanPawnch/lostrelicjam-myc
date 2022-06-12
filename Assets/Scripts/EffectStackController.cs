using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStackController : MonoBehaviour
{
    private Ezbhan ezbhan;
    private LSDChromaticwheel lsdChromaticWheel;
    private ChromaticWaves chromaticWaves;
    private PsychedelicPattern psychedelicPattern;
    
    public MushroomAreas MushroomArea;
    [Range(0,1)] public float Intensity;


    // Start is called before the first frame update
    void Start()
    {
        ezbhan = GetComponent<Ezbhan>();
        lsdChromaticWheel = GetComponent<LSDChromaticwheel>();
        chromaticWaves = GetComponent<ChromaticWaves>();
        psychedelicPattern = GetComponent<PsychedelicPattern>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (MushroomArea)
        {
            case MushroomAreas.None:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = false;
                break;
            case MushroomAreas.Mushroom2:
                ezbhan.enabled = true;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = false;


                ezbhan.EffectOpacity = Intensity * 1f;
                ezbhan.Displacement = 0.001f + (Intensity * 0.01f);
                break;
            case MushroomAreas.Mushroom3:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = true;
                psychedelicPattern.enabled = false;

                chromaticWaves.LightPos = new Vector2(
                    Intensity * 0.4f,
                    Intensity * 0.4f
                );
            
                chromaticWaves.Displacement = Intensity * 0.05F;
                chromaticWaves.EffectOpacity = Mathf.Clamp(Intensity * 10.0F, 0.0F, 1.0F);
                
                break;
            case MushroomAreas.Mushroom4:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = true;

                psychedelicPattern.Displacement = 0.002F;
                psychedelicPattern.EffectOpacity =
                    Mathf.Clamp(Intensity, 0.0F, 0.35F);
                
                break;
            case MushroomAreas.Mushroom5:
                break;
        }
    }
}
