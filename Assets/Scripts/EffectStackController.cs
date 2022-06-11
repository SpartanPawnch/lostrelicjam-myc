using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStackController : MonoBehaviour
{
    public enum EffectStack {
        None,
        Mushroom2,
        Mushroom3,
        Mushroom4,
        Mushroom5,
    }

    private Ezbhan ezbhan;
    private LSDChromaticwheel lsdChromaticWheel;
    private ChromaticWaves chromaticWaves;

    public EffectStack Stack;
    [Range(0,1)] public float Intensity;


    // Start is called before the first frame update
    void Start()
    {
        ezbhan = GetComponent<Ezbhan>();
        lsdChromaticWheel = GetComponent<LSDChromaticwheel>();
        chromaticWaves = GetComponent<ChromaticWaves>();
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Stack)
        {
            case EffectStack.None:
                ezbhan.enabled = false;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;
                break;
            case EffectStack.Mushroom2:
                ezbhan.enabled = true;
                lsdChromaticWheel.enabled = false;
                chromaticWaves.enabled = false;

                ezbhan.EffectOpacity = Intensity * 1f;
                ezbhan.Displacement = 0.001f + (Intensity * 0.01f);
                break;
            case EffectStack.Mushroom3:
                break;
            case EffectStack.Mushroom4:
                break;
            case EffectStack.Mushroom5:
                break;
        }
    }
}
