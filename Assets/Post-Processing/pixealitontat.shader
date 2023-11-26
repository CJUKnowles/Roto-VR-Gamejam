Shader "Custom/PixelationPostProcess" {
    SubShader {
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
}

// Vertex shader
void vert (inout appdata_full v, out Input o) {
    UNITY_INITIALIZE_OUTPUT(Input, o);
    UNITY_TRANSFER_FOG(o,o.vertex);
}

// Fragment shader
fixed4 frag (Input i) : COLOR {
    // Pixelation effect, replace with your own shader logic
    fixed4 col = tex2D(_CameraColorTexture, i.uv);
    col.rgb = floor(col.rgb * 10) / 10; // Pixelation factor

    return col;
}
