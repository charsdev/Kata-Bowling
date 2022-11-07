// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/ToonShader" {
   Properties {
    _Color ("Diffuse Material Color", Color) = (1,1,1,1)
    _UnlitColor ("Unlit Color", Color) = (0.5,0.5,0.5,1)
    _DiffuseThreshold ("Lighting Threshold", Range(-1.1,1)) = 0.1
    _SpecColor ("Specular Material Color", Color) = (1,1,1,1)
    _Shininess ("Shininess", Range(0.5,1)) = 1 
    _OutlineThickness ("Outline Thickness", Range(0,1)) = 0.1
    _OutlineColor("Outline Color", Color) = (1,1,1,1)
    }
   
     SubShader {

     Pass {
        Tags{ "LightMode" = "ForwardBase" }
        // pass for ambient light and first light source
     
        CGPROGRAM
       
        #pragma vertex vert
		//Tells cg to use vertex shader called vert.
		
        #pragma fragment frag
        //tells cg to use fragment shader called frag.
            
        //Toon Shader Uniforms
        uniform float4 _Color;
        uniform float4 _UnlitColor;
        uniform float _DiffuseThreshold;
        uniform float4 _SpecColor;
        uniform float _Shininess;
        uniform float _OutlineThickness;
        uniform float4 _OutlineColor;

        uniform float4 _LightColor0;
        uniform sampler2D _MainTex;
        uniform float4 _MainTex_ST;            
       
        struct vertexInput { //<<<< makes Unity understand
              
        //- Toon Shader variables -
        float4 vertex : POSITION;
        float3 normal : NORMAL;
        float4 texcoord : TEXCOORD0;
                 
        };
       
        struct vertexOutput {
               
         float4 pos : SV_POSITION;
         float3 normalDir : TEXCOORD1;
         float4 lightDir : TEXCOORD2;
         float3 viewDir : TEXCOORD3;
         float2 uv : TEXCOORD0;
        };
        
     	//How the Toon Shader should respond to World Light
        vertexOutput vert(vertexInput input)
        {
                vertexOutput output;
               
                //normalDirection
                output.normalDir = normalize ( mul( float4( input.normal, 0.0 ), unity_WorldToObject).xyz );
               //Here we multiply float4, input normal and our World2Object to the World Space. After normalizing we get a normal direction unit vector.
	
				//Unity transform Position
				
				//World position
                float4 posWorld = mul(unity_ObjectToWorld, input.vertex);
               	//Multiply the Object with the Input vertex. Transform Local position into World Space. View Matrix is inverse transform of camera. And thus converses the World Space to a position in the Camera's local space.
		
				//View Direction
                output.viewDir = normalize( _WorldSpaceCameraPos.xyz - posWorld.xyz ); //vector from object to the camera
               //Take World Space Camera Position - POsition of the World which gives us a Vector from Object to Camera. Normalized to get a unit vector.
	
				//Light Direction
                float3 fragmentToLightSource = ( _WorldSpaceCameraPos.xyz - posWorld.xyz) ;
                output.lightDir = float4(
                        normalize( lerp(_WorldSpaceLightPos0.xyz , fragmentToLightSource, _WorldSpaceLightPos0.w) ),
                        lerp(1.0 , 1.0/length(fragmentToLightSource), _WorldSpaceLightPos0.w)
                );
               
                //fragmentInput output;
                output.pos = UnityObjectToClipPos( input.vertex );

                //UV-Map
                output.uv =input.texcoord;
               
                return output;
         
        }
       
        float4 frag(vertexOutput input) : COLOR
        {
 
        float nDotL = saturate(dot(input.normalDir, input.lightDir.xyz)); //nDotL = normalDir vector and the lightDir vector. Saturate makes the range from 0-1. nDotL
		                       
        //Diffuse Threshold calculation
        float diffuseCutoff = saturate( ( max(_DiffuseThreshold, nDotL) - _DiffuseThreshold ) *1000 ) ;
                       
        //Specular Threshold calculation
        float specularCutoff = saturate( max(_Shininess, dot(reflect(-input.lightDir.xyz, input.normalDir), input.viewDir))-_Shininess ) * 1000;
        //viewDir then makes it so the reflection moves around based on our camera's view while the shadow doens't.
		
		//Calculate Outlines
        float outlineStrength =  saturate((dot(input.normalDir, input.viewDir ) - _OutlineThickness) * 1000);
        //Inputnormal and InputView make it so it will ALWAYS follow the camera around.
                       
        float3 ambientLight = (1-diffuseCutoff) * _UnlitColor.xyz ; //Ambient Illumination
        float3 diffuseReflection = (1-specularCutoff) * _Color.xyz * diffuseCutoff ;
      	float3 specularReflection = _SpecColor.xyz * specularCutoff;
        float3 combinedLight = (ambientLight + diffuseReflection  ) * outlineStrength  + specularReflection;
                   
        return float4(combinedLight, 1.0);
               
        }
       
        ENDCG
      }


    
   }
 
}