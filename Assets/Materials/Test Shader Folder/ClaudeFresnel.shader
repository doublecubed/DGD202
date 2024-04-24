Shader "ClaudeShader/BasicShaderURPFresnel"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelPower ("Fresnel Power", Range(0.1, 8)) = 2
    }

    SubShader
    {
        Tags { "RenderType" = "Opaque" "RenderPipeline" = "UniversalPipeline" }
        LOD 300

        HLSLINCLUDE
        #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
        ENDHLSL

        Pass
        {
            Name "ForwardLit"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma target 3.0

            #pragma vertex vert
            #pragma fragment frag

            struct Attributes
            {
                float4 positionOS   : POSITION;
                float2 uv           : TEXCOORD0;
                float3 normalOS     : NORMAL;
            };

            struct Varyings
            {
                float2 uv           : TEXCOORD0;
                float4 positionHCS  : SV_POSITION;
                float3 normalWS     : TEXCOORD1;
                float3 viewDirWS    : TEXCOORD2;
            };

            TEXTURE2D(_MainTex);
            SAMPLER(sampler_MainTex);

            CBUFFER_START(UnityPerMaterial)
            float4 _MainTex_ST;
            half4 _Color;
            half4 _FresnelColor;
            half _FresnelPower;
            CBUFFER_END

            Varyings vert(Attributes input)
            {
                Varyings output;
                output.positionHCS = TransformObjectToHClip(input.positionOS.xyz);
                output.uv = TRANSFORM_TEX(input.uv, _MainTex);
                output.normalWS = TransformObjectToWorldNormal(input.normalOS);
                output.viewDirWS = GetCameraPositionWS() - TransformObjectToWorld(input.positionOS.xyz);
                return output;
            }

            half4 frag(Varyings input) : SV_Target
            {
                half4 texColor = SAMPLE_TEXTURE2D(_MainTex, sampler_MainTex, input.uv);
                half3 normalWS = normalize(input.normalWS);
                half3 viewDirWS = normalize(input.viewDirWS);
                half fresnel = pow(1 - saturate(dot(normalWS, viewDirWS)), _FresnelPower);
                half4 finalColor = lerp(texColor * _Color, _FresnelColor, fresnel);
                return finalColor;
            }
            ENDHLSL
        }
    }
}