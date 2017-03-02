Shader "Custom/OutlineShader"{

	// Variables
	Properties{
		_MainTexture("Main Color (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)

		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(0, 0.1)) = .05
	}

	SubShader{
		Tags{ "RenderType" = "Opaque" }
		LOD 200
		// Regular Diffuse Pass
		CGPROGRAM

		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Standard fullforwardshadows

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTexture;

		struct Input {
			float2 uv_MainTex;
		};

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		void surf(Input IN, inout SurfaceOutputStandard o) {
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D(_MainTexture, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		}

		ENDCG

		// Outline Pass
		Tags { "RenderType" = "Opaque"}
		Pass {
			Cull Front

			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction
			#include "UnityCG.cginc"

			uniform float _Outline;
			uniform float4 _OutlineColor;
			uniform float4 _MainText_ST;
			uniform sampler2D _MainTexture;

			struct v2f {
				float4 pos : POSITION;
				float4 color : COLOR;
			};

			v2f vertexFunction(appdata_base IN)
			{
				v2f OUT;
				OUT.pos = mul(UNITY_MATRIX_MVP, IN.vertex);
				float3 norm = mul((float3x3)UNITY_MATRIX_IT_MV, IN.normal);
				float2 offset = TransformViewToProjection(norm.xy);
				OUT.pos.xy += offset  * _Outline;
				OUT.color = _OutlineColor;
				return OUT;
			}

			half4 fragmentFunction(v2f IN) :COLOR
			{
				return IN.color;
			}

			ENDCG
		}

	}
	Fallback "Diffuse"
}