using UnityEngine;
using System;
using ProWPack.Core.Struct.FixedPointy;

public class MathParabola
{

    public static Vector3 Parabola(Vector3 start, Vector3 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }

    public static Vector2 Parabola(Vector2 start, Vector2 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector2.Lerp(start, end, t);

        return new Vector2(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t));
    }

    public static FixVec2 Parabola(FixVec2 start, FixVec2 end, float height, float t)
    {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;        
        int lerpX = (int)Mathf.Lerp((float)start.X, (float)end.X, t);
        int lerpY = (int)Mathf.Lerp((float)start.Y, (float)end.Y, t);        
        return new FixVec2(lerpX, (int)f(t) + lerpY);
    }

}