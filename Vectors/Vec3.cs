using Newtonsoft.Json;

namespace Vectors;

public readonly struct Vec3(double x, double y, double z)
{
    public override string ToString()
    {
        return $"({X}, {Y}, {Z})";
    }

    public readonly double X = x;
    public readonly double Y = y;
    public readonly double Z = z;

    public static Vec3 Up => new(0, 1, 0);
    public static Vec3 Down => new(0, -1, 0);
    public static Vec3 Left => new(-1, 0, 0);
    public static Vec3 Right => new(1, 0, 0);
    public static Vec3 Forward => new(0, 0, -1);
    public static Vec3 Back => new(0, 0, 1);

    #region Swizzling

    [JsonIgnore] public Vec2 XY => new(X, Y);
    [JsonIgnore] public Vec2 XZ => new(X, Z);

    [JsonIgnore] public Vec2 YX => new(Y, X);
    [JsonIgnore] public Vec2 YZ => new(Y, Z);

    [JsonIgnore] public Vec2 ZX => new(Z, X);
    [JsonIgnore] public Vec2 ZY => new(Z, Y);

    #endregion

    public static Vec3 operator +(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vec3 operator +(Vec3 a, double b)
    {
        return new Vec3(a.X + b, a.Y + b, a.Z + b);
    }

    public static Vec3 operator +(double b, Vec3 a)
    {
        return a + b;
        // Commutative addition
    }


    public static Vec3 operator -(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vec3 operator -(Vec3 a, double b)
    {
        return new Vec3(a.X - b, a.Y - b, a.Z - b);
    }

    public static Vec3 operator -(double b, Vec3 a)
    {
        return new Vec3(b - a.X, b - a.Y, b - a.Z);
    }


    public static Vec3 operator *(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
    }

    public static Vec3 operator *(Vec3 a, double b)
    {
        return new Vec3(a.X * b, a.Y * b, a.Z * b);
    }

    public static Vec3 operator *(double b, Vec3 a)
    {
        return a * b;
        // Commutative multiplication
    }


    public static Vec3 operator /(Vec3 a, Vec3 b)
    {
        return new Vec3(a.X / b.X, a.Y / b.Y, a.Z / b.Z);
    }

    public static Vec3 operator /(Vec3 a, double b)
    {
        return new Vec3(a.X / b, a.Y / b, a.Z / b);
    }

    public static Vec3 operator /(double b, Vec3 a)
    {
        return new Vec3(b / a.X, b / a.Y, b / a.Z);
    }


    public double Length => Math.Sqrt(X * X + Y * Y + Z * Z);


    public double DotProduct(Vec3 b)
    {
        return X * b.X + Y * b.Y + Z * b.Z;
    }


    public Vec3 Normalise()
    {
        return this / Length;
    }
}