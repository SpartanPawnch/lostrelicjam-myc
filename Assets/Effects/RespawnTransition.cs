using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnTransition : MonoBehaviour
{
    public float Completion = 0.0F;
    void OnRenderImage(RenderTexture source, RenderTexture output) 
    {
        var sheet = new Material(Shader.Find("Hidden/RespawnTransition"));
        sheet.SetFloat("_Completion", Completion);
        sheet.SetFloat("_Ratio", (float)source.width / (float)source.height);
        Graphics.Blit(source, output, sheet);
    }
}
