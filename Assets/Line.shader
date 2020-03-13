Shader "Unlit/Line"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Edges ("Edge widths", Vector) = (0.25, 0.25, 0.75, 0.75)
	}
	SubShader
	{
		Tags 
		{ 
			"Queue"="Transparent" 
			"RenderType"="Transparent" 
		}
		LOD 100
        Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _Edges;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				col.a = 
					smoothstep(0, _Edges.x, i.uv.x) * 
					smoothstep(1, _Edges.z, i.uv.x) *
					smoothstep(0, _Edges.y, i.uv.y) *
					smoothstep(1, _Edges.w, i.uv.y);
				return col;
			}
			ENDCG
		}
	}
}
