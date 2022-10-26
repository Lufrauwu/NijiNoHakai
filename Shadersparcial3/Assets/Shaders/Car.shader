Shader "UWU/Car"
{
    Properties
    {
        _RimColor ("Rim Color", Color) = (1,1,1,1)
        _Range("Range", Range(0, 3)) = 1
    }
    SubShader
    {
        Tags { "Queue"="Transparent" }
        Pass{
            ZWrite On
            ColorMask 0
        }
        CGPROGRAM
        #pragma surface surf Lambert alpha:fade

        struct Input
        {
            float3 viewDir;
        };
        half _Range;
        float4 _RimColor;

        void surf (Input IN, inout SurfaceOutput o)
        {
            half rim =    1- saturate(dot(normalize(IN.viewDir ), o.Normal)) ;
            o.Emission = pow( rim ,  _RimColor);
            o.Alpha = pow(rim, _RimColor)- _RimColor;

        }
        ENDCG
    }
    FallBack "Diffuse"
}
