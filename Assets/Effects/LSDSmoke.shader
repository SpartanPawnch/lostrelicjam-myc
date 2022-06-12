Shader "Hidden/LSDSmoke"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Ratio ("Ratio", Float) = 0.0
        _Displacement ("Displacement", Float) = 1.0
        _EffectOpacity ("Effect Opacity", Float) = 0.4
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            #include "utility.cginc"
            #include "effects.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            float _EffectOpacity;
            float _Ratio;
            float _Displacement;

            fixed4 frag (v2f i) : SV_Target
            {
                float2 s = wobble(i.uv, 0.2, 8, 0.3);
                fixed4 f = chromatic_wheel(s);
                
                fixed4 col = tex2D(_MainTex, i.uv + 0.005 * _Displacement * f.xy);
                fixed4 eff = lsd_smoke(i.uv, _Ratio);
                return blend_hardmix(col, eff, _EffectOpacity);
            }
            ENDCG
        }
    }
}
