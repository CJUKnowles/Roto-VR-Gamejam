Shader "Custom/Pixelation" {
    Properties {
        _MainTex ("Texture", 2D) = "white" { }
        _PixelSize ("Pixel Size", Range(1, 100)) = 10
    }

    CGINCLUDE
    #include "UnityCG.cginc"
    CGINCLUDE

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG

            CGPROGRAM
            #pragma fragment frag
            ENDCG
        }
    }

    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            Name "OUTLINE"

            ZWrite On
            ZTest LEqual
            Offset 8,8

            ColorMask RGB
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Front

            CGPROGRAM
            #pragma vertex vert
            #pragma exclude_renderers gles xbox360 ps3
            ENDCG

            CGPROGRAM
            #pragma fragment frag
            ENDCG
        }
    }
}

// Vertex shader
void vert (inout appdata_full v, out Input o) {
    UNITY_INITIALIZE_OUTPUT(Input, o);
    UNITY_TRANSFER_FOG(o,o.vertex);
}

// Fragment shader
fixed4 frag (Input i) : COLOR {
    // Get the pixelation size
    float pixelSize = _PixelSize;

    // Calculate the pixelation coordinates
    float2 uv = i.uv;
    uv.x = floor(uv.x * (_ScreenParams.x / pixelSize)) / (_ScreenParams.x / pixelSize);
    uv.y = floor(uv.y * (_ScreenParams.y / pixelSize)) / (_ScreenParams.y / pixelSize);

    // Sample the color from the main texture
    fixed4 col = tex2D(_MainTex, uv);

    return col;
}