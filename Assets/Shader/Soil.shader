Shader "Custom/Soil"
{
   Properties
   {
       _MainTex("Texture", 2D) = "white" {}
       _WaterLevel("Water Level", Float) = 0.0
       _DarkenAmount("Darken Amount", Range(0, 1)) = 0.5
   }

      SubShader
       {
           Tags { "RenderType" = "Opaque" }

           CGPROGRAM
           #pragma surface surf Standard fullforwardshadows

           struct Input
           {
               float2 uv_MainTex;
           };

           sampler2D _MainTex;
           float _WaterLevel;
           float _DarkenAmount;

           void surf(Input IN, inout SurfaceOutputStandard o)
           {
              // Sample the texture
              fixed4 c = tex2D(_MainTex, IN.uv_MainTex);

              // Calculate the darken factor based on water level
              float darkenFactor = saturate((_WaterLevel - IN.uv_MainTex.y) / _WaterLevel) * _DarkenAmount;

              // Darken the color
              c.rgb *= (1 - darkenFactor);

              // Assign the final color
              o.Albedo = c.rgb;
              o.Alpha = c.a;
          }
          ENDCG
       }
          FallBack "Diffuse"
}
