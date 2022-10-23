 Shader "UWU/BP2" {
  
         Properties {
             _Color ("Color", color) = (1,1,1,1)
             _MainTex("Texture", 2D) = "white"
             _Metalic("Metalic", Range(0, 1)) = 1
             
         }
         SubShader {

          
             CGPROGRAM
             #pragma surface surf Standard

             
             struct Input {
                float2 uv_MetalicTex;
             };
        float4 _Color;
         sampler2D _MainTex;
             half _Metalic;

            
 
             void surf (Input IN, inout SurfaceOutputStandard o) {
                 o.Smoothness = tex2D(_MainTex, IN.uv_MetalicTex).rgb;
                 o.Albedo = _Color.rgb;
                 o.Metallic = _Metalic;
                 

             }
             ENDCG
         }
         FallBack "Diffuse"
     }