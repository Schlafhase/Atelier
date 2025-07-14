using System.Collections.Immutable;

namespace Vectors;

/// <summary>
///     A static class that provides math functions for vectors.
/// </summary>
public static class MathV
{
    /// <summary>
    ///     Interpolates smoothly between 0 and 1 based on the input value and edge thresholds.
    /// </summary>
    /// <param name="edge0">The lower edge of the transition.</param>
    /// <param name="edge1">The upper edge of the transition.</param>
    /// <param name="x">The input value to interpolate, assumed to be between edge0 and edge1.</param>
    /// <returns>A <see cref="double" /> that represents the smoothed interpolation result.</returns>
    public static double SmoothStep(double edge0, double edge1, double x)
    {
        x = Clamp01((x - edge0) / (edge1 - edge0));
        return x * x * (3 - 2 * x);
    }

    // [SupportedOSPlatform("windows")]
    // public static Bitmap ToBitmap(this Vec4[] image, Vec2 resolution)
    // {
    // 	Bitmap bitmap = new((int)resolution.X, (int)resolution.Y);
    //
    // 	for (int y = 0; y < resolution.Y; y++)
    // 	{
    // 		for (int x = 0; x < resolution.X; x++)
    // 		{
    // 			Vec4 fragColor = image[x + y * (int)resolution.X];
    // 			bitmap.SetPixel(x, y, fragColor);
    // 		}
    // 	}
    //
    // 	return bitmap;
    // }

    #region Clamp

    /// <summary>
    ///     Clamps a <see cref="double" /> between 0 and 1.
    /// </summary>
    /// <param name="value">The <see cref="double" /> to be clamped.</param>
    /// <returns>A clamped value between 0 and 1</returns>
    public static double Clamp01(double value)
    {
        // Return 0 if value is smaller than 0; return 1 if value is greater than 1; otherwise return value.
        return value < 0 ? 0 : value > 1 ? 1 : value;
    }

    /// <summary>
    ///     A Clamp01 method for <see cref="Vec2" />. It clamps every component of the provided <see cref="Vec2" />
    ///     between 0 and 1 using the <see cref="Clamp01(double)" /> method.
    /// </summary>
    /// <param name="value">The <see cref="Vec2" /> to be clamped</param>
    /// <returns>A <see cref="Vec2" /> whose components are clamped between 0 and 1</returns>
    public static Vec2 Clamp01(Vec2 value)
    {
        return new Vec2(Clamp01(value.X), Clamp01(value.Y));
    }

    /// <summary>
    ///     A Clamp01 method for <see cref="Vec3" />. It clamps every component of the provided <see cref="Vec3" />
    ///     between 0 and 1 using the <see cref="Clamp01(double)" /> method.
    /// </summary>
    /// <param name="value">The <see cref="Vec3" /> to be clamped</param>
    /// <returns>A <see cref="Vec3" /> whose components are clamped between 0 and 1</returns>
    public static Vec3 Clamp01(Vec3 value)
    {
        return new Vec3(Clamp01(value.X), Clamp01(value.Y), Clamp01(value.Z));
    }

    /// <summary>
    ///     A Clamp01 method for <see cref="Vec4" />. It clamps every component of the provided <see cref="Vec4" />
    ///     between 0 and 1 using the <see cref="Clamp01(double)" /> method.
    /// </summary>
    /// <param name="value">The <see cref="Vec4" /> to be clamped</param>
    /// <returns>A <see cref="Vec4" /> whose components are clamped between 0 and 1</returns>
    public static Vec4 Clamp01(Vec4 value)
    {
        return new Vec4(Clamp01(value.X), Clamp01(value.Y), Clamp01(value.Z), Clamp01(value.W));
    }

    #endregion

    #region Linear Interpolation

    /// <summary>
    ///     Interpolates between to <see cref="double" /> values.
    /// </summary>
    /// <param name="a">The starting value</param>
    /// <param name="b">The destination value</param>
    /// <param name="t">
    ///     The percentage of the interpolation. If t is 1, then the result is b.
    ///     If t is 0, then the result is a.
    /// </param>
    /// <returns>The interpolated value between <see cref="a" /> and <see cref="b" /></returns>
    public static double Lerp(double a, double b, double t)
    {
        return a * (1 - t) + b * t;
    }

