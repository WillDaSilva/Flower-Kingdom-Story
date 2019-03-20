Shader "UnlitShadows/UnlitShadowCastCutout" {
	Properties{
		_Color("Main Color", Color) = (1,1,1,1)
		_MainTex("Base (RGB)", 2D) = "white" {}
	_Cutoff("Alpha Cutoff", Range(0,1)) = 0.1
	}
		SubShader{
		Pass{ Alphatest Greater[_Cutoff] Cull Off SetTexture[_MainTex] }
	}
		Fallback "Transparent/Cutout/VertexLit"
}