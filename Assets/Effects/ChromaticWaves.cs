using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChromaticWaves : MonoBehaviour
{
    public float Displacement = 0.05F;
    public Vector2 LightPos = new Vector2(0.0F, 0.0F);
    void OnRenderImage(RenderTexture source, RenderTexture output) 
    {
        var sheet = new Material(Shader.Find("Hidden/ChromaticWaves"));
        sheet.SetFloat("_Ratio", (float)source.width / (float)source.height);
        sheet.SetFloat("_Displacement", Displacement);
        sheet.SetVector("_LightPos", new Vector4((LightPos.x + 1.0F) / 2.0F, (LightPos.y + 1.0F) / 2.0F, 0.0F, 0.0F));
        Graphics.Blit(source, output, sheet);
    }
}
