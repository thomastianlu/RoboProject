Shader "Custom/OutlineShader"{

	// Variables
	Properties{
		_MainTexture("Main Color (RGB)", 2D) = "white" {}
		_Color("Color", Color) = (1, 1, 1, 1)

		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(0, 0.1)) = .05
	}

	SubShader{
		// Regular Diffuse Pass
		Pass{

			CGPROGRAM

			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction
			#include "UnityCG.cginc"

			uniform float4 _Color;
			uniform float4 _MainText_ST;
			sampler2D _MainTexture;

			struct appdata {
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float4 position : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			// Build out vertex
			v2f vertexFunction(appdata IN){

				v2f OUT;

				OUT.position = mul(UNITY_MATRIX_MVP, IN.vertex);
				OUT.uv = IN.uv;

				return OUT;
			}

			// Color
			fixed4 fragmentFunction(v2f IN) : SV_Target{
				
				float4 textureColor = tex2D(_MainTexture, IN.uv);

				return textureColor * _Color;
			}

			ENDCG
		}

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