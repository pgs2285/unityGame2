Shader "Custom/ScreenEdgeShader" {
    Properties{
        _MainTex("Texture", 2D) = "white" {}
        _EdgeColor("Edge Color", Color) = (0,0,0,1)
        _EdgeWidth("Edge Width", Range(0, 0.1)) = 0.02
    }
        

        SubShader{

            Tags { "RenderType" = "Opaque" }

            Pass {
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
                float4 _EdgeColor;
                float _EdgeWidth;

                v2f vert(appdata v) {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target {
                    float2 uv = i.uv;
                    float4 col = tex2D(_MainTex, uv);
                    float2 dist = float2(ddx(uv.x), ddy(uv.y));
                    float edge = 1 - length(dist);
                    col.rgb += _EdgeColor.rgb * smoothstep(_EdgeWidth, 0, edge);
                    return col;
                }
                ENDCG
            }
        }
            FallBack "Diffuse"
}
