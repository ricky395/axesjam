// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "_ECDS_HD/Particles/Blend Additive"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("Color", Color) = (0,0,0,0)
	

	}
	SubShader
	{
		Tags {	"RenderType"="Transparent" 
				"Queue"="Transparent"
				"IgnoreProjector" = "True"
				"PreviewType" = "Plane"
			}

		LOD 100

		Pass
		{

			Cull Off
			Lighting Off
			Zwrite Off
			//Blend SrcAlpha OneMinusSrcAlpha
			Blend SrcAlpha One

			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma multi_compile _ LOD_FADE_CROSSFADE
		
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 pos : SV_POSITION;

			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Color;
			
			v2f vert (appdata v)
			{
				v2f o;

				o.pos = UnityObjectToClipPos(v.vertex);				
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv) * _Color;
				#ifdef LOD_FADE_CROSSFADE
				col.a *= unity_LODFade.x;
				#endif
				return col;
			}
			ENDCG
		}
	}
}
