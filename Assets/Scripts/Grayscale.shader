Shader "Custom/Grayscale" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _Color("Tint", Color) = (1,1,1,1)
    }

        SubShader{
            Tags {"Queue" = "Transparent" "RenderType" = "Transparent"}
            LOD 100

            Pass {
                ZWrite Off
                Blend SrcAlpha OneMinusSrcAlpha

                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f {
                    float2 uv : TEXCOORD0;
                    float4 vertex : SV_POSITION;
                };

                sampler2D _MainTex;
                float4 _MainTex_ST;
                float4 _Color;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    fixed4 tex = tex2D(_MainTex, i.uv);
                    float grayscale = dot(tex.rgb, float3(0.299, 0.587, 0.114));
                    fixed4 color = lerp(fixed4(grayscale, grayscale, grayscale, tex.a), _Color, _Color.a);
                    return color;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
