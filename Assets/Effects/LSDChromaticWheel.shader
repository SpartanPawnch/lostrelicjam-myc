Shader "Hidden/LSDChromaticWheel"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Speed ("Speed", Float) = 0.2
        _Frequency ("Frequency", Float) = 16.0 
        _Amplitude ("Amplitude", Float) = 0.0
        _EffectOpacity ("Effect Opacity", Float) = 0.0
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
            #include "effects.cginc"
            #include "utility.cginc"

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
            float _Speed;
            float _Frequency;
            float _Amplitude;
            float _EffectOpacity;
            
            fixed4 frag (v2f i) : SV_Target
            {
                float2 s = wobble(i.uv, _Speed, _Frequency, _Amplitude);
                fixed4 f = chromatic_wheel(s);
                fixed4 col = tex2D(_MainTex, i.uv);
                return blend_overlay(col, f, _EffectOpacity);
            }
            ENDCG
        }
    }
}
