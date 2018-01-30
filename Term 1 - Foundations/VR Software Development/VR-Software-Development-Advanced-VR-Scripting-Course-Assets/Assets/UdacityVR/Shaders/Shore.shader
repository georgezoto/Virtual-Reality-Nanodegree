﻿Shader "Shore" 
{
	SubShader 
	{
		Pass 
		{
			Fog { Mode Off } 
			Lighting On
			ZTest Less
			ZWrite On
			Cull Back
			
			//Blend SrcColor DstAlpha
			
			Offset 0, 0
			GLSLPROGRAM

			#include "UnityCG.glslinc"


			#ifdef VERTEX

//			#define gl_TexCoord _glesTexCoord;
			
//			varying highp vec4 _glesTexCoord[1];
//			uniform vec4 _Time;
//			uniform mat4x4 _Object2World;
//			uniform vec4 _WorldSpaceCameraPos;
//			uniform vec4 _WorldSpaceLightPos0;

			#include "Includes/Maps/terrain.glslinc"


			float map(vec3 position)
			{
				float bowl			= length(position.xz) * .2;
				
				vec2 wave_position	= position.xz;
				position.xz			*= 2.;
				position.xz 		+= vec2(8., 12.);
				float t				= _Time.x * 14.;
			
				float waves 	=  voronoi(position.xz * 3.  + vec2(1., 4.) - t * .125) * .35;
				waves			+= voronoi(position.xz * 4.  -        waves + t * .45)  * .85 - waves  * .5;
				waves			+= voronoi(position.xz * 12. +        waves - t * .25) * .126 - waves * .5;
				waves 			= (sin(waves)+1.)*.0425-.1;
				waves 			*= (1.-waves);
				waves			+= bowl;
				return waves;
			}


			vec3 derive_axis(in vec3 position, in float delta)
			{
				vec3 derivative		= vec3(0.);
				vec2 offset			= vec2(.0, delta);
			
				derivative.x		= map(position + offset.yxx) - map(position - offset.yxx);
				derivative.y		= map(position + offset.xyx) - map(position - offset.xyx);
				derivative.z		= map(position + offset.xxy) - map(position - offset.xxy);
				return derivative;
			} 


			float fresnel(const in float i, const in float ndl)
			{   
				return i + (1.-i) * pow((1.-ndl), 5.0);
			}

			float distribution(const in float r, const in float ndh)
			{ 
				float alpha = r * r;
				float denom = ndh * ndh * (alpha - 1.) + 1.;
				return alpha / (3.14 * denom * denom);
			}
			
			uniform vec4 _LightColor0; 
			varying vec4 _FragCoord;
			varying vec4 _Color;

			void main()
			{	
				_FragCoord				= gl_MultiTexCoord0;
				
				vec3 position			= gl_MultiTexCoord0.xzy - .5;
				position.y 				= 0.;

				float waves				= map(position);

				gl_Position				= gl_Vertex;//;
				vec3 gradient			= derive_axis(position, .00625);
				gradient.xz				*= -1.;
				gradient.y				= waves * .0175;

				gl_Position.xyz			-= gradient;

				vec3 normal				= normalize(gradient);
			
				gl_Position.y			+= waves;

				vec3 world_position		= (_Object2World * gl_Position).xyz;
				gl_Position				= gl_ModelViewProjectionMatrix * gl_Position;
				vec3 direction			= normalize(-_WorldSpaceCameraPos.xyz - world_position);
				
				vec3 light_position		= normalize(_WorldSpaceLightPos0.xyz)*8192.;

				vec3 light_direction	= normalize(world_position - light_position);

				vec3 half_direction		= normalize(light_direction + direction);

				float ndl				= max(dot(normal, light_direction), 0.);
				float ndh				= max(dot(normal,  half_direction), 0.);


				float diffuse			= distribution( .8, max(ndl, 0.));
				float specular			= distribution(.15, max(ndh, 0.));
				float light_incidence	= max(fresnel(.125, ndh), 0.);
				float view_incidence	= max(dot(normal, direction), -1.);
				float depth				= length(world_position-_WorldSpaceCameraPos.xyz);

				vec3 color				= vec3(.15, .3285,.5) * 1.6;
				color					+= diffuse				* _LightColor0.xyz;
				color					+= specular 			* .25;
				color					+= light_incidence 		* .25;
				color					+= (1.-view_incidence) 	* _LightColor0.xyz + depth*.01625;
				color					+= diffuse * pow(max(view_incidence, .04), depth * 2.) ;
				color					*= clamp(depth, 0., .75);
					
				float opacity			= 1.-(1.5 * depth * view_incidence)/depth;
				opacity					+= depth * gl_Position.w * 128.;
				opacity					-= light_incidence 	* .95;

				_Color					= clamp(vec4(color, opacity), 0., 1.);
			}
			#endif

			#ifdef FRAGMENT
			varying vec4 	_FragCoord;
			varying vec4 	_Color;

			void main(void) 
			{
				gl_FragColor 	= _Color;
			}//sphinx
			#endif 
			ENDGLSL 
		} 
	}
}