using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ezbhan : MonoBehaviour
{
    public float Displacement = 0.001F;
    public float EffectOpacity = 0.01F;

    void OnRenderImage(RenderTexture source, RenderTexture output)
    {
        var sheet = new Material(Shader.Find("Hidden/Ezbhan"));
        sheet.SetFloat("_Ratio", (float)source.width / (float)source.height);
        sheet.SetFloat("_Displacement", Displacement);
        sheet.SetFloat("_EffectOpacity", EffectOpacity);
        Graphics.Blit(source, output, sheet);
    }
}
