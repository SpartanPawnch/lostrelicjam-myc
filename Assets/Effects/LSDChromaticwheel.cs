using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSDChromaticwheel : MonoBehaviour
{
    public float Speed = 0.2F;
    public float Frequency = 8.0F;
    public float AmplitudeFactor = 1.0F;
    public float EffectOpacity = 0.4F;
    
    void OnRenderImage(RenderTexture source, RenderTexture output) 
    {
        var sheet = new Material(Shader.Find("Hidden/LSDChromaticWheel"));
        sheet.SetFloat("_Amplitude", AmplitudeFactor * 2.0F / source.width);
        sheet.SetFloat("_Speed", Speed);
        sheet.SetFloat("_Frequency", Frequency);
        sheet.SetFloat("_EffectOpacity", EffectOpacity);
        Graphics.Blit(source, output, sheet);
    }
}

