Shader "Hidden/ChromaticWaves"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Displacement ("Displacement", Float) = 0.05
        _LightPos ("Light Position", Vector) = (1.0, 1.0, 0.0, 0.0) 
        _Ratio ("Ratio", Float) = 1.0
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
            float4 _LightPos;
            float _Displacement;
            float _Ratio;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 eff = waves(i.uv, _Ratio, _LightPos.xy);
                fixed4 col = tex2D(_MainTex, i.uv + _Displacement * eff.xy);

                col.xyz = rgb2hsv(col);
                col.x = col.x + length(eff);
                col.xyz = hsv2rgb(col);
                
                return col;
            }
            ENDCG
        }
    }
}
