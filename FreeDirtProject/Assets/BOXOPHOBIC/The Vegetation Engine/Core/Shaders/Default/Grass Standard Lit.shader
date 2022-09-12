// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "BOXOPHOBIC/The Vegetation Engine/Default/Grass Standard Lit"
{
	Properties
	{
		[StyledCategory(Render Settings, 5, 10)]_CategoryRender("[ Category Render ]", Float) = 0
		[Enum(Opaque,0,Transparent,1)]_RenderMode("Render Mode", Float) = 0
		[Enum(Off,0,On,1)]_RenderZWrite("Render ZWrite", Float) = 1
		[Enum(Both,0,Back,1,Front,2)]_RenderCull("Render Faces", Float) = 0
		[Enum(Flip,0,Mirror,1,Same,2)]_RenderNormals("Render Normals", Float) = 0
		[HideInInspector]_RenderQueue("Render Queue", Float) = 0
		[HideInInspector]_RenderPriority("Render Priority", Float) = 0
		[Enum(Off,0,On,1)]_RenderSpecular("Render Specular", Float) = 1
		[Enum(Off,0,On,1)]_RenderDecals("Render Decals", Float) = 0
		[Enum(Off,0,On,1)]_RenderSSR("Render SSR", Float) = 0
		[Space(10)]_RenderDirect("Render Direct", Range( 0 , 1)) = 1
		_RenderShadow("Render Shadow", Range( 0 , 1)) = 1
		_RenderAmbient("Render Ambient", Range( 0 , 1)) = 1
		[Enum(Off,0,On,1)][Space(10)]_RenderClip("Alpha Clipping", Float) = 1
		[Enum(Off,0,On,1)]_RenderCoverage("Alpha To Mask", Float) = 0
		_AlphaClipValue("Alpha Treshold", Range( 0 , 1)) = 0.5
		_AlphaFeatherValue("Alpha Feather", Range( 0 , 2)) = 0.5
		[StyledSpace(10)]_SpaceRenderFade("# Space Render Fade", Float) = 0
		[StyledCategory(Global Settings)]_CategoryGlobal("[ Category Global ]", Float) = 0
		[StyledEnum(TVELayers, Default 0 Layer_1 1 Layer_2 2 Layer_3 3 Layer_4 4 Layer_5 5 Layer_6 6 Layer_7 7 Layer_8 8, 0, 0)]_LayerColorsValue("Layer Colors", Float) = 0
		[StyledEnum(TVELayers, Default 0 Layer_1 1 Layer_2 2 Layer_3 3 Layer_4 4 Layer_5 5 Layer_6 6 Layer_7 7 Layer_8 8, 0, 0)]_LayerExtrasValue("Layer Extras", Float) = 0
		[StyledEnum(TVELayers, Default 0 Layer_1 1 Layer_2 2 Layer_3 3 Layer_4 4 Layer_5 5 Layer_6 6 Layer_7 7 Layer_8 8, 0, 0)]_LayerMotionValue("Layer Motion", Float) = 0
		[StyledEnum(TVELayers, Default 0 Layer_1 1 Layer_2 2 Layer_3 3 Layer_4 4 Layer_5 5 Layer_6 6 Layer_7 7 Layer_8 8, 0, 0)]_LayerVertexValue("Layer Vertex", Float) = 0
		[StyledSpace(10)]_SpaceGlobalLayers("# Space Global Layers", Float) = 0
		[StyledMessage(Info, Procedural Variation in use. The Variation might not work as expected when switching from one LOD to another., _VertexVariationMode, 1 , 0, 10)]_MessageGlobalsVariation("# Message Globals Variation", Float) = 0
		_GlobalColors("Global Color", Range( 0 , 1)) = 1
		_GlobalAlpha("Global Alpha", Range( 0 , 1)) = 1
		_GlobalOverlay("Global Overlay", Range( 0 , 1)) = 1
		_GlobalWetness("Global Wetness", Range( 0 , 1)) = 1
		_GlobalEmissive("Global Emissive", Range( 0 , 1)) = 1
		_GlobalSize("Global Size Fade", Range( 0 , 1)) = 1
		[StyledSpace(10)]_SpaceGlobalLocals("# Space Global Locals", Float) = 0
		[StyledRemapSlider(_ColorsMaskMinValue, _ColorsMaskMaxValue, 0, 1)]_ColorsMaskRemap("Color Mask", Vector) = (0,0,0,0)
		[HideInInspector]_ColorsMaskMinValue("Color Mask Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_ColorsMaskMaxValue("Color Mask Max Value", Range( 0 , 1)) = 0
		_ColorsVariationValue("Color Variation", Range( 0 , 1)) = 0
		[StyledRemapSlider(_AlphaMaskMinValue, _AlphaMaskMaxValue, 0, 1, 10, 0)]_AlphaMaskRemap("Alpha Mask", Vector) = (0,0,0,0)
		_AlphaVariationValue("Alpha Variation", Range( 0 , 1)) = 1
		[StyledRemapSlider(_OverlayMaskMinValue, _OverlayMaskMaxValue, 0, 1)]_OverlayMaskRemap("Overlay Mask", Vector) = (0,0,0,0)
		[HideInInspector]_OverlayMaskMinValue("Overlay Mask Min Value", Range( 0 , 1)) = 0.45
		[HideInInspector]_OverlayMaskMaxValue("Overlay Mask Max Value", Range( 0 , 1)) = 0.55
		_OverlayVariationValue("Overlay Variation", Range( 0 , 1)) = 0
		[StyledSpace(10)]_SpaceGlobalPosition("# Space Global Position", Float) = 0
		[StyledToggle]_ColorsPositionMode("Use Pivot Position for Colors", Float) = 0
		[StyledToggle]_ExtrasPositionMode("Use Pivot Position for Extras", Float) = 0
		[StyledCategory(Main Settings)]_CategoryMain("[Category Main ]", Float) = 0
		[NoScaleOffset][StyledTextureSingleLine]_MainAlbedoTex("Main Albedo", 2D) = "white" {}
		[NoScaleOffset][StyledTextureSingleLine]_MainNormalTex("Main Normal", 2D) = "bump" {}
		[NoScaleOffset][StyledTextureSingleLine]_MainMaskTex("Main Mask", 2D) = "white" {}
		[Space(10)][StyledVector(9)]_MainUVs("Main UVs", Vector) = (1,1,0,0)
		[HDR]_MainColor("Main Color", Color) = (1,1,1,1)
		_MainNormalValue("Main Normal", Range( -8 , 8)) = 1
		_MainOcclusionValue("Main Occlusion", Range( 0 , 1)) = 0
		_MainSmoothnessValue("Main Smoothness", Range( 0 , 1)) = 0
		[StyledCategory(Detail Settings)]_CategoryDetail("[ Category Detail ]", Float) = 0
		[Enum(Off,0,On,1)]_DetailMode("Detail Mode", Float) = 0
		[Enum(Overlay,0,Replace,1)]_DetailBlendMode("Detail Blend", Float) = 1
		[Enum(Vertex Blue,0,Projection,1)]_DetailTypeMode("Detail Type", Float) = 0
		[StyledRemapSlider(_DetailBlendMinValue, _DetailBlendMaxValue,0,1)]_DetailBlendRemap("Detail Blending", Vector) = (0,0,0,0)
		[StyledCategory(Occlusion Settings)]_CategoryOcclusion("[ Category Occlusion ]", Float) = 0
		[HDR]_VertexOcclusionColor("Vertex Occlusion Color", Color) = (1,1,1,1)
		[StyledRemapSlider(_VertexOcclusionMinValue, _VertexOcclusionMaxValue, 0, 1)]_VertexOcclusionRemap("Vertex Occlusion Mask", Vector) = (0,0,0,0)
		[HideInInspector]_VertexOcclusionMinValue("Vertex Occlusion Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_VertexOcclusionMaxValue("Vertex Occlusion Max Value", Range( 0 , 1)) = 1
		[StyledCategory(Subsurface Settings)]_CategorySubsurface("[ Category Subsurface ]", Float) = 0
		_SubsurfaceValue("Subsurface Intensity", Range( 0 , 1)) = 1
		[HDR]_SubsurfaceColor("Subsurface Color", Color) = (0.4,0.4,0.1,1)
		[StyledRemapSlider(_SubsurfaceMaskMinValue, _SubsurfaceMaskMaxValue,0,1)]_SubsurfaceMaskRemap("Subsurface Mask", Vector) = (0,0,0,0)
		[HideInInspector]_SubsurfaceMaskMinValue("Subsurface Mask Min Value", Range( 0 , 1)) = 0
		[HideInInspector]_SubsurfaceMaskMaxValue("Subsurface Mask Max Value", Range( 0 , 1)) = 1
		[Space(10)][DiffusionProfile]_SubsurfaceDiffusion("Subsurface Diffusion", Float) = 0
		[HideInInspector] _texcoord( "", 2D ) = "white" {}
		[HideInInspector]_SubsurfaceDiffusion_Asset("Subsurface Diffusion", Vector) = (0,0,0,0)
		[HideInInspector][Space(10)][ASEDiffusionProfile(_SubsurfaceDiffusion)]_SubsurfaceDiffusion_asset("Subsurface Diffusion", Vector) = (0,0,0,0)
		[Space(10)]_SubsurfaceScatteringValue("Subsurface Scattering", Range( 0 , 16)) = 2
		_SubsurfaceAngleValue("Subsurface Angle", Range( 1 , 16)) = 8
		_SubsurfaceNormalValue("Subsurface Normal", Range( 0 , 1)) = 0
		_SubsurfaceDirectValue("Subsurface Direct", Range( 0 , 1)) = 1
		_SubsurfaceAmbientValue("Subsurface Ambient", Range( 0 , 1)) = 0.2
		_SubsurfaceShadowValue("Subsurface Shadow", Range( 0 , 1)) = 1
		[StyledCategory(Gradient Settings)]_CategoryGradient("[ Category Gradient ]", Float) = 0
		[HDR]_GradientColorOne("Gradient Color One", Color) = (1,1,1,1)
		[HDR]_GradientColorTwo("Gradient Color Two", Color) = (1,1,1,1)
		[StyledRemapSlider(_GradientMinValue, _GradientMaxValue, 0, 1)]_GradientMaskRemap("Gradient Mask", Vector) = (0,0,0,0)
		[HideInInspector]_GradientMinValue("Gradient Mask Min", Range( 0 , 1)) = 0
		[HideInInspector]_GradientMaxValue("Gradient Mask Max ", Range( 0 , 1)) = 1
		[StyledCategory(Noise Settings)]_CategoryNoise("[ Category Noise ]", Float) = 0
		[StyledRemapSlider(_NoiseMinValue, _NoiseMaxValue, 0, 1)]_NoiseMaskRemap("Noise Mask", Vector) = (0,0,0,0)
		[StyledCategory(Emissive Settings)]_CategoryEmissive("[ Category Emissive]", Float) = 0
		[NoScaleOffset][Space(10)][StyledTextureSingleLine]_EmissiveTex("Emissive Texture", 2D) = "white" {}
		[Space(10)][StyledVector(9)]_EmissiveUVs("Emissive UVs", Vector) = (1,1,0,0)
		[Enum(None,0,Any,10,Baked,20,Realtime,30)]_EmissiveFlagMode("Emissive Baking", Float) = 0
		[HDR]_EmissiveColor("Emissive Color", Color) = (0,0,0,0)
		[StyledEmissiveIntensity]_EmissiveIntensityParams("Emissive Intensity", Vector) = (1,1,1,0)
		[StyledCategory(Perspective Settings)]_CategoryPerspective("[ Category Perspective ]", Float) = 0
		_PerspectivePushValue("Perspective Push", Range( 0 , 4)) = 0
		_PerspectiveNoiseValue("Perspective Noise", Range( 0 , 4)) = 0
		_PerspectiveAngleValue("Perspective Angle", Range( 0 , 8)) = 1
		[StyledCategory(Size Fade Settings)]_CategorySizeFade("[ Category Size Fade ]", Float) = 0
		[StyledMessage(Info, The Size Fade feature is recommended to be used to fade out vegetation at a distance in combination with the LOD Groups or with a 3rd party culling system., _SizeFadeMode, 1, 0, 10)]_MessageSizeFade("# Message Size Fade", Float) = 0
		[Enum(Off,0,On,1)]_SizeFadeMode("Size Fade Mode", Float) = 0
		_SizeFadeStartValue("Size Fade Start", Range( 0 , 1000)) = 200
		_SizeFadeEndValue("Size Fade End", Range( 0 , 1000)) = 300
		[StyledCategory(Motion Settings)]_CategoryMotion("[ Category Motion ]", Float) = 0
		[StyledMessage(Info, Procedural variation in use. Use the Scale settings if the Variation is splitting the mesh., _VertexVariationMode, 1 , 0, 10)]_MessageMotionVariation("# Message Motion Variation", Float) = 0
		[HDR]_MotionHighlightColor("Motion Highlight Color", Color) = (2,2,2,1)
		_MotionNormalValue("Motion Normal Direction", Range( 0 , 1)) = 1
		[StyledSpace(10)]_SpaceMotionGlobals("# SpaceMotionGlobals", Float) = 0
		_MotionAmplitude_10("Motion Bending", Range( 0 , 2)) = 0.2
		[IntRange]_MotionSpeed_10("Motion Speed", Range( 0 , 40)) = 2
		_MotionScale_10("Motion Scale", Range( 0 , 20)) = 0
		_MotionVariation_10("Motion Variation", Range( 0 , 20)) = 0
		[Space(10)]_MotionAmplitude_32("Motion Flutter", Range( 0 , 2)) = 0.2
		[IntRange]_MotionSpeed_32("Motion Speed", Range( 0 , 40)) = 20
		_MotionScale_32("Motion Scale", Range( 0 , 20)) = 10
		_MotionVariation_32("Motion Variation", Range( 0 , 20)) = 10
		[Space(10)]_InteractionAmplitude("Interaction Amplitude", Range( 0 , 2)) = 1
		_InteractionMaskValue("Interaction Use Mask", Range( 0 , 1)) = 1
		[StyledSpace(10)]_SpaceMotionLocals("# SpaceMotionLocals", Float) = 0
		[StyledToggle]_MotionValue_30("Use Flutter Motion Settings", Float) = 1
		[HideInInspector][StyledToggle]_VertexPivotMode("Enable Pre Baked Pivots", Float) = 0
		[HideInInspector][StyledToggle]_VertexDataMode("Enable Batching Support", Float) = 0
		[HideInInspector][StyledToggle]_VertexDynamicMode("Enable Dynamic Support", Float) = 0
		[HideInInspector]_render_normals("_render_normals", Vector) = (1,1,1,0)
		[HideInInspector]_Cutoff("Legacy Cutoff", Float) = 0.5
		[HideInInspector]_Color("Legacy Color", Color) = (0,0,0,0)
		[HideInInspector]_MainTex("Legacy MainTex", 2D) = "white" {}
		[HideInInspector]_BumpMap("Legacy BumpMap", 2D) = "white" {}
		[HideInInspector]_LayerReactValue("Legacy Layer React", Float) = 0
		[HideInInspector]_VertexRollingMode("Legacy Vertex Rolling", Float) = 1
		[HideInInspector]_MaxBoundsInfo("Legacy Bounds Info", Vector) = (1,1,1,1)
		[HideInInspector]_VertexVariationMode("_VertexVariationMode", Float) = 0
		[HideInInspector]_VertexMasksMode("_VertexMasksMode", Float) = 0
		[HideInInspector]_IsTVEShader("_IsTVEShader", Float) = 1
		[HideInInspector]_IsVersion("_IsVersion", Float) = 700
		[HideInInspector]_HasEmissive("_HasEmissive", Float) = 0
		[HideInInspector]_HasGradient("_HasGradient", Float) = 0
		[HideInInspector]_HasOcclusion("_HasOcclusion", Float) = 0
		[HideInInspector]_IsGrassShader("_IsGrassShader", Float) = 1
		[HideInInspector]_IsStandardShader("_IsStandardShader", Float) = 1
		[HideInInspector]_render_cull("_render_cull", Float) = 0
		[HideInInspector]_render_src("_render_src", Float) = 1
		[HideInInspector]_render_dst("_render_dst", Float) = 0
		[HideInInspector]_render_zw("_render_zw", Float) = 1
		[HideInInspector]_render_coverage("_render_coverage", Float) = 0
		[HideInInspector] __dirty( "", Int ) = 1
	}

	SubShader
	{
		Tags{ "RenderType" = "Opaque"  "Queue" = "Geometry+0" "IsEmissive" = "true"  }
		Cull [_render_cull]
		ZWrite [_render_zw]
		Blend [_render_src] [_render_dst]
		
		AlphaToMask [_render_coverage]
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#include "UnityStandardUtils.cginc"
		#pragma target 4.0
		#pragma shader_feature_local TVE_FEATURE_CLIP
		#pragma shader_feature_local TVE_FEATURE_BATCHING
		//TVE Shader Type Defines
		#define TVE_IS_GRASS_SHADER
		//TVE Pipeline Defines
		#define THE_VEGETATION_ENGINE
		#define TVE_IS_STANDARD_PIPELINE
		//TVE Injection Defines
		//SHADER INJECTION POINT BEGIN
		//SHADER INJECTION POINT END
		#if defined(SHADER_API_D3D11) || defined(SHADER_API_XBOXONE) || defined(UNITY_COMPILER_HLSLCC) || defined(SHADER_API_PSSL) || (defined(SHADER_TARGET_SURFACE_ANALYSIS) && !defined(SHADER_TARGET_SURFACE_ANALYSIS_MOJOSHADER))//ASE Sampler Macros
		#define SAMPLE_TEXTURE2D_ARRAY_LOD(tex,samplerTex,coord,lod) tex.SampleLevel(samplerTex,coord, lod)
		#else//ASE Sampling Macros
		#define SAMPLE_TEXTURE2D_ARRAY_LOD(tex,samplertex,coord,lod) tex2DArraylod(tex, float4(coord,lod))
		#endif//ASE Sampling Macros

		#pragma surface surf StandardSpecular keepalpha addshadow fullforwardshadows dithercrossfade vertex:vertexDataFunc 
		#undef TRANSFORM_TEX
		#define TRANSFORM_TEX(tex,name) float4(tex.xy * name##_ST.xy + name##_ST.zw, tex.z, tex.w)
		struct Input
		{
			float3 worldPos;
			float4 uv_texcoord;
			half ASEVFace : VFACE;
			float vertexToFrag11_g74014;
			float vertexToFrag11_g74084;
			float vertexToFrag11_g74090;
			float3 vertexToFrag3890_g54098;
			float3 vertexToFrag4224_g54098;
			float4 vertexColor : COLOR;
		};

		uniform half _render_src;
		uniform half _render_cull;
		uniform half _render_dst;
		uniform half _render_zw;
		uniform half _IsStandardShader;
		uniform half _IsGrassShader;
		uniform half _render_coverage;
		uniform half _SpaceMotionGlobals;
		uniform half _RenderShadow;
		uniform half _VertexMasksMode;
		uniform sampler2D _BumpMap;
		uniform half _CategorySubsurface;
		uniform half _DetailTypeMode;
		uniform half TVE_Enabled;
		uniform half4 _OverlayMaskRemap;
		uniform half _DetailMode;
		uniform half _SpaceGlobalLocals;
		uniform float4 _NoiseMaskRemap;
		uniform half _HasEmissive;
		uniform half _SpaceRenderFade;
		uniform half _HasGradient;
		uniform half _SubsurfaceAngleValue;
		uniform float4 _SubsurfaceDiffusion_asset;
		uniform half _MessageSizeFade;
		uniform half _SpaceGlobalPosition;
		uniform half _IsTVEShader;
		uniform half4 _AlphaMaskRemap;
		uniform half _VertexVariationMode;
		uniform half _CategoryDetail;
		uniform half _RenderAmbient;
		uniform half _RenderClip;
		uniform float4 _SubsurfaceDiffusion_Asset;
		uniform half _CategoryMotion;
		uniform half _RenderPriority;
		uniform half _RenderMode;
		uniform half _LayerReactValue;
		uniform half _RenderCoverage;
		uniform half _IsVersion;
		uniform half _SpaceMotionLocals;
		uniform float4 _Color;
		uniform half _CategorySizeFade;
		uniform half _CategoryMain;
		uniform half _CategoryOcclusion;
		uniform half _CategoryEmissive;
		uniform half _RenderNormals;
		uniform half _CategoryGradient;
		uniform half _SpaceGlobalLayers;
		uniform half _VertexRollingMode;
		uniform half _AlphaClipValue;
		uniform half _Cutoff;
		uniform half _HasOcclusion;
		uniform float4 _MaxBoundsInfo;
		uniform half _RenderCull;
		uniform half _SubsurfaceAmbientValue;
		uniform half _SubsurfaceDirectValue;
		uniform sampler2D _MainTex;
		uniform half _DetailBlendMode;
		uniform half _RenderQueue;
		uniform half _CategoryRender;
		uniform float _SubsurfaceDiffusion;
		uniform float4 _GradientMaskRemap;
		uniform half _CategoryPerspective;
		uniform half4 _SubsurfaceMaskRemap;
		uniform half _CategoryNoise;
		uniform half _EmissiveFlagMode;
		uniform half _AlphaFeatherValue;
		uniform half _RenderDecals;
		uniform half _RenderDirect;
		uniform half _MessageGlobalsVariation;
		uniform half4 _DetailBlendRemap;
		uniform half _RenderZWrite;
		uniform half _SubsurfaceShadowValue;
		uniform half _SubsurfaceScatteringValue;
		uniform half _CategoryGlobal;
		uniform half _RenderSSR;
		uniform half4 _VertexOcclusionRemap;
		uniform half _MessageMotionVariation;
		uniform half _SubsurfaceNormalValue;
		uniform half4 _ColorsMaskRemap;
		uniform half _VertexPivotMode;
		uniform half4 TVE_MotionParams;
		UNITY_DECLARE_TEX2DARRAY_NOSAMPLER(TVE_MotionTex);
		uniform half4 TVE_MotionCoords;
		uniform half _LayerMotionValue;
		SamplerState sampler_linear_clamp;
		uniform float TVE_MotionUsage[10];
		uniform half _MotionAmplitude_10;
		uniform sampler2D TVE_NoiseTex;
		uniform float _MotionScale_10;
		uniform half4 TVE_NoiseParams;
		uniform float _MotionSpeed_10;
		uniform half _MotionVariation_10;
		uniform half _VertexDynamicMode;
		uniform half _InteractionAmplitude;
		uniform half _InteractionMaskValue;
		uniform float _MotionScale_32;
		uniform float _MotionVariation_32;
		uniform float _MotionSpeed_32;
		uniform half4 TVE_FlutterParams;
		uniform half _MotionAmplitude_32;
		uniform half _MotionValue_30;
		uniform half TVE_MotionFadeEnd;
		uniform half TVE_MotionFadeStart;
		uniform half _MotionNormalValue;
		uniform half _VertexDataMode;
		uniform half _PerspectivePushValue;
		uniform half _PerspectiveNoiseValue;
		uniform half _PerspectiveAngleValue;
		uniform half4 TVE_VertexParams;
		UNITY_DECLARE_TEX2DARRAY_NOSAMPLER(TVE_VertexTex);
		uniform half4 TVE_VertexCoords;
		uniform half _LayerVertexValue;
		uniform float TVE_VertexUsage[10];
		uniform half _GlobalSize;
		uniform half TVE_DistanceFadeBias;
		uniform half _SizeFadeEndValue;
		uniform half _SizeFadeStartValue;
		uniform half _SizeFadeMode;
		uniform half _DisableSRPBatcher;
		uniform sampler2D _MainNormalTex;
		uniform half4 _MainUVs;
		uniform half _MainNormalValue;
		uniform half3 _render_normals;
		uniform half4 _GradientColorTwo;
		uniform half4 _GradientColorOne;
		uniform half _GradientMinValue;
		uniform half _GradientMaxValue;
		uniform half4 _MotionHighlightColor;
		uniform half4 _MainColor;
		uniform sampler2D _MainAlbedoTex;
		uniform half4 _VertexOcclusionColor;
		uniform half _VertexOcclusionMinValue;
		uniform half _VertexOcclusionMaxValue;
		uniform half4 TVE_ColorsParams;
		UNITY_DECLARE_TEX2DARRAY_NOSAMPLER(TVE_ColorsTex);
		uniform half4 TVE_ColorsCoords;
		uniform half _ColorsPositionMode;
		uniform half _LayerColorsValue;
		uniform float TVE_ColorsUsage[10];
		uniform half _GlobalColors;
		uniform half _ColorsVariationValue;
		uniform half _ColorsMaskMinValue;
		uniform half _ColorsMaskMaxValue;
		uniform half4 _SubsurfaceColor;
		uniform half _SubsurfaceValue;
		uniform half TVE_SubsurfaceValue;
		uniform half _SubsurfaceMaskMinValue;
		uniform half _SubsurfaceMaskMaxValue;
		uniform half3 TVE_MainLightDirection;
		uniform half4 TVE_OverlayColor;
		uniform half _GlobalOverlay;
		uniform half4 TVE_ExtrasParams;
		UNITY_DECLARE_TEX2DARRAY_NOSAMPLER(TVE_ExtrasTex);
		uniform half4 TVE_ExtrasCoords;
		uniform half _ExtrasPositionMode;
		uniform half _LayerExtrasValue;
		uniform float TVE_ExtrasUsage[10];
		uniform half _OverlayVariationValue;
		uniform half _OverlayMaskMinValue;
		uniform half _OverlayMaskMaxValue;
		uniform half4 _EmissiveColor;
		uniform float4 _EmissiveIntensityParams;
		uniform sampler2D _EmissiveTex;
		uniform half4 _EmissiveUVs;
		uniform half _GlobalEmissive;
		uniform half _RenderSpecular;
		uniform sampler2D _MainMaskTex;
		uniform half _MainSmoothnessValue;
		uniform half TVE_OverlaySmoothness;
		uniform half _GlobalWetness;
		uniform half _MainOcclusionValue;
		uniform half _AlphaVariationValue;
		uniform half _GlobalAlpha;


		float2 DecodeFloatToVector2( float enc )
		{
			float2 result ;
			result.y = enc % 2048;
			result.x = floor(enc / 2048);
			return result / (2048 - 1);
		}


		void vertexDataFunc( inout appdata_full v, out Input o )
		{
			UNITY_INITIALIZE_OUTPUT( Input, o );
			float3 ase_vertex3Pos = v.vertex.xyz;
			float3 VertexPosition3588_g54098 = ase_vertex3Pos;
			float3 appendResult60_g74051 = (float3(v.texcoord3.x , v.texcoord3.z , v.texcoord3.y));
			half3 Mesh_PivotsData2831_g54098 = ( appendResult60_g74051 * _VertexPivotMode );
			half3 Mesh_PivotsOS2291_g54098 = Mesh_PivotsData2831_g54098;
			float3 temp_output_2283_0_g54098 = ( VertexPosition3588_g54098 - Mesh_PivotsOS2291_g54098 );
			half3 VertexPos40_g74066 = temp_output_2283_0_g54098;
			float3 appendResult74_g74066 = (float3(VertexPos40_g74066.x , 0.0 , 0.0));
			half3 VertexPosRotationAxis50_g74066 = appendResult74_g74066;
			float3 break84_g74066 = VertexPos40_g74066;
			float3 appendResult81_g74066 = (float3(0.0 , break84_g74066.y , break84_g74066.z));
			half3 VertexPosOtherAxis82_g74066 = appendResult81_g74066;
			float4 temp_output_91_19_g74044 = TVE_MotionCoords;
			float4x4 break19_g74008 = unity_ObjectToWorld;
			float3 appendResult20_g74008 = (float3(break19_g74008[ 0 ][ 3 ] , break19_g74008[ 1 ][ 3 ] , break19_g74008[ 2 ][ 3 ]));
			float3 temp_output_122_0_g74008 = Mesh_PivotsData2831_g54098;
			float3 PivotsOnly105_g74008 = (mul( unity_ObjectToWorld, float4( temp_output_122_0_g74008 , 0.0 ) ).xyz).xyz;
			half3 ObjectData20_g74009 = ( appendResult20_g74008 + PivotsOnly105_g74008 );
			float3 ase_worldPos = mul( unity_ObjectToWorld, v.vertex );
			half3 WorldData19_g74009 = ase_worldPos;
			#ifdef TVE_FEATURE_BATCHING
				float3 staticSwitch14_g74009 = WorldData19_g74009;
			#else
				float3 staticSwitch14_g74009 = ObjectData20_g74009;
			#endif
			float3 temp_output_114_0_g74008 = staticSwitch14_g74009;
			float3 vertexToFrag4224_g54098 = temp_output_114_0_g74008;
			half3 ObjectData20_g74057 = vertexToFrag4224_g54098;
			float3 vertexToFrag3890_g54098 = ase_worldPos;
			half3 WorldData19_g74057 = vertexToFrag3890_g54098;
			#ifdef TVE_FEATURE_BATCHING
				float3 staticSwitch14_g74057 = WorldData19_g74057;
			#else
				float3 staticSwitch14_g74057 = ObjectData20_g74057;
			#endif
			float3 ObjectPosition4223_g54098 = staticSwitch14_g74057;
			half2 UV94_g74044 = ( (temp_output_91_19_g74044).zw + ( (temp_output_91_19_g74044).xy * (ObjectPosition4223_g54098).xz ) );
			float temp_output_84_0_g74044 = _LayerMotionValue;
			float4 lerpResult107_g74044 = lerp( TVE_MotionParams , saturate( SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_MotionTex, sampler_linear_clamp, float3(UV94_g74044,temp_output_84_0_g74044), 0.0 ) ) , TVE_MotionUsage[(int)temp_output_84_0_g74044]);
			half4 Global_Motion_Params3909_g54098 = lerpResult107_g74044;
			float4 break322_g73999 = Global_Motion_Params3909_g54098;
			float3 appendResult397_g73999 = (float3(break322_g73999.x , 0.0 , break322_g73999.y));
			float3 temp_output_398_0_g73999 = (appendResult397_g73999*2.0 + -1.0);
			float3 ase_parentObjectScale = (1.0/float3( length( unity_WorldToObject[ 0 ].xyz ), length( unity_WorldToObject[ 1 ].xyz ), length( unity_WorldToObject[ 2 ].xyz ) ));
			half2 Global_MotionDirectionOS39_g54098 = (( mul( unity_WorldToObject, float4( temp_output_398_0_g73999 , 0.0 ) ).xyz * ase_parentObjectScale )).xz;
			half2 Input_DirectionOS358_g73995 = Global_MotionDirectionOS39_g54098;
			half Wind_Power369_g73999 = break322_g73999.z;
			half Global_WindPower2223_g54098 = Wind_Power369_g73999;
			half3 Input_Position419_g74072 = ObjectPosition4223_g54098;
			float Input_MotionScale287_g74072 = ( _MotionScale_10 + 1.0 );
			half Global_Scale448_g74072 = TVE_NoiseParams.x;
			float2 temp_output_597_0_g74072 = (( Input_Position419_g74072 * Input_MotionScale287_g74072 * Global_Scale448_g74072 * 0.0075 )).xz;
			half2 Global_MotionDirectionWS4683_g54098 = (temp_output_398_0_g73999).xz;
			half2 Input_DirectionWS423_g74072 = Global_MotionDirectionWS4683_g54098;
			half Input_MotionSpeed62_g74072 = _MotionSpeed_10;
			half Global_Speed449_g74072 = TVE_NoiseParams.y;
			half Input_MotionVariation284_g74072 = _MotionVariation_10;
			float3 break111_g74011 = ObjectPosition4223_g54098;
			half Global_DynamicMode5112_g54098 = _VertexDynamicMode;
			half Input_DynamicMode120_g74011 = Global_DynamicMode5112_g54098;
			float Mesh_Variation16_g54098 = v.color.r;
			half Input_Variation124_g74011 = Mesh_Variation16_g54098;
			half ObjectData20_g74012 = frac( ( ( ( break111_g74011.x + break111_g74011.y + break111_g74011.z + 0.001275 ) * ( 1.0 - Input_DynamicMode120_g74011 ) ) + Input_Variation124_g74011 ) );
			half WorldData19_g74012 = Input_Variation124_g74011;
			#ifdef TVE_FEATURE_BATCHING
				float staticSwitch14_g74012 = WorldData19_g74012;
			#else
				float staticSwitch14_g74012 = ObjectData20_g74012;
			#endif
			float clampResult129_g74011 = clamp( staticSwitch14_g74012 , 0.01 , 0.99 );
			half Global_MeshVariation5104_g54098 = clampResult129_g74011;
			half Input_GlobalVariation569_g74072 = Global_MeshVariation5104_g54098;
			float temp_output_630_0_g74072 = ( ( ( _Time.y * Input_MotionSpeed62_g74072 * Global_Speed449_g74072 ) + ( Input_MotionVariation284_g74072 * Input_GlobalVariation569_g74072 ) ) * 0.03 );
			float temp_output_607_0_g74072 = frac( temp_output_630_0_g74072 );
			float4 lerpResult590_g74072 = lerp( tex2Dlod( TVE_NoiseTex, float4( ( temp_output_597_0_g74072 + ( -Input_DirectionWS423_g74072 * temp_output_607_0_g74072 ) ), 0, 0.0) ) , tex2Dlod( TVE_NoiseTex, float4( ( temp_output_597_0_g74072 + ( -Input_DirectionWS423_g74072 * frac( ( temp_output_630_0_g74072 + 0.5 ) ) ) ), 0, 0.0) ) , ( abs( ( temp_output_607_0_g74072 - 0.5 ) ) / 0.5 ));
			half Input_GlobalWind327_g74072 = Global_WindPower2223_g54098;
			float lerpResult612_g74072 = lerp( 1.4 , 0.4 , Input_GlobalWind327_g74072);
			float3 temp_cast_7 = (lerpResult612_g74072).xxx;
			float3 break638_g74072 = (pow( ( abs( (lerpResult590_g74072).rgb ) + 0.2 ) , temp_cast_7 )*1.4 + -0.2);
			half Global_NoiseTexR34_g54098 = break638_g74072.x;
			half Motion_10_Amplitude2258_g54098 = ( _MotionAmplitude_10 * Global_WindPower2223_g54098 * Global_NoiseTexR34_g54098 );
			half Input_BendingAmplitude376_g73995 = Motion_10_Amplitude2258_g54098;
			half Mesh_Height1524_g54098 = v.color.a;
			half Input_MeshHeight388_g73995 = Mesh_Height1524_g54098;
			half ObjectData20_g73997 = ( Input_MeshHeight388_g73995 * 2.0 );
			float enc62_g74013 = v.texcoord.w;
			float2 localDecodeFloatToVector262_g74013 = DecodeFloatToVector2( enc62_g74013 );
			float2 break63_g74013 = ( localDecodeFloatToVector262_g74013 * 100.0 );
			float Bounds_Height5230_g54098 = break63_g74013.x;
			half Input_BoundsHeight390_g73995 = Bounds_Height5230_g54098;
			half WorldData19_g73997 = ( ( Input_MeshHeight388_g73995 * Input_MeshHeight388_g73995 ) * Input_BoundsHeight390_g73995 * 2.0 );
			#ifdef TVE_FEATURE_BATCHING
				float staticSwitch14_g73997 = WorldData19_g73997;
			#else
				float staticSwitch14_g73997 = ObjectData20_g73997;
			#endif
			half Mask_Motion_10321_g73995 = staticSwitch14_g73997;
			half Input_InteractionAmplitude58_g73995 = _InteractionAmplitude;
			half Input_InteractionUseMask62_g73995 = _InteractionMaskValue;
			float lerpResult371_g73995 = lerp( 2.0 , Mask_Motion_10321_g73995 , Input_InteractionUseMask62_g73995);
			half ObjectData20_g73996 = lerpResult371_g73995;
			half WorldData19_g73996 = Mask_Motion_10321_g73995;
			#ifdef TVE_FEATURE_BATCHING
				float staticSwitch14_g73996 = WorldData19_g73996;
			#else
				float staticSwitch14_g73996 = ObjectData20_g73996;
			#endif
			half Mask_Interaction373_g73995 = ( Input_InteractionAmplitude58_g73995 * staticSwitch14_g73996 );
			half Global_InteractionMask66_g54098 = ( break322_g73999.w * break322_g73999.w );
			float Input_InteractionGlobalMask330_g73995 = Global_InteractionMask66_g54098;
			float lerpResult360_g73995 = lerp( ( Input_BendingAmplitude376_g73995 * Mask_Motion_10321_g73995 ) , Mask_Interaction373_g73995 , saturate( ( Input_InteractionAmplitude58_g73995 * Input_InteractionGlobalMask330_g73995 ) ));
			float2 break364_g73995 = ( Input_DirectionOS358_g73995 * lerpResult360_g73995 );
			half Motion_10_BendingZ190_g54098 = break364_g73995.y;
			half Angle44_g74066 = Motion_10_BendingZ190_g54098;
			half3 VertexPos40_g74058 = ( VertexPosRotationAxis50_g74066 + ( VertexPosOtherAxis82_g74066 * cos( Angle44_g74066 ) ) + ( cross( float3(1,0,0) , VertexPosOtherAxis82_g74066 ) * sin( Angle44_g74066 ) ) );
			float3 appendResult74_g74058 = (float3(0.0 , 0.0 , VertexPos40_g74058.z));
			half3 VertexPosRotationAxis50_g74058 = appendResult74_g74058;
			float3 break84_g74058 = VertexPos40_g74058;
			float3 appendResult81_g74058 = (float3(break84_g74058.x , break84_g74058.y , 0.0));
			half3 VertexPosOtherAxis82_g74058 = appendResult81_g74058;
			half Motion_10_BendingX216_g54098 = break364_g73995.x;
			half Angle44_g74058 = -Motion_10_BendingX216_g54098;
			half Input_MotionScale321_g74081 = _MotionScale_32;
			half Input_MotionVariation330_g74081 = _MotionVariation_32;
			half Input_GlobalVariation372_g74081 = Global_MeshVariation5104_g54098;
			half Input_MotionSpeed62_g74081 = _MotionSpeed_32;
			half Global_Speed350_g74081 = TVE_FlutterParams.y;
			half Motion_FacingMask5214_g54098 = 1.0;
			float temp_output_7_0_g74017 = TVE_MotionFadeEnd;
			half Motion_FadeOut4005_g54098 = saturate( ( ( distance( ase_worldPos , _WorldSpaceCameraPos ) - temp_output_7_0_g74017 ) / ( TVE_MotionFadeStart - temp_output_7_0_g74017 ) ) );
			half Motion_30_Amplitude4960_g54098 = ( _MotionAmplitude_32 * _MotionValue_30 * Global_WindPower2223_g54098 * Global_NoiseTexR34_g54098 * Motion_FacingMask5214_g54098 * Motion_FadeOut4005_g54098 );
			half Input_MotionAmplitude58_g74081 = Motion_30_Amplitude4960_g54098;
			half Global_Power354_g74081 = TVE_FlutterParams.x;
			float enc59_g74013 = v.texcoord.z;
			float2 localDecodeFloatToVector259_g74013 = DecodeFloatToVector2( enc59_g74013 );
			float2 break61_g74013 = localDecodeFloatToVector259_g74013;
			half Mesh_Motion_30144_g54098 = break61_g74013.y;
			half Input_MeshMotion_30374_g74081 = Mesh_Motion_30144_g54098;
			float3 ase_vertexNormal = v.normal.xyz;
			half Input_MotionNormal364_g74081 = _MotionNormalValue;
			float3 lerpResult370_g74081 = lerp( float3( 1,1,1 ) , ase_vertexNormal , Input_MotionNormal364_g74081);
			half3 Motion_30_Details263_g54098 = ( ( sin( ( ( ( ase_worldPos.x + ase_worldPos.y + ase_worldPos.z ) * Input_MotionScale321_g74081 ) + ( Input_MotionVariation330_g74081 * Input_GlobalVariation372_g74081 ) + ( _Time.y * Input_MotionSpeed62_g74081 * Global_Speed350_g74081 ) ) ) * Input_MotionAmplitude58_g74081 * Global_Power354_g74081 * Input_MeshMotion_30374_g74081 * 0.4 ) * lerpResult370_g74081 );
			float3 Vertex_Motion_Object833_g54098 = ( ( VertexPosRotationAxis50_g74058 + ( VertexPosOtherAxis82_g74058 * cos( Angle44_g74058 ) ) + ( cross( float3(0,0,1) , VertexPosOtherAxis82_g74058 ) * sin( Angle44_g74058 ) ) ) + Motion_30_Details263_g54098 );
			float3 temp_output_3474_0_g54098 = ( VertexPosition3588_g54098 - Mesh_PivotsOS2291_g54098 );
			float3 appendResult2043_g54098 = (float3(Motion_10_BendingX216_g54098 , 0.0 , Motion_10_BendingZ190_g54098));
			float3 Vertex_Motion_World1118_g54098 = ( ( temp_output_3474_0_g54098 + appendResult2043_g54098 ) + Motion_30_Details263_g54098 );
			#ifdef TVE_FEATURE_BATCHING
				float3 staticSwitch4976_g54098 = Vertex_Motion_World1118_g54098;
			#else
				float3 staticSwitch4976_g54098 = ( Vertex_Motion_Object833_g54098 + ( _VertexDataMode * 0.0 ) );
			#endif
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 normalizeResult2696_g54098 = normalize( ase_worldViewDir );
			float3 break2709_g54098 = cross( normalizeResult2696_g54098 , half3(0,1,0) );
			float3 appendResult2710_g54098 = (float3(-break2709_g54098.z , 0.0 , break2709_g54098.x));
			float3 appendResult2667_g54098 = (float3(Global_MeshVariation5104_g54098 , 0.5 , Global_MeshVariation5104_g54098));
			float3 normalizeResult2169_g54098 = normalize( ase_worldViewDir );
			float3 ViewDir_Normalized3963_g54098 = normalizeResult2169_g54098;
			float dotResult2212_g54098 = dot( ViewDir_Normalized3963_g54098 , float3(0,1,0) );
			half Mask_HView2656_g54098 = dotResult2212_g54098;
			float saferPower2652_g54098 = abs( Mask_HView2656_g54098 );
			half3 Grass_Perspective2661_g54098 = ( ( ( mul( unity_WorldToObject, float4( appendResult2710_g54098 , 0.0 ) ).xyz * _PerspectivePushValue ) + ( (appendResult2667_g54098*2.0 + -1.0) * _PerspectiveNoiseValue ) ) * Mesh_Height1524_g54098 * pow( saferPower2652_g54098 , _PerspectiveAngleValue ) );
			float4 temp_output_94_19_g74068 = TVE_VertexCoords;
			half2 UV97_g74068 = ( (temp_output_94_19_g74068).zw + ( (temp_output_94_19_g74068).xy * (ObjectPosition4223_g54098).xz ) );
			float temp_output_84_0_g74068 = _LayerVertexValue;
			float4 lerpResult109_g74068 = lerp( TVE_VertexParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_VertexTex, sampler_linear_clamp, float3(UV97_g74068,temp_output_84_0_g74068), 0.0 ) , TVE_VertexUsage[(int)temp_output_84_0_g74068]);
			half4 Global_Object_Params4173_g54098 = lerpResult109_g74068;
			half Global_VertexSize174_g54098 = saturate( Global_Object_Params4173_g54098.w );
			float lerpResult346_g54098 = lerp( 1.0 , Global_VertexSize174_g54098 , _GlobalSize);
			float3 appendResult3480_g54098 = (float3(lerpResult346_g54098 , lerpResult346_g54098 , lerpResult346_g54098));
			half3 ObjectData20_g73998 = appendResult3480_g54098;
			half3 _Vector11 = half3(1,1,1);
			half3 WorldData19_g73998 = _Vector11;
			#ifdef TVE_FEATURE_BATCHING
				float3 staticSwitch14_g73998 = WorldData19_g73998;
			#else
				float3 staticSwitch14_g73998 = ObjectData20_g73998;
			#endif
			half3 Vertex_Size1741_g54098 = staticSwitch14_g73998;
			half3 _Vector5 = half3(1,1,1);
			float temp_output_7_0_g74078 = _SizeFadeEndValue;
			float temp_output_335_0_g54098 = saturate( ( ( ( distance( _WorldSpaceCameraPos , ObjectPosition4223_g54098 ) * ( 1.0 / TVE_DistanceFadeBias ) ) - temp_output_7_0_g74078 ) / ( _SizeFadeStartValue - temp_output_7_0_g74078 ) ) );
			float3 appendResult3482_g54098 = (float3(temp_output_335_0_g54098 , temp_output_335_0_g54098 , temp_output_335_0_g54098));
			float3 lerpResult5065_g54098 = lerp( _Vector5 , appendResult3482_g54098 , _SizeFadeMode);
			half3 ObjectData20_g74067 = lerpResult5065_g54098;
			half3 WorldData19_g74067 = _Vector5;
			#ifdef TVE_FEATURE_BATCHING
				float3 staticSwitch14_g74067 = WorldData19_g74067;
			#else
				float3 staticSwitch14_g74067 = ObjectData20_g74067;
			#endif
			float3 Vertex_SizeFade1740_g54098 = staticSwitch14_g74067;
			float3 lerpResult16_g74007 = lerp( VertexPosition3588_g54098 , ( ( ( staticSwitch4976_g54098 + Grass_Perspective2661_g54098 ) * Vertex_Size1741_g54098 * Vertex_SizeFade1740_g54098 ) + Mesh_PivotsOS2291_g54098 ) , TVE_Enabled);
			float3 Final_VertexPosition890_g54098 = ( lerpResult16_g74007 + _DisableSRPBatcher );
			v.vertex.xyz = Final_VertexPosition890_g54098;
			v.vertex.w = 1;
			float temp_output_7_0_g74052 = _GradientMinValue;
			half Gradient_Tint2784_g54098 = saturate( ( ( Mesh_Height1524_g54098 - temp_output_7_0_g74052 ) / ( _GradientMaxValue - temp_output_7_0_g74052 ) ) );
			o.vertexToFrag11_g74014 = Gradient_Tint2784_g54098;
			half Global_NoiseTexA4860_g54098 = (lerpResult590_g74072).a;
			half Highlight_Tint3231_g54098 = ( Global_NoiseTexA4860_g54098 * Global_WindPower2223_g54098 * Motion_FadeOut4005_g54098 * Mesh_Height1524_g54098 );
			o.vertexToFrag11_g74084 = Highlight_Tint3231_g54098;
			float Mesh_Occlusion318_g54098 = v.color.g;
			float temp_output_7_0_g74091 = _VertexOcclusionMinValue;
			float temp_output_3377_0_g54098 = saturate( ( ( Mesh_Occlusion318_g54098 - temp_output_7_0_g74091 ) / ( _VertexOcclusionMaxValue - temp_output_7_0_g74091 ) ) );
			o.vertexToFrag11_g74090 = temp_output_3377_0_g54098;
			o.vertexToFrag3890_g54098 = ase_worldPos;
			o.vertexToFrag4224_g54098 = temp_output_114_0_g74008;
		}

		void surf( Input i , inout SurfaceOutputStandardSpecular o )
		{
			half2 Main_UVs15_g54098 = ( ( i.uv_texcoord.xy * (_MainUVs).xy ) + (_MainUVs).zw );
			half3 Main_Normal137_g54098 = UnpackScaleNormal( tex2D( _MainNormalTex, Main_UVs15_g54098 ), _MainNormalValue );
			float3 temp_output_13_0_g74085 = Main_Normal137_g54098;
			float3 switchResult12_g74085 = (((i.ASEVFace>0)?(temp_output_13_0_g74085):(( temp_output_13_0_g74085 * _render_normals ))));
			half3 Blend_Normal312_g54098 = switchResult12_g74085;
			half3 Final_Normal366_g54098 = Blend_Normal312_g54098;
			o.Normal = Final_Normal366_g54098;
			float3 lerpResult2779_g54098 = lerp( (_GradientColorTwo).rgb , (_GradientColorOne).rgb , i.vertexToFrag11_g74014);
			float4 tex2DNode29_g54098 = tex2D( _MainAlbedoTex, Main_UVs15_g54098 );
			half3 Main_Albedo99_g54098 = ( (_MainColor).rgb * (tex2DNode29_g54098).rgb );
			half3 Blend_Albedo265_g54098 = Main_Albedo99_g54098;
			float3 temp_cast_1 = (1.0).xxx;
			float3 lerpResult2945_g54098 = lerp( (_VertexOcclusionColor).rgb , temp_cast_1 , i.vertexToFrag11_g74090);
			float3 Vertex_Occlusion648_g54098 = lerpResult2945_g54098;
			half3 Blend_AlbedoTinted2808_g54098 = ( ( lerpResult2779_g54098 * float3(1,1,1) * ( ( (_MotionHighlightColor).rgb * i.vertexToFrag11_g74084 ) + float3( 1,1,1 ) ) ) * Blend_Albedo265_g54098 * Vertex_Occlusion648_g54098 );
			float dotResult3616_g54098 = dot( Blend_AlbedoTinted2808_g54098 , float3(0.2126,0.7152,0.0722) );
			float3 temp_cast_2 = (dotResult3616_g54098).xxx;
			float4 temp_output_91_19_g74053 = TVE_ColorsCoords;
			float3 WorldPosition3905_g54098 = i.vertexToFrag3890_g54098;
			half3 ObjectData20_g74057 = i.vertexToFrag4224_g54098;
			half3 WorldData19_g74057 = i.vertexToFrag3890_g54098;
			#ifdef TVE_FEATURE_BATCHING
				float3 staticSwitch14_g74057 = WorldData19_g74057;
			#else
				float3 staticSwitch14_g74057 = ObjectData20_g74057;
			#endif
			float3 ObjectPosition4223_g54098 = staticSwitch14_g74057;
			float3 lerpResult4822_g54098 = lerp( WorldPosition3905_g54098 , ObjectPosition4223_g54098 , _ColorsPositionMode);
			half2 UV94_g74053 = ( (temp_output_91_19_g74053).zw + ( (temp_output_91_19_g74053).xy * (lerpResult4822_g54098).xz ) );
			float temp_output_82_0_g74053 = _LayerColorsValue;
			float4 lerpResult108_g74053 = lerp( TVE_ColorsParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ColorsTex, sampler_linear_clamp, float3(UV94_g74053,temp_output_82_0_g74053), 0.0 ) , TVE_ColorsUsage[(int)temp_output_82_0_g74053]);
			half Global_ColorsTex_A1701_g54098 = saturate( (lerpResult108_g74053).a );
			half Global_Colors_Influence3668_g54098 = Global_ColorsTex_A1701_g54098;
			float3 lerpResult3618_g54098 = lerp( Blend_AlbedoTinted2808_g54098 , temp_cast_2 , Global_Colors_Influence3668_g54098);
			half3 Global_ColorsTex_RGB1700_g54098 = (lerpResult108_g74053).rgb;
			#ifdef UNITY_COLORSPACE_GAMMA
				float staticSwitch1_g74092 = 2.0;
			#else
				float staticSwitch1_g74092 = 4.594794;
			#endif
			half3 Global_Colors1954_g54098 = ( Global_ColorsTex_RGB1700_g54098 * staticSwitch1_g74092 );
			float3 break111_g74011 = ObjectPosition4223_g54098;
			half Global_DynamicMode5112_g54098 = _VertexDynamicMode;
			half Input_DynamicMode120_g74011 = Global_DynamicMode5112_g54098;
			float Mesh_Variation16_g54098 = i.vertexColor.r;
			half Input_Variation124_g74011 = Mesh_Variation16_g54098;
			half ObjectData20_g74012 = frac( ( ( ( break111_g74011.x + break111_g74011.y + break111_g74011.z + 0.001275 ) * ( 1.0 - Input_DynamicMode120_g74011 ) ) + Input_Variation124_g74011 ) );
			half WorldData19_g74012 = Input_Variation124_g74011;
			#ifdef TVE_FEATURE_BATCHING
				float staticSwitch14_g74012 = WorldData19_g74012;
			#else
				float staticSwitch14_g74012 = ObjectData20_g74012;
			#endif
			float clampResult129_g74011 = clamp( staticSwitch14_g74012 , 0.01 , 0.99 );
			half Global_MeshVariation5104_g54098 = clampResult129_g74011;
			float lerpResult3870_g54098 = lerp( 1.0 , ( Global_MeshVariation5104_g54098 * Global_MeshVariation5104_g54098 ) , _ColorsVariationValue);
			half Global_Colors_Variation3650_g54098 = ( _GlobalColors * lerpResult3870_g54098 );
			half Mesh_Height1524_g54098 = i.vertexColor.a;
			float clampResult5405_g54098 = clamp( Mesh_Height1524_g54098 , 0.01 , 0.99 );
			float temp_output_7_0_g74061 = _ColorsMaskMinValue;
			half Global_Colors_Mask3692_g54098 = saturate( ( ( clampResult5405_g54098 - temp_output_7_0_g74061 ) / ( _ColorsMaskMaxValue - temp_output_7_0_g74061 ) ) );
			float lerpResult16_g74059 = lerp( 0.0 , ( Global_Colors_Variation3650_g54098 * Global_Colors_Mask3692_g54098 ) , TVE_Enabled);
			float3 lerpResult3628_g54098 = lerp( Blend_AlbedoTinted2808_g54098 , ( lerpResult3618_g54098 * Global_Colors1954_g54098 ) , lerpResult16_g74059);
			half3 Blend_AlbedoColored863_g54098 = lerpResult3628_g54098;
			float3 temp_output_799_0_g54098 = (_SubsurfaceColor).rgb;
			float dotResult3930_g54098 = dot( temp_output_799_0_g54098 , float3(0.2126,0.7152,0.0722) );
			float3 temp_cast_5 = (dotResult3930_g54098).xxx;
			float3 lerpResult3932_g54098 = lerp( temp_output_799_0_g54098 , temp_cast_5 , Global_Colors_Influence3668_g54098);
			float3 lerpResult3942_g54098 = lerp( temp_output_799_0_g54098 , ( lerpResult3932_g54098 * Global_Colors1954_g54098 ) , ( Global_Colors_Variation3650_g54098 * Global_Colors_Mask3692_g54098 ));
			half3 Subsurface_Color1722_g54098 = lerpResult3942_g54098;
			half Global_Subsurface4041_g54098 = TVE_SubsurfaceValue;
			half Subsurface_Intensity1752_g54098 = ( _SubsurfaceValue * Global_Subsurface4041_g54098 );
			float temp_output_7_0_g74049 = _SubsurfaceMaskMinValue;
			half Subsurface_Mask1557_g54098 = saturate( ( ( Mesh_Height1524_g54098 - temp_output_7_0_g74049 ) / ( _SubsurfaceMaskMaxValue - temp_output_7_0_g74049 ) ) );
			half3 Subsurface_Translucency884_g54098 = ( Subsurface_Color1722_g54098 * Subsurface_Intensity1752_g54098 * Subsurface_Mask1557_g54098 );
			half3 MainLight_Direction3926_g54098 = TVE_MainLightDirection;
			float3 ase_worldPos = i.worldPos;
			float3 ase_worldViewDir = normalize( UnityWorldSpaceViewDir( ase_worldPos ) );
			float3 normalizeResult2169_g54098 = normalize( ase_worldViewDir );
			float3 ViewDir_Normalized3963_g54098 = normalizeResult2169_g54098;
			float dotResult785_g54098 = dot( -MainLight_Direction3926_g54098 , ViewDir_Normalized3963_g54098 );
			float saferPower1624_g54098 = abs( saturate( dotResult785_g54098 ) );
			#ifdef UNITY_PASS_FORWARDADD
				float staticSwitch1602_g54098 = 0.0;
			#else
				float staticSwitch1602_g54098 = ( pow( saferPower1624_g54098 , _SubsurfaceAngleValue ) * _SubsurfaceScatteringValue );
			#endif
			half Mask_Subsurface_View782_g54098 = staticSwitch1602_g54098;
			half3 Subsurface_Approximation1693_g54098 = ( Subsurface_Translucency884_g54098 * Blend_AlbedoColored863_g54098 * Mask_Subsurface_View782_g54098 );
			half3 Blend_AlbedoAndSubsurface149_g54098 = ( Blend_AlbedoColored863_g54098 + Subsurface_Approximation1693_g54098 );
			half3 Global_OverlayColor1758_g54098 = (TVE_OverlayColor).rgb;
			half Main_Albedo_G3526_g54098 = tex2DNode29_g54098.g;
			float4 temp_output_93_19_g74000 = TVE_ExtrasCoords;
			float3 lerpResult4827_g54098 = lerp( WorldPosition3905_g54098 , ObjectPosition4223_g54098 , _ExtrasPositionMode);
			half2 UV96_g74000 = ( (temp_output_93_19_g74000).zw + ( (temp_output_93_19_g74000).xy * (lerpResult4827_g54098).xz ) );
			float temp_output_84_0_g74000 = _LayerExtrasValue;
			float4 lerpResult109_g74000 = lerp( TVE_ExtrasParams , SAMPLE_TEXTURE2D_ARRAY_LOD( TVE_ExtrasTex, sampler_linear_clamp, float3(UV96_g74000,temp_output_84_0_g74000), 0.0 ) , TVE_ExtrasUsage[(int)temp_output_84_0_g74000]);
			float4 break89_g74000 = lerpResult109_g74000;
			half Global_Extras_Overlay156_g54098 = break89_g74000.b;
			float lerpResult1065_g54098 = lerp( 1.0 , Global_MeshVariation5104_g54098 , _OverlayVariationValue);
			half Overlay_Variation4560_g54098 = lerpResult1065_g54098;
			half Overlay_Commons1365_g54098 = ( _GlobalOverlay * Global_Extras_Overlay156_g54098 * Overlay_Variation4560_g54098 );
			half Overlay_Mask_2D5121_g54098 = ( ( ( Mesh_Height1524_g54098 * 0.5 ) + Main_Albedo_G3526_g54098 ) * Overlay_Commons1365_g54098 );
			float temp_output_7_0_g74005 = _OverlayMaskMinValue;
			half Overlay_Mask269_g54098 = saturate( ( ( Overlay_Mask_2D5121_g54098 - temp_output_7_0_g74005 ) / ( _OverlayMaskMaxValue - temp_output_7_0_g74005 ) ) );
			float3 lerpResult336_g54098 = lerp( Blend_AlbedoAndSubsurface149_g54098 , Global_OverlayColor1758_g54098 , Overlay_Mask269_g54098);
			half3 Final_Albedo359_g54098 = lerpResult336_g54098;
			o.Albedo = Final_Albedo359_g54098;
			float4 temp_output_4214_0_g54098 = ( _EmissiveColor * _EmissiveIntensityParams.x );
			half2 Emissive_UVs2468_g54098 = ( ( i.uv_texcoord.xy * (_EmissiveUVs).xy ) + (_EmissiveUVs).zw );
			half Global_Extras_Emissive4203_g54098 = break89_g74000.r;
			float lerpResult4206_g54098 = lerp( 1.0 , Global_Extras_Emissive4203_g54098 , _GlobalEmissive);
			half3 Final_Emissive2476_g54098 = ( (( temp_output_4214_0_g54098 * tex2D( _EmissiveTex, Emissive_UVs2468_g54098 ) )).rgb * lerpResult4206_g54098 );
			o.Emission = Final_Emissive2476_g54098;
			half Render_Specular4861_g54098 = _RenderSpecular;
			float3 temp_cast_8 = (( 0.04 * Render_Specular4861_g54098 )).xxx;
			o.Specular = temp_cast_8;
			float4 tex2DNode35_g54098 = tex2D( _MainMaskTex, Main_UVs15_g54098 );
			half Main_Smoothness227_g54098 = ( tex2DNode35_g54098.a * _MainSmoothnessValue );
			half Blend_Smoothness314_g54098 = Main_Smoothness227_g54098;
			half Global_OverlaySmoothness311_g54098 = TVE_OverlaySmoothness;
			float lerpResult343_g54098 = lerp( Blend_Smoothness314_g54098 , Global_OverlaySmoothness311_g54098 , Overlay_Mask269_g54098);
			half Final_Smoothness371_g54098 = lerpResult343_g54098;
			half Global_Extras_Wetness305_g54098 = break89_g74000.g;
			float lerpResult3673_g54098 = lerp( 0.0 , Global_Extras_Wetness305_g54098 , _GlobalWetness);
			half Final_SmoothnessAndWetness4130_g54098 = saturate( ( Final_Smoothness371_g54098 + lerpResult3673_g54098 ) );
			o.Smoothness = Final_SmoothnessAndWetness4130_g54098;
			float lerpResult240_g54098 = lerp( 1.0 , tex2DNode35_g54098.g , _MainOcclusionValue);
			half Main_Occlusion247_g54098 = lerpResult240_g54098;
			half Blend_Occlusion323_g54098 = Main_Occlusion247_g54098;
			o.Occlusion = Blend_Occlusion323_g54098;
			float localCustomAlphaClip19_g74036 = ( 0.0 );
			float Main_Alpha316_g54098 = ( _MainColor.a * tex2DNode29_g54098.a );
			half Global_Extras_Alpha1033_g54098 = saturate( break89_g74000.a );
			float lerpResult5154_g54098 = lerp( 0.1 , Global_MeshVariation5104_g54098 , _AlphaVariationValue);
			half Global_Alpha_Variation5158_g54098 = lerpResult5154_g54098;
			half Global_Alpha_Mask4546_g54098 = 1.0;
			float lerpResult5203_g54098 = lerp( 1.0 , ( ( Global_Extras_Alpha1033_g54098 - Global_Alpha_Variation5158_g54098 ) + ( Global_Extras_Alpha1033_g54098 * 0.5 ) ) , ( Global_Alpha_Mask4546_g54098 * _GlobalAlpha ));
			float lerpResult16_g74034 = lerp( 1.0 , lerpResult5203_g54098 , TVE_Enabled);
			half AlphaTreshold2132_g54098 = _AlphaClipValue;
			half Global_Alpha315_g54098 = ( lerpResult16_g74034 + AlphaTreshold2132_g54098 );
			half Fade_Alpha3727_g54098 = 1.0;
			float temp_output_661_0_g54098 = ( Main_Alpha316_g54098 * Global_Alpha315_g54098 * Fade_Alpha3727_g54098 );
			half Alpha34_g74031 = temp_output_661_0_g54098;
			half Offest27_g74031 = AlphaTreshold2132_g54098;
			half AlphaFeather5305_g54098 = _AlphaFeatherValue;
			half Feather30_g74031 = AlphaFeather5305_g54098;
			float temp_output_25_0_g74031 = ( ( ( Alpha34_g74031 - Offest27_g74031 ) / ( max( fwidth( Alpha34_g74031 ) , 0.001 ) + Feather30_g74031 ) ) + Offest27_g74031 );
			float temp_output_3_0_g74036 = temp_output_25_0_g74031;
			float Alpha19_g74036 = temp_output_3_0_g74036;
			float temp_output_15_0_g74036 = AlphaTreshold2132_g54098;
			float Treshold19_g74036 = temp_output_15_0_g74036;
			{
			#if defined (TVE_FEATURE_CLIP)
			#if defined (TVE_IS_HD_PIPELINE)
				#if !defined (SHADERPASS_FORWARD_BYPASS_ALPHA_TEST)
					clip(Alpha19_g74036 - Treshold19_g74036);
				#endif
				#if !defined (SHADERPASS_GBUFFER_BYPASS_ALPHA_TEST)
					clip(Alpha19_g74036 - Treshold19_g74036);
				#endif
			#else
				clip(Alpha19_g74036 - Treshold19_g74036);
			#endif
			#endif
			}
			half Final_Alpha914_g54098 = saturate( Alpha19_g74036 );
			o.Alpha = Final_Alpha914_g54098;
		}

		ENDCG
	}
	Fallback "Hidden/BOXOPHOBIC/The Vegetation Engine/Fallback"
	CustomEditor "TVEShaderCoreGUI"
}
/*ASEBEGIN
Version=18935
1920;6;1920;1023;2586.067;1056.147;1;False;False
Node;AmplifyShaderEditor.RangedFloatNode;20;-1984,-768;Half;False;Property;_render_src;_render_src;200;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;10;-2176,-768;Half;False;Property;_render_cull;_render_cull;199;1;[HideInInspector];Create;True;0;3;Both;0;Back;1;Front;2;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;7;-1792,-768;Half;False;Property;_render_dst;_render_dst;201;1;[HideInInspector];Create;True;0;2;Opaque;0;Transparent;1;0;True;0;False;0;0;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;17;-1600,-768;Half;False;Property;_render_zw;_render_zw;202;1;[HideInInspector];Create;True;0;2;Opaque;0;Transparent;1;0;True;0;False;1;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;81;-1968,-896;Half;False;Property;_IsStandardShader;_IsStandardShader;198;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;0;1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.RangedFloatNode;168;-2176,-896;Half;False;Property;_IsGrassShader;_IsGrassShader;197;1;[HideInInspector];Create;True;0;0;0;True;0;False;1;0;1;1;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;583;-1344,-896;Inherit;False;Compile All Shaders;-1;;54094;e67c8238031dbf04ab79a5d4d63d1b4f;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;584;-1536,-896;Inherit;False;Compile Core;-1;;54095;634b02fd1f32e6a4c875d8fc2c450956;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;535;-2176,384;Inherit;False;Define Shader Grass;-1;;54096;921559c53826c0142ba6e27dd03eaef2;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;582;-1904,384;Inherit;False;Define Pipeline Standard;-1;;54097;9af03ae8defe78d448ef2a4ef3601e12;0;0;1;FLOAT;529
Node;AmplifyShaderEditor.RangedFloatNode;585;-1408,-768;Half;False;Property;_render_coverage;_render_coverage;204;1;[HideInInspector];Create;True;0;2;Opaque;0;Transparent;1;0;True;0;False;0;1;0;0;0;1;FLOAT;0
Node;AmplifyShaderEditor.FunctionNode;569;-2176,-384;Inherit;False;Base Shader;0;;54098;856f7164d1c579d43a5cf4968a75ca43;84,3880,1,4029,1,4028,1,3903,1,3900,1,3904,1,4204,1,3908,1,4172,1,1300,1,1298,1,4995,1,4179,1,3586,0,4499,1,1708,1,3658,1,3509,1,5151,0,3873,1,893,1,5196,0,5128,1,5156,1,5345,0,1715,1,1714,1,1718,1,1717,1,5075,1,916,0,1763,0,1762,0,3568,1,5118,0,1776,1,3475,1,4210,1,1745,1,3479,0,3501,1,5152,0,1646,1,1271,1,3889,0,2807,1,3886,0,4999,0,3887,0,3957,0,5357,0,2172,0,3883,0,3728,0,3949,0,5147,0,5146,1,5350,0,2658,1,1742,1,3484,0,1735,0,1737,0,5079,0,4837,0,1736,0,1733,0,1734,0,1550,0,878,0,860,1,2260,1,2261,1,2054,0,2032,0,5258,0,2062,1,2039,1,3243,1,5220,0,4217,1,4242,1,5090,1,5339,0;6;5115;FLOAT;1;False;5127;FLOAT;1;False;5143;FLOAT;1;False;5119;FLOAT;1;False;5117;FLOAT;1;False;5340;FLOAT3;0,0,0;False;23;FLOAT3;0;FLOAT3;528;FLOAT3;2489;FLOAT;531;FLOAT;4842;FLOAT;529;FLOAT;3678;FLOAT;530;FLOAT;4122;FLOAT;4134;FLOAT;1235;FLOAT;532;FLOAT;5389;FLOAT;721;FLOAT3;1230;FLOAT;5296;FLOAT;1461;FLOAT;1290;FLOAT;629;FLOAT3;534;FLOAT;4867;FLOAT4;5246;FLOAT4;4841
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;581;-1376,-384;Float;False;True;-1;4;TVEShaderCoreGUI;0;0;StandardSpecular;BOXOPHOBIC/The Vegetation Engine/Default/Grass Standard Lit;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;False;False;False;False;False;True;Back;0;True;17;0;False;-1;False;0;False;-1;0;False;-1;False;0;Custom;0.5;True;True;0;True;Opaque;;Geometry;All;18;all;True;True;True;True;0;False;-1;False;0;False;-1;255;False;-1;255;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;-1;False;2;15;10;25;False;0.5;True;1;0;True;20;0;True;7;0;0;False;-1;0;False;-1;0;False;-1;0;False;-1;0;False;0;0,0,0,0;VertexOffset;True;False;Cylindrical;False;True;Absolute;0;Hidden/BOXOPHOBIC/The Vegetation Engine/Fallback;203;-1;-1;-1;0;False;0;0;True;10;-1;0;False;-1;0;0;0;False;0.1;False;-1;0;True;585;False;16;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT3;0,0,0;False;4;FLOAT;0;False;5;FLOAT;0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0;False;9;FLOAT;0;False;10;FLOAT;0;False;13;FLOAT3;0,0,0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
Node;AmplifyShaderEditor.CommentaryNode;408;-2176,256;Inherit;False;1026.438;100;Features;0;;0,1,0.5,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;33;-2176,-512;Inherit;False;1024.392;100;Final;0;;0,1,0.5,1;0;0
Node;AmplifyShaderEditor.CommentaryNode;37;-2176,-1024;Inherit;False;1023.392;100;Internal;0;;1,0.252,0,1;0;0
WireConnection;581;0;569;0
WireConnection;581;1;569;528
WireConnection;581;2;569;2489
WireConnection;581;3;569;3678
WireConnection;581;4;569;530
WireConnection;581;5;569;531
WireConnection;581;9;569;532
WireConnection;581;11;569;534
ASEEND*/
//CHKSM=92A9F134551828D63CD0842E04779385A29A1998
