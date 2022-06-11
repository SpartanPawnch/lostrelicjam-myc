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
    float d = atan2(cp.y, cp.x) / 6.283185; // -pi < atan() <= +pi
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


/* Eye of Ezbhan */
// source: https://www.shadertoy.com/view/td3Xzr

float2 ezbhan__spiralPosition(float t)
{
    float THETA = 2.399963229728653;
    float angle = t * THETA - _Time.y * .001; 
    float radius = ( t + .5 ) * .5;
    return float2(radius * cos(angle) + .5, radius * sin(angle) + .5 );
}

fixed4 ezbhan(float2 iuv, float ratio)
{
    ratio = 1. / ratio;
    float2 suv = iuv;
    suv.y = suv.y * ratio;
    float2 sres = float2(1.0, ratio);
    
    float2 uv = (suv - .5 * sres) / sres.y * 1024.;
    
    float a = 0.;
    float d = 50.;
    
    for(int i = 0; i < 256; i++)
    {
        float2 pointDist = uv - ezbhan__spiralPosition(float(i)) * 6.66;
        a += atan2(pointDist.x, pointDist.y);
        d = min(dot( pointDist, pointDist), d);
    }
    
    d = sqrt(d) * .02;
    d = 1. - pow(1. - d, 32.);
    a += sin(length(uv) * .01 + _Time.y * .5 ) * 2.75;
    float3 col = d * (.5 + .5 * sin(a + _Time.y + float3( 2.9, 1.7, 0)));

    return fixed4(col, 1.0);
}

/* Waves */
//source: https://www.shadertoy.com/view/NtByDt
float waves__dx(float2 p) {
    return -normalize(p).x * sin(length(p) - _Time.y);
}

fixed4 waves(float2 iuv, float ratio, float2 light_position)
{
    ratio = 1. / ratio;
    float2 suv = iuv;
    suv.y = suv.y * ratio;
    float2 sres = float2(1.0, ratio);

    float2 light_suv = light_position;
    light_suv.y = light_suv.y * ratio;
    
    float2 uv = (2 * suv - sres) / sres.y * 10.;
    float2 light_uv =  (2 * light_suv - sres) / sres.y * 10.;

    float3 n = normalize(cross(float3(1, 0, waves__dx(uv)), float3(0, 1, waves__dx(uv.yx))));
    float3 mousedir = float3(light_uv, 1);
    float v = dot(n, mousedir);
    float3 col  = v < 0. ? -v * float3(.1, .1, .2) : v * float3(.7, .7, .5);
    
    return fixed4(col, 1.0);
}

#endif