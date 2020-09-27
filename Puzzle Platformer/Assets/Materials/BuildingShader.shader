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
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;
        sampler2D _EmissionTex;

        struct Input
        {
            float3 worldNormal;
            float3 worldPos;
            float2 uv_MainTex;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;
        float _Scale;
        float _Intensity;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float rand(float3 myVector) {
            return frac(sin(dot(myVector, float3(12.9898, 78.233, 45.5432))) * 43758.5453);
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            float2 UV;
            fixed4 c;
            fixed4 e;

            float3 worldScale = float3(
                length(float3(unity_ObjectToWorld[0].x, unity_ObjectToWorld[1].x, unity_ObjectToWorld[2].x)), // scale x axis
                length(float3(unity_ObjectToWorld[0].y, unity_ObjectToWorld[1].y, unity_ObjectToWorld[2].y)), // scale y axis
                length(float3(unity_ObjectToWorld[0].z, unity_ObjectToWorld[1].z, unity_ObjectToWorld[2].z))  // scale z axis
                );

            float2 randPos = float2(rand(15), rand(8)) * 1;
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
