 Shader "UWU/BP" {
  
         Properties {
             _Color ("Color", color) = (1,1,1,1)
             _SpecColor ("Spec color", color) = (0.5,0.5,0.5,0.5)
             _Glossiness("Gloss", Range(0, 1)) = 1
             _Specular("Specular", Range(0,1)) = 1
         }
         SubShader {

          
             CGPROGRAM
             #pragma surface surf BlinnPhong

             
             struct Input {
                 float3 normal : NORMAL;
             };
    
         half _Glossiness;
         fixed4 _Color;
             half _Specular;
 
             void surf (Input IN, inout SurfaceOutput o) {
                 o.Albedo = _Color.rgb;
                 o.Specular = _Specular;
                 o.Gloss =  _Glossiness;

             }
             ENDCG
         }
         FallBack "Diffuse"
     }