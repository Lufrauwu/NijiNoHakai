Shader "Custom/FullPBR"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _SmoothnessTex ("Smoothness", 2D) = "white" {}
        _MetallicTex ("Metallic", 2D) = "white"{}
        _MetallicRange ("Metalic" , Range(0,1)) = 1
        _OcclusionRange("Occlusion range" , Range(0,1)) = 1
        _AOTex ("AO" , 2D) = "white"{}
        _NormalMap ("Normal map", 2D) = "bump" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200
        CGPROGRAM
        #pragma surface surf Standard
        #pragma target 3.0
        half _MetallicRange;
        sampler2D _MainTex;
        sampler2D _AOTex;
        sampler2D _Smoothness;
        sampler2D _MetallicTex;
        sampler2D _NormalMap;
        half _OcclusionRange;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_AOTex;
            float2 uv_SmoothnessTex;
            float2 uv_MetallicTex;
            float2 uv_NormalMap;
        };
        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            o.Albedo = tex2D(_MainTex, IN.uv_MainTex);
            o.Occlusion = tex2D(_AOTex, IN.uv_AOTex) * _OcclusionRange;
            o.Smoothness = tex2D(_Smoothness, IN.uv_SmoothnessTex);
            o.Metallic = tex2D(_MetallicTex, IN.uv_MetallicTex) * _MetallicRange;
            o.Normal = UnpackNormal(tex2D(_NormalMap, IN.uv_NormalMap));
        }
        
        ENDCG
    }
    FallBack "Diffuse"
}
