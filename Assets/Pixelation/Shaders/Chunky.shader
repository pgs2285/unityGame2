Shader "Custom/ChunkyURP"
{
    Properties
    {
    _MainTex("Texture", 2D) = "white" {}
    _SprTex("Texture", 2D) = "white" {}
    }
        SubShader
    {
    Tags
    {
    "RenderType" = "Opaque"
    }
    Pass
    {
    HLSLPROGRAM
    #pragma vertex vert
    #pragma fragment frag
    #include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Core.hlsl"

        sampler2D _MainTex; // screen texture
        sampler2D _SprTex; // chunky texture

        float4 _Color = float4(1, 1, 1, 1); // screen brightness control

        float2 BlockCount; // number of blocks on the screen in Ox and Oy
        float2 BlockSize; // block size in the screen space

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

        v2f vert(appdata v)
        {
            v2f o;
            o.vertex = UnityObjectToClipPos(v.vertex);
            o.uv = v.uv;
            return o;
        }

        fixed4 frag(v2f i) : SV_Target
        {
            // (1)
            float2 blockPos = floor(i.uv * BlockCount);
            float2 blockCenter = blockPos * BlockSize + BlockSize * 0.5;

            // (2)
            float4 del = float4(1, 1, 1, 1) - _Color;

            // (3)
            float4 tex = tex2D(_MainTex, blockCenter) - del;
            float grayscale = dot(tex.rgb, float3(0.3, 0.59, 0.11));
            grayscale = clamp(grayscale, 0.0, 1.0);

            // (4)
            float dx = floor(grayscale * 16.0);

            // (5)
            float2 sprPos = i.uv;
            sprPos -= blockPos * BlockSize;
            sprPos.x /= 16;
            sprPos *= BlockCount;
            sprPos.x += 1.0 / 16.0 * dx;

            // (6)
            float4 tex2 = tex2D(_SprTex, sprPos);
            return tex2;
        }
        ENDHLSL
    }
    }
        FallBack "Diffuse"
}