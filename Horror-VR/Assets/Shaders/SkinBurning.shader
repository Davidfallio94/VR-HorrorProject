// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/SkinBurning"
{
	Properties{
		_MainTex("Main texture", 2D) = "white" {}
	_DissolveTex("Dissolution texture", 2D) = "gray" {}
	_Threshold("Threshold", Range(0, 1.1)) = 0
	}

		SubShader{

		Tags{ "Queue" = "Geometry" }
		Tags{ "LightMode" = "ForwardBase" }

		Pass{

		CGPROGRAM
#pragma vertex vert
#pragma fragment frag

#include "UnityCG.cginc"

		struct v2f {
		float4 pos : SV_POSITION;
		float2 uv : TEXCOORD0;
		float3 normal : NORMAL;
	};

	sampler2D _MainTex;
	float4 _MainTex_ST;

	v2f vert(appdata_base v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);
		o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
		o.normal = normalize(mul(v.normal, unity_WorldToObject).xyz);
		return o;
	}

	sampler2D _DissolveTex;
	float _Threshold;

	fixed4 _LightColor0;
	fixed4 frag(v2f i) : SV_Target{
		fixed4 c = tex2D(_MainTex, i.uv);
	fixed val = 1 - tex2D(_DissolveTex, i.uv).r;
	
	if (val < _Threshold - 0.04)
	{
		discard;
	}

	bool b = val < _Threshold;
	return lerp(c, c * fixed4(lerp(1, 0, 1 - saturate(abs(_Threshold - val) / 0.04)), 0, 0, 1), b);
	float dif = max(0.0, dot(i.normal, normalize(_WorldSpaceLightPos0.xyz)));
	fixed4 col = tex2D(_MainTex, i.uv);
	return fixed4(col.rgb * dif * _LightColor0.rgb, 1);
	}


		ENDCG

	}

	}
		FallBack "Diffuse"
}