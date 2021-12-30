Shader "CustomRenderTexture/Simple"
{
    Properties
    {
        _Tex("InputTex", 2D) = "white" {}
     }

     SubShader
     {
        Lighting Off
        Blend One Zero

        Pass
        {
            CGPROGRAM
            #include "UnityCustomRenderTexture.cginc"
            #pragma vertex CustomRenderTextureVertexShader
            #pragma fragment frag
            #pragma target 3.0

            sampler2D   _Tex;

            float4 frag(v2f_customrendertexture IN) : COLOR
            {
                return tex2D(_SelfTexture2D, IN.localTexcoord.xy +fixed2(1/_CustomRenderTextureWidth,0));
            }
            ENDCG
            }
    }
}