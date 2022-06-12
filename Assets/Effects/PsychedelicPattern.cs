using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsychedelicPattern : MonoBehaviour
{
    public float Displacement = 0.3F;
    public float EffectOpacity = 1.0F;
    
    void OnRenderImage(RenderTexture source, RenderTexture output) 
    {
        var sheet = new Material(Shader.Find("Hidden/PsychedelicPattern"));
        sheet.SetFloat("_Ratio", (float)source.width / (float)source.height);
        sheet.SetFloat("_Displacement", Displacement);
        sheet.SetFloat("_EffectOpacity", EffectOpacity);
        Graphics.Blit(source, output, sheet);
    }
}
