Shader "fishShader" {

//Fish render before all objects, so fishbackground is revealed to camera.

    SubShader {
//This Queue call tells the graphics card that this should be drawn before any of the geometry. This is what give the shader its ability. It gets drawn before anything else and any thing drawn behind it gets clipped
        Tags {"Queue" = "Geometry-70" }     
        Lighting On
        ZTest LEqual
        ZWrite On
        ColorMask 0
        Pass {}
        
    }
}