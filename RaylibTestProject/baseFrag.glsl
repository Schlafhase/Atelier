#version 330

// Input vertex attributes (from vertex shader)
in vec2 fragTexCoord;
in vec4 fragColor;

// Input uniform values
uniform sampler2D texture0;
uniform vec4 colDiffuse;
uniform vec2 u_resolution;

// Output fragment color
out vec4 finalColor;

// NOTE: Add your custom variables here

void main()
{
    // Texel color fetching from texture sampler
    vec2 uv = (fragTexCoord.xy * 2.-u_resolution.xy)/u_resolution.y;

    // NOTE: Implement here your fragment shader code

    // final color is the color from the texture 
    //    times the tint color (colDiffuse)
    //    times the fragment color (interpolated vertex color)
    finalColor = vec4(uv.xy, 1., 1.);
}