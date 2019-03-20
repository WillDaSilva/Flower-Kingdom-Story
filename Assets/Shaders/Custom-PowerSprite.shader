Shader "Custom/PowerSprite"
{
	Properties
	{
		[PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
	AlphaCut("Alpha Cutoff", Float) = .5
	}

		SubShader
	{
		Tags
	{
		"Queue" = "Transparent"
		"IgnoreProjector" = "True"
		"RenderType" = "TransparentCutout"
		"PreviewType" = "Plane"
		//                      "CanUseSpriteAtlas"="True"
	}

		ZWrite On
		Cull Off
		Blend One OneMinusSrcAlpha

		CGPROGRAM
#pragma surface surf Lambert vertex:vert alphatest:AlphaCut

		sampler2D _MainTex;
	fixed AmbientResponse;
	fixed4 _RecolorA;
	fixed4 _RecolorB;

	struct Input
	{
		float2 uv_MainTex;
		fixed4 color;
	};

	void vert(inout appdata_full v, out Input o)
	{
		v.normal = float3(0,0,-1);
		UNITY_INITIALIZE_OUTPUT(Input, o);
		o.color = v.color;
	}

	void surf(Input IN, inout SurfaceOutput o)
	{
		fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * IN.color;
		o.Albedo = c.rgb * c.a;
		if (c.a < 0.5)
		{
			discard;
		}
		o.Alpha = c.a;
	}


	ENDCG
	}

		Fallback Off
}