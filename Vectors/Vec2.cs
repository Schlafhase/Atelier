using System.Numerics;
using Newtonsoft.Json;

namespace Vectors;

public readonly struct Vec2(double x, double y)
{
    public override string ToString()
    {
        return $"({X}, {Y})";
    }

    public readonly double X = x;
    public readonly double Y = y;

    public Vec2(double x) : this(x, x)
    {
    }

    public static Vec2 Up => new(0, -1);
    public static Vec2 Down => new(0, 1);
    public static Vec2 Left => new(-1, 0);
    public static Vec2 Right => new(1, 0);

    [JsonIgnore] public Vec2 YX => new(Y, X);

    public static Vec2 operator +(Vec2 a, Vec2 b)
    {
        return new Vec2(a.X + b.X, a.Y + b.Y);
    }

    public static Vec2 operator +(Vec2 a, double b)
    {
        return new Vec2(a.X + b, a.Y + b);
    }

    public static Vec2 operator +(double b, Vec2 a)
    {
        return a + b;
        // Commutative addition
    }


    public static Vec2 operator -(Vec2 a, Vec2 b)
    {
        return new Vec2(a.X - b.X, a.Y - b.Y);
    }

    public static Vec2 operator -(Vec2 a, double b)
    {
        return new Vec2(a.X - b, a.Y - b);
    }

    public static Vec2 operator -(double b, Vec2 a)
    {
        return new Vec2(b - a.X, b - a.Y);
    }


    public static Vec2 operator *(Vec2 a, Vec2 b)
    {
        return new Vec2(a.X * b.X, a.Y * b.Y);
    }

    public static Vec2 operator *(Vec2 a, double b)
    {
        return new Vec2(a.X * b, a.Y * b);
    }

    public static Vec2 operator *(double b, Vec2 a)
    {
        return a * b;
        // Commutative multiplication
    }


    public static Vec2 operator /(Vec2 a, Vec2 b)
    {
        return new Vec2(a.X / b.X, a.Y / b.Y);
    }

    public static Vec2 operator /(Vec2 a, double b)
    {
        return new Vec2(a.X / b, a.Y / b);
    }

    public static Vec2 operator /(double b, Vec2 a)
    {
        return new Vec2(b / a.X, b / a.Y);
    }


    public double Length => Math.Sqrt(X * X + Y * Y);

    public double DotProduct(Vec2 b)
    {
        return X * b.X + Y * b.Y;
    }

    public Vec2 Normalise()
    {
        return this / Length;
    }

    public static implicit operator Vector2(Vec2 vec2)
    {
        return new Vector2((float)vec2.X, (float)vec2.Y);
    }

    public static implicit operator Vec2(Vector2 vec2)
    {
        return new Vec2(vec2.X, vec2.Y);
    }
}