    /// <summary>
    ///     A Lerp function for <see cref="Vec2" />. It interpolates between two <see cref="Vec2" /> values.
    /// </summary>
    /// <param name="a">The starting value</param>
    /// <param name="b">The destination value</param>
    /// <param name="t">
    ///     The percentage of the interpolation. If t is 1, then the result is b.
    ///     If t is 0, then the result is a.
    /// </param>
    /// <returns>The interpolated value between <see cref="a" /> and <see cref="b" /></returns>
    public static Vec2 Lerp(Vec2 a, Vec2 b, double t)
    {
        return new Vec2(Lerp(a.X, b.X, t), Lerp(a.Y, b.Y, t));
    }

    /// <summary>
    ///     Interpolates between two <see cref="Vec3" /> values.
    /// </summary>
    /// <param name="a">The starting value</param>
    /// <param name="b">The destination value</param>
    /// <param name="t">
    ///     The percentage of the interpolation. If t is 1, then the result is b.
    ///     If t is 0, then the result is a.
    /// </param>
    /// <returns>The interpolated value between <see cref="a" /> and <see cref="b" /></returns>
    public static Vec3 Lerp(Vec3 a, Vec3 b, double t)
    {
        return new Vec3(Lerp(a.X, b.X, t), Lerp(a.Y, b.Y, t), Lerp(a.Z, b.Z, t));
    }

    /// <summary>
    ///     Interpolates between two <see cref="Vec4" /> values.
    /// </summary>
    /// <param name="a">The starting value</param>
    /// <param name="b">The destination value</param>
    /// <param name="t">
    ///     The percentage of the interpolation. If t is 1, then the result is b.
    ///     If t is 0, then the result is a.
    /// </param>
    /// <returns>The interpolated value between <see cref="a" /> and <see cref="b" /></returns>
    public static Vec4 Lerp(Vec4 a, Vec4 b, double t)
    {
        return new Vec4(Lerp(a.X, b.X, t), Lerp(a.Y, b.Y, t), Lerp(a.Z, b.Z, t), Lerp(a.W, b.W, t));
    }

    /// <summary>
    ///     Interpolates between multiple <see cref="Vec4" /> values.
    /// </summary>
    /// <param name="values">The array of values to be interpolated between</param>
    /// <param name="t">
    ///     The percentage of the interpolation. If t is 1, then the result is the last element of the <see cref="values" />
    ///     array.
    ///     If t is 0, then the result is the first element of the <see cref="values" /> array.
    /// </param>
    /// <returns>An interpolated value between two elements of the <see cref="values" /> array.</returns>
    public static Vec4 LerpMultiple(Vec4[] values, double t)
    {
        t = Clamp01(t);
        int index = (int)(t * (values.Length - 1));
        double t2 = t * (values.Length - 1) - index;
        return Lerp(values[index], values[index + 1], t2);
    }

    /// <summary>
    ///     Interpolates between multiple <see cref="Vec4" /> values in an <see cref="ImmutableArray{T}" />.
    ///     This can be useful in shader kernels due to the limitations of GPU programming.
    /// </summary>
    /// <param name="values">The array of values to be interpolated between</param>
    /// <param name="t">
    ///     The percentage of the interpolation. If t is 1, then the result is the last element of the <see cref="values" />
    ///     array.
    ///     If t is 0, then the result is the first element of the <see cref="values" /> array.
    /// </param>
    /// <returns>An interpolated value between two elements of the <see cref="values" /> array.</returns>
    public static Vec4 LerpMultiple(ImmutableArray<Vec4> values, double t)
    {
        t = Clamp01(t);
        int index = (int)(t * (values.Length - 1));
        double t2 = t * (values.Length - 1) - index;
        return Lerp(values[index], values[index + 1], t2);
    }

    #endregion
}