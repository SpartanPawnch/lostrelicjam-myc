#ifndef UTILITY
#define UTILITY

#include "UnityCG.cginc"

/* blend modes */

float4 blend_overlay(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    float4 result1 = 1.0 - 2.0 * (1.0 - Base) * (1.0 - Blend);
    float4 result2 = 2.0 * Base * Blend;
    float4 zeroOrOne = step(Base, 0.5);
    Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    Out = lerp(Base, Out, Opacity);

    return Out;
}

float4 blend_burn(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out =  1.0 - (1.0 - Blend)/Base;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_darken(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = min(Blend, Base);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_difference(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = abs(Blend - Base);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_dodge(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Base / (1.0 - Blend);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_divide(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Base / (Blend + 0.000000000001);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_exclusion(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Blend + Base - (2.0 * Blend * Base);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_hardlight(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    float4 result1 = 1.0 - 2.0 * (1.0 - Base) * (1.0 - Blend);
    float4 result2 = 2.0 * Base * Blend;
    float4 zeroOrOne = step(Blend, 0.5);
    Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_hardmix(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = step(1 - Base, Blend);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_lighten(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = max(Blend, Base);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_linearburn(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Base + Blend - 1.0;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_lineardodge(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Base + Blend;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_linearlight(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Blend < 0.5 ? max(Base + (2 * Blend) - 1, 0) : min(Base + 2 * (Blend - 0.5), 1);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_linearlightaddsub(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Blend + 2.0 * Base - 1.0;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_multiply(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Base * Blend;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_negation(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = 1.0 - abs(1.0 - Blend - Base);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_pinlight(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    float4 check = step (0.5, Blend);
    float4 result1 = check * max(2.0 * (Base - 0.5), Blend);
    Out = result1 + (1.0 - check) * min(2.0 * Base, Blend);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_screen(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = 1.0 - (1.0 - Blend) * (1.0 - Base);
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_softlight(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    float4 result1 = 2.0 * Base * Blend + Base * Base * (1.0 - 2.0 * Blend);
    float4 result2 = sqrt(Base) * (2.0 * Blend - 1.0) + 2.0 * Base * (1.0 - Blend);
    float4 zeroOrOne = step(0.5, Blend);
    Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_subtract(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = Base - Blend;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_vividlight(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    float4 result1 = 1.0 - (1.0 - Blend) / (2.0 * Base);
    float4 result2 = Blend / (2.0 * (1.0 - Base));
    float4 zeroOrOne = step(0.5, Base);
    Out = result2 * zeroOrOne + (1 - zeroOrOne) * result1;
    Out = lerp(Base, Out, Opacity);
    return Out;
}

float4 blend_overwrite(float4 Base, float4 Blend, float Opacity)
{
    float4 Out;
    Out = lerp(Base, Blend, Opacity);
    return Out;
}


/* GLSL intrinstics */

float3 mix(float3 x, float3 y, float a)
{
    return x * (1 - a) + y * a;
}

float4 mix(float4 x, float4 y, float a)
{
    return x * (1 - a) + y * a;
}

float mix(float x, float y, float a)
{
    return x * (1 - a) + y * a;
}

float min(float a, float b, float c)
{
    return min(a, min(b, c));
}

/* helpers */

float3 rgb2hsv(float3 c)
{
    float4 K = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
    float4 p = mix(float4(c.bg, K.wz), float4(c.gb, K.xy), step(c.b, c.g));
    float4 q = mix(float4(p.xyw, c.r), float4(c.r, p.yzx), step(p.x, c.r));

    float d = q.x - min(q.w, q.y);
    float e = 1.0e-10;
    return float3(abs(q.z + (q.w - q.y) / (6.0 * d + e)), d / (q.x + e), q.x);
}

float3 hsv2rgb(float3 c)
{
    float4 K = float4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
    float3 p = abs(frac(c.xxx + K.xyz) * 6.0 - K.www);
    return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

#endif