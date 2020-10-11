// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

 
Shader "Element/RadioTextureBlend"
{
    Properties
    {
        _MainTex ("Main Texture", 2D) = "white" {}
        _SecondTex ("Second Texture", 2D) = "black" {}
        _Radius ("Radius", Float) = 0
        _MyWorldPos ("my World Position", Vector) = (0, 0, 0, 0)
        _TargetPos ("Target World Position", Vector) = (0, 0, 0, 0)
       
    }
 
    SubShader {
        Pass
        {
            Tags {"Queue" = "Geometry"}
 
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
           
            #include "UnityCG.cginc"
 
            uniform sampler2D _MainTex;
            uniform float4 _MainTex_ST;
            uniform sampler2D _SecondTex;
            uniform float4 _SecondTex_ST;
           
            uniform float4 _MyWorldPos;
            uniform float4 _TargetPos;
            uniform float _Radius;
           
            struct vertexInput
            {
                float4 vertex : POSITION;
                float4 texcoord : TEXCOORD0;
            };
           
            struct fragmentInput
            {
                float4 pos : SV_POSITION;
                half2 uv : TEXCOORD0;
                half2 uv2 : TEXCOORD1;
                float3 posW : TEXCOORD2;
            };
           
            fragmentInput vert(vertexInput i)
            {
                fragmentInput o;
                o.pos = UnityObjectToClipPos(i.vertex);
                o.uv = TRANSFORM_TEX(i.texcoord, _MainTex);
                o.uv2 = TRANSFORM_TEX(i.texcoord, _SecondTex);                
                o.posW = mul(unity_ObjectToWorld ,i.vertex).xyz;
               
                return o;
            }
           
            half4 frag(fragmentInput i) : COLOR
            {
                float dist = distance(i.posW, _TargetPos.xyz);
                if(dist - _Radius >= 0)
                {
                    return tex2D(_MainTex, i.uv);
                }
                else
                {
                    return tex2D(_SecondTex, i.uv2);
                }
            }
           
            ENDCG
        }
    }
}
 