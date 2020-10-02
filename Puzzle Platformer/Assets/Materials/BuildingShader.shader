// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

Shader "Custom/BuildingShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _EmissionTex ("Emission (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0
        _Scale ("Texture Scale", Range(0,1)) = 0.1
        _Intensity("Emission Intensity", Float) = 2
        _BRDF("BRDF Ramp", 2D) = "gray" {}
        _LightIntensity("Light Intensity", Float) = 200
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Ramp

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _EmissionTex;

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float _Scale;
        float _Intensity;
        float _LightIntensity;

        sampler2D _BRDF;

        half4 LightingRamp(SurfaceOutput s, half3 lightDir, half3 viewDir, half atten) {

            // Calculate dot product of light direction and surface normal
            // 1.0 = facing each other perfectly
            // 0.0 = right angles
            // -1.0 = parallel, facing same direction
            half NdotL = dot(s.Normal, lightDir);

            // NdotL lies in the range between -1.0 and 1.0
            // To use as a texture lookup we need to adjust to lie in the range 0.0 to 1.0
            // We could simply clamp it, but instead we'll apply softer "half" lighting
            // (which Unity calls "Diffuse Wrap")
            NdotL = NdotL * 0.5 + 0.5, 0, 1;

            // Calculate dot product of view direction and surface normal
            // Note that, since we only render front-facing normals, this will
            // always be positive
            half NdotV = dot(s.Normal, viewDir);

            // Lookup the corresponding colour from the BRDF texture map
            half3 brdf = tex2D(_BRDF, float2(NdotL, NdotV)).rgb;

            half4 c;

            // For illustrative purpsoes, let's set the pixel colour based entirely on the BRDF texture
            // In practice, you'd normally also have Albedo and lightcolour terms here too. 
            c.rgb = s.Albedo + _LightColor0.rgb * brdf * (atten * _LightIntensity);
            c.a = s.Alpha;
            return c;
        }

        struct Input
        {
            float3 worldNormal;
            float3 worldPos;
            float2 uv_MainTex;
        };

        float random(float2 p)
        {
            // e^pi (Gelfond's constant)
            // 2^sqrt(2) (Gelfond–Schneider constant)
            float2 K1 = float2(23.14069263277926, 2.665144142690225);

            //return fract( cos( mod( 12345678., 256. * dot(p,K1) ) ) ); // ver1
            //return fract(cos(dot(p,K1)) * 123456.); // ver2
            return frac(cos(dot(p, K1)) * 12345.6789); // ver3
        }

        void surf (Input IN, inout SurfaceOutput o)
        {
            float2 UV;
            fixed4 c;
            fixed4 e;

            float3 worldScale = float3(
                length(float3(unity_ObjectToWorld[0].x, unity_ObjectToWorld[1].x, unity_ObjectToWorld[2].x)), // scale x axis
                length(float3(unity_ObjectToWorld[0].y, unity_ObjectToWorld[1].y, unity_ObjectToWorld[2].y)), // scale y axis
                length(float3(unity_ObjectToWorld[0].z, unity_ObjectToWorld[1].z, unity_ObjectToWorld[2].z))  // scale z axis
                );

            float4 objectOrigin = mul(unity_ObjectToWorld, float4(0.0, 0.0, 0.0, 1.0));
            float2 randPos = float2(random(objectOrigin.xz), random(objectOrigin.xz)) * 200.0;
            float3 pos = mul(unity_WorldToObject, IN.worldPos) * worldScale;
            float3 norm = normalize(mul(unity_WorldToObject, IN.worldNormal));

            if (abs(norm.x) > 0.5) {
                UV = pos.yz + randPos;
                c = tex2D(_MainTex, UV * _Scale);
                e = tex2D(_EmissionTex, UV * _Scale);
            }
            else if (abs(norm.z) > 0.5) {
                UV = pos.xy + randPos;
                c = tex2D(_MainTex, UV * _Scale);
                e = tex2D(_EmissionTex, UV * _Scale);
            }
            else{
                UV = pos.xz + randPos;
                c = tex2D(_MainTex, UV * _Scale);
                e = tex2D(_EmissionTex, UV * _Scale);
            }

            o.Albedo = c.rgb * _Color;
            o.Emission = c.rgb + e.rgb * _Color * _Intensity;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
