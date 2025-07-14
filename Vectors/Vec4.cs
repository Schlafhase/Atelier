using Newtonsoft.Json;
using Raylib_cs;

namespace Vectors;

public readonly struct Vec4(double x, double y, double z, double w)
{
    public override string ToString()
    {
        return $"({X}, {Y}, {Z}, {W})";
    }

    public readonly double X = x;
    public readonly double Y = y;
    public readonly double Z = z;
    public readonly double W = w;

    public Vec4(Vec2 vec2, double z, double w) : this(vec2.X, vec2.Y, z, w)
    {
    }

    public Vec4(Vec3 vec3, double w) : this(vec3.X, vec3.Y, vec3.Z, w)
    {
    }

    #region Swizzling

    [JsonIgnore] public Vec2 XY => new(X, Y);
    [JsonIgnore] public Vec2 XZ => new(X, Z);
    [JsonIgnore] public Vec2 XW => new(X, W);
    [JsonIgnore] public Vec2 YX => new(Y, X);
    [JsonIgnore] public Vec2 YZ => new(Y, Z);
    [JsonIgnore] public Vec2 YW => new(Y, W);
    [JsonIgnore] public Vec2 ZX => new(Z, X);
    [JsonIgnore] public Vec2 ZY => new(Z, Y);
    [JsonIgnore] public Vec2 ZW => new(Z, W);

    [JsonIgnore] public Vec3 XYZ => new(X, Y, Z);
    [JsonIgnore] public Vec3 XYW => new(X, Y, W);
    [JsonIgnore] public Vec3 XZY => new(X, Z, Y);
    [JsonIgnore] public Vec3 XZW => new(X, Z, W);
    [JsonIgnore] public Vec3 XWY => new(X, W, Y);
    [JsonIgnore] public Vec3 XWZ => new(X, W, Z);

    [JsonIgnore] public Vec3 YXZ => new(Y, X, Z);
    [JsonIgnore] public Vec3 YXW => new(Y, X, W);
    [JsonIgnore] public Vec3 YZX => new(Y, Z, X);
    [JsonIgnore] public Vec3 YZW => new(Y, Z, W);
    [JsonIgnore] public Vec3 YWX => new(Y, W, X);
    [JsonIgnore] public Vec3 YWZ => new(Y, W, Z);

    [JsonIgnore] public Vec3 ZXY => new(Z, X, Y);
    [JsonIgnore] public Vec3 ZXW => new(Z, X, W);
    [JsonIgnore] public Vec3 ZYX => new(Z, Y, X);
    [JsonIgnore] public Vec3 ZYW => new(Z, Y, W);
    [JsonIgnore] public Vec3 ZWX => new(Z, W, X);
    [JsonIgnore] public Vec3 ZWY => new(Z, W, Y);

    [JsonIgnore] public Vec3 WXY => new(W, X, Y);
    [JsonIgnore] public Vec3 WXZ => new(W, X, Z);
    [JsonIgnore] public Vec3 WYX => new(W, Y, X);
    [JsonIgnore] public Vec3 WYZ => new(W, Y, Z);
    [JsonIgnore] public Vec3 WZX => new(W, Z, X);
    [JsonIgnore] public Vec3 WZY => new(W, Z, Y);

    #endregion

    #region Colors

    public static Vec4 Black => new(0d, 0d, 0d, 1d);
    public static Vec4 White => new(1d, 1d, 1d, 1d);
    public static Vec4 Red => new(1d, 0d, 0d, 1d);
    public static Vec4 Green => new(0d, 1d, 0d, 1d);
    public static Vec4 Blue => new(0d, 0d, 1d, 1d);
    public static Vec4 DarkBlue => new(0d, 0d, 0.54d, 1d);
    public static Vec4 Aqua => new(0d, 1d, 1d, 1d);
    public static Vec4 Yellow => new(1d, 1d, 0d, 1d);
    public static Vec4 Orange => new(1d, 0.65d, 0d, 1d);
    public static Vec4 OrangeRed => new(1d, 0.27d, 0d, 1d);
    public static Vec4 Crimson => new(0.86d, 0.08d, 0.24d, 1d);

    #endregion

    public static Vec4 operator +(Vec4 a, Vec4 b)
    {
        return new Vec4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);
    }

    public static Vec4 operator +(Vec4 a, double b)
    {
        return new Vec4(a.X + b, a.Y + b, a.Z + b, a.W + b);
    }

    public static Vec4 operator +(double b, Vec4 a)
    {
        return a + b;
        // Commutative addition
    }


    public static Vec4 operator -(Vec4 a, Vec4 b)
    {
        return new Vec4(a.X - b.X, a.Y - b.Y, a.Z - b.Z, a.W - b.W);
    }

    public static Vec4 operator -(Vec4 a, double b)
    {
        return new Vec4(a.X - b, a.Y - b, a.Z - b, a.W - b);
    }

    public static Vec4 operator -(double b, Vec4 a)
    {
        return new Vec4(b - a.X, b - a.Y, b - a.Z, b - a.W);
    }


    public static Vec4 operator *(Vec4 a, Vec4 b)
    {
        return new Vec4(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * b.W);
    }

    public static Vec4 operator *(Vec4 a, double b)
    {
        return new Vec4(a.X * b, a.Y * b, a.Z * b, a.W * b);
    }

    public static Vec4 operator *(double b, Vec4 a)
    {
        return a * b;
        // Commutative multiplication
    }


    public static Vec4 operator /(Vec4 a, Vec4 b)
    {
        return new Vec4(a.X / b.X, a.Y / b.Y, a.Z / b.Z, a.W / b.W);
    }

    public static Vec4 operator /(Vec4 a, double b)
    {
        return new Vec4(a.X / b, a.Y / b, a.Z / b, a.W / b);
    }

    public static Vec4 operator /(double b, Vec4 a)
    {
        return new Vec4(b / a.X, b / a.Y, b / a.Z, b / a.W);
    }


    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z + W * W);

    public double DotProduct(Vec4 b)
    {
        return X * b.X + Y * b.Y + Z * b.Z + W * b.W;
    }

    public Vec4 Normalise()
    {
        return this / Length;
    }


    public static implicit operator Color(Vec4 vec)
    {
        return new Color((int)(MathV.Clamp01(vec.X) * 255),
            (int)(MathV.Clamp01(vec.Y) * 255),
            (int)(MathV.Clamp01(vec.Z) * 255),
            (int)(MathV.Clamp01(vec.W) * 255));
    }
}