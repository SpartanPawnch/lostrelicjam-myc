using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStackController : MonoBehaviour
{
    private Ezbhan ezbhan;
    private LSDChromaticwheel lsdChromaticWheel;
    private ChromaticWaves chromaticWaves;
    private PsychedelicPattern psychedelicPattern;

    private LSDSmoke lsdSmoke;
    
    public MushroomAreas MushroomArea;
    [Range(0,1)] public float Intensity;


    // Start is called before the first frame update
    void Start()
    {
        ezbhan = GetComponent<Ezbhan>();
        lsdChromaticWheel = GetComponent<LSDChromaticwheel>();
        chromaticWaves = GetComponent<ChromaticWaves>();
        psychedelicPattern = GetComponent<PsychedelicPattern>();
        lsdSmoke = GetComponent<LSDSmoke>();
    }

    // Update is called once per frame
    void Update()
    {
        float remappedIntensity = Mathf.Clamp(Intensity * 3.0F, 0.0F, 1.0F);

        switch (MushroomArea)
        {
            case MushroomAreas.None:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = false;
                lsdSmoke.enabled = false;
                break;
            case MushroomAreas.Mushroom2:
                ezbhan.enabled = true;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = false;
                lsdSmoke.enabled = false;

                ezbhan.EffectOpacity = remappedIntensity * 1f;
                ezbhan.Displacement = 0.001f + (remappedIntensity * 0.01f);
                break;
            case MushroomAreas.Mushroom3:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = true;
                psychedelicPattern.enabled = false;
                lsdSmoke.enabled = false;

                chromaticWaves.LightPos = new Vector2(
                    remappedIntensity * 0.4f,
                    remappedIntensity * 0.4f
                );
            
                chromaticWaves.Displacement = remappedIntensity * 0.05F;
                chromaticWaves.EffectOpacity = Mathf.Clamp(remappedIntensity * 10.0F, 0.0F, 1.0F);
                
                break;
            case MushroomAreas.Mushroom4:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = true;
                lsdSmoke.enabled = false;

                psychedelicPattern.Displacement = 0.002F;
                psychedelicPattern.EffectOpacity =
                    Mathf.Clamp(remappedIntensity, 0.0F, 0.35F);
                
                break;
            case MushroomAreas.Mushroom5:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                psychedelicPattern.enabled = false;
                lsdSmoke.enabled = true;

                lsdSmoke.Displacement = Mathf.Clamp(remappedIntensity * 10, 0.0F, 1.0F);
                lsdSmoke.EffectOpacity = Mathf.Clamp(remappedIntensity * 10, 0.0F, 1.0F) * 0.4F;
                
                break;
        }
    }
}
