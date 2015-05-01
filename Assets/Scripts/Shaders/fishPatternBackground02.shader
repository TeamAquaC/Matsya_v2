Shader "fishPatternBackground02" {
 
Properties {
    _Color ("Main Color (A=Opacity)", Color) = (1,1,1,1)
    _MainTex ("Base (A=Opacity)", 2D) = ""
}

Category {
    Tags {"Queue"="Geometry-70"}
    ZWrite Off
	Blend SrcAlpha OneMinusSrcAlpha
 
   SubShader {Pass {
        GLSLPROGRAM
        varying mediump vec2 uv;
       
        #ifdef VERTEX
        uniform mediump vec4 _MainTex_ST;
        void main() {
            gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
            uv = gl_MultiTexCoord0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
        }
        #endif
       
        #ifdef FRAGMENT
        uniform lowp sampler2D _MainTex;
        uniform lowp vec4 _Color;
        void main() {
            gl_FragColor = texture2D(_MainTex, uv) * _Color;
        }
        #endif     
        ENDGLSL
    }}
   
    SubShader {Pass {
        SetTexture[_MainTex] {Combine texture * constant ConstantColor[_Color]}
    }}
    
  }

SubShader {
      Tags { "Queue" = "Geometry-80" }
      CGPROGRAM
      #pragma surface surf Lambert
      struct Input {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb;
      }
      ENDCG
    } 
    Fallback "Diffuse"
  
  }
