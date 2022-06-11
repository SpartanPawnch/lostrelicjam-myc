Shader "Hidden/Ezbhan"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Ratio ("Ratio", Float) = 1.0
        _Displacement ("Displacement", Float) = 0.001
        _EffectOpacity ("Effect Opacity", Float) = 0.01
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
            float _Ratio;
            float _Displacement;
            float _EffectOpacity;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 eff = ezbhan(i.uv, _Ratio);
                fixed4 col = tex2D(_MainTex, i.uv + _Displacement * (eff.xy));
                return blend_screen(col, eff, _EffectOpacity);
            }
            ENDCG
        }
    }
}
