using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSDSmoke : MonoBehaviour
{
    public float Displacement = 1.0F;
    public float EffectOpacity = 0.4F;
    
    void OnRenderImage(RenderTexture source, RenderTexture output) 
    {
        var sheet = new Material(Shader.Find("Hidden/LSDSmoke"));
        sheet.SetFloat("_EffectOpacity", EffectOpacity);
        sheet.SetFloat("_Displacement", Displacement);
        sheet.SetFloat("_Ratio", (float)source.width / (float)source.height);
        Graphics.Blit(source, output, sheet);
    }
}
