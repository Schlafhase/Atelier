#version 330

#define PI 3.14159265359
#define TWO_PI 6.28318530718
#define center vec2(-0.74326380829271044,0.18079212896068195)
#define angle (PI/4.)
#define squareSize 3.
#define iterations 10000

// Input vertex attributes (from vertex shader)
in vec2 fragTexCoord;
in vec4 fragColor;

// Input uniform values
uniform sampler2D texture0;
uniform vec4 colDiffuse;
uniform vec2 u_resolution;
uniform float u_time;

// Output fragment color
out vec4 finalColor;


float remap( float minval, float maxval, float curval )
{
    return ( curval - minval ) / ( maxval - minval );
}

vec4 getColor(float i)
{
  vec3 lightblue = vec3(0., 0.68, 1.);
  vec3 yellow = vec3(0.851, 1.0, 0.0);
  vec3 orange = vec3(1.0, 0.6824, 0.0);
  vec3 pink = vec3(1.0, 0.0, 0.8667);
  float cCount = 4.;
  
  vec3 c = vec3(0.);

  if(i == -1.)
  {
    return vec4(c, 0.);
  }
  float value = 25.;
  // i = exp(i);
  // i = i/value;
  float OGi = i;
  i = mod(i, value);

  if (i < value/cCount)
    c = mix(vec4(lightblue, 1.), vec4(yellow,1.), remap(-1., value/cCount, i)).xyz;
  else if (i < 2.*value/cCount)
    c = mix(vec4(yellow, 1.), vec4(orange,1.), remap(value/cCount, 2.*value/cCount, i)).xyz;
  else if (i < 3.*value/cCount)
    c = mix(vec4(orange, 1.), vec4(pink,1.), remap(2.*value/cCount, 3.*value/cCount, i)).xyz;
  else
    c = mix(vec4(pink, 1.), vec4(lightblue,1.), remap(3.*value/cCount, 4.*value/cCount, i)).xyz;

  return vec4(c, OGi/50);
}

void main()
{
  float size = 5.5;
  float ratio = u_resolution.x/u_resolution.y;
  vec2 uv = fragTexCoord -0.5;
  uv.x *= ratio;
  
  float r = length(uv);
  float theta = atan(uv.x, uv.y);
  theta += angle;
  uv = vec2(sin(theta)*r, cos(theta)*r);
  
  float x0 = (uv.x*(size/2.))+center.x;
  float y0 = (uv.y*(size/2.))+center.y;
  float x = 0.;
  float y = 0.;

  float p = -1.;

  for (int i = 0; i < iterations; i++)
  {
    if (x*x + y*y > 4.)
    {
      float mod = sqrt(mod(p, 2.));
      p = float(i) - log2(max(1., log2(mod)));
      break;
    }
    float xTemp = x*x - y*y + x0;
    y = 2.*x*y + y0;
    x = xTemp;
  }
  
  finalColor = getColor(p);
  // gl_FragColor = vec4(vec3(smoothstep(0., 20.,p)), 1.);
}
