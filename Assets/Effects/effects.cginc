#ifndef EFFECTS
#define EFFECTS


#include "utility.cginc"
#include "UnityCG.cginc"


/* Chromatic Wheel */
// source: https://www.shadertoy.com/view/XtfGDN

float3 chromatic_wheel__hue2rgb(float a)
{
    return clamp(abs(frac(float3(a, a, a) + float3(3, 2, 1) / 3.) * 6. - 3.) - 1., 0., 1.);
}

float chromatic_wheel__sat(float x)
{
    float m = fmod(floor(x),8.);
    if( m < 4. )
        return 1. + m;
    else
        return 9. - m;
}

fixed4 chromatic_wheel(float2 uv)
{
    float2 cp = 2. * uv - 1.;
    float d = atan(cp.y / cp.x) / 6.283185; // -pi < atan() <= +pi
    float t = _Time.y / 3.;         // change every 3 seconds
    fixed4 f = fixed4(
        2. * mix(chromatic_wheel__hue2rgb(d * chromatic_wheel__sat(t)), chromatic_wheel__hue2rgb(d * chromatic_wheel__sat(t + 1.)), t - floor(t)),
        1.); // over-saturate to white with 2x

    return f;
}


/* Wobble */
// source: https://www.shadertoy.com/view/Mls3DH

float2 wobble__shift(float2 p, float speed, float frequency)
{
    float d = _Time.y * speed;
    float2 f = frequency * (p + d);
    float2 q = cos(float2(                        
       cos(f.x - f.y) * cos(f.y),                       
       sin(f.x + f.y) * sin(f.y)));
    
    return q;                                  
}     

float2 wobble(float2 uv, float speed, float frequency, float amplitude)
{
    float2 r = uv;
    float2 p = wobble__shift(r, speed, frequency);             
    float2 q = wobble__shift(r + 1.0, speed, frequency);

    return r + amplitude * (p - q);
}

#endif