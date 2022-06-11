#ifndef UTILITY
#define UTILITY

#include "UnityCG.cginc"

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

float3 mix(float3 x, float3 y, float a)
{
    return x * (1 - a) + y * a;
}

#endif