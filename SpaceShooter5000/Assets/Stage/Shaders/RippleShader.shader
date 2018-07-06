Shader "Custom/RippleShaderi" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Color", Color) = (1,1,1,1)
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		_Scale ("Scale", float) = 1
		_Speed ("Speed", float) = 1
		_Frequency ("Frequency", float) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque"}
		LOD 200

		CGPROGRAM
		#pragma surface surf Standard Lambert vertex:vert

		sampler2D _MainTex;
		float _Scale, _Speed, _Frequency;
		half4 _Color;
		half _Glossiness;
		half _Metallic;

		struct Input {
			float2 uv_MainTex;
		};

		void vert(inout appdata_full v) {
			half offsetvert = (v.vertex.x * v.vertex.x) + (v.vertex.z * v.vertex.z);
			half value = _Scale * sin(_Time.w * _Speed + offsetvert * _Frequency);

			v.vertex.y += value;
		}

		void surf (Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
