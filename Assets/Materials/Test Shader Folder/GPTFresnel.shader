Shader "GPTShader/SimpleFresnelShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Float) = 3.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldNormal : TEXCOORD0;
                float3 viewDir : TEXCOORD1;
            };

            fixed4 _Color;
            fixed4 _FresnelColor;
            float _FresnelPower;

            v2f vert (appdata v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);
                o.viewDir = normalize(UnityWorldSpaceViewDir(v.vertex));
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float fresnel = pow(1.0 - dot(normalize(i.viewDir), normalize(i.worldNormal)), _FresnelPower);
                fixed4 finalColor = _Color + _FresnelColor * fresnel;
                return finalColor;
            }
            ENDCG
        }
    }
}
