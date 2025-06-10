Shader "Custom/2DOutlineURP"
{
    Properties
    {
        _MainTex("Main Texture", 2D) = "white" {}
        _Color("Base Color", Color) = (1,1,1,1)
        _OutlineColor("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth("Outline Width", Range(0,10)) = 2
    }

    SubShader
    {
        Tags { "RenderPipeline"="UniversalPipeline" "Queue"="Transparent" "RenderType"="Transparent" }
        LOD 100
        Blend SrcAlpha OneMinusSrcAlpha
        Cull Off
        ZWrite Off

        Pass
        {
            Name "2DOutlinePass"
            Tags { "LightMode" = "UniversalForward" }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 position : SV_POSITION;
                float2 uv : TEXCOORD0;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float4 _Color;
            float4 _OutlineColor;
            float _OutlineWidth;
            float4 _ScreenParams;

            v2f vert(appdata v)
            {
                v2f o;
                o.position = TransformObjectToHClip(v.vertex.xyz);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            float SampleAlpha(float2 uv)
            {
                return tex2D(_MainTex, uv).a;
            }

            half4 frag(v2f i) : SV_Target
            {
                float2 uv = i.uv;
                float2 texelSize = float2(_OutlineWidth / _ScreenParams.x, _OutlineWidth / _ScreenParams.y);

                float alpha = SampleAlpha(uv);

                // Outline sampling (8 directions)
                float outline = 0;
                outline += SampleAlpha(uv + texelSize * float2( 1,  0));
                outline += SampleAlpha(uv + texelSize * float2(-1,  0));
                outline += SampleAlpha(uv + texelSize * float2( 0,  1));
                outline += SampleAlpha(uv + texelSize * float2( 0, -1));
                outline += SampleAlpha(uv + texelSize * float2( 1,  1));
                outline += SampleAlpha(uv + texelSize * float2(-1,  1));
                outline += SampleAlpha(uv + texelSize * float2( 1, -1));
                outline += SampleAlpha(uv + texelSize * float2(-1, -1));
                outline /= 8;

                if (alpha < 0.1 && outline > 0.1)
                {
                    return _OutlineColor;
                }

                half4 col = tex2D(_MainTex, uv) * _Color;
                return col;
            }
            ENDHLSL
        }
    }
}
