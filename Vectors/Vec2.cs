using System.Numerics;
using Newtonsoft.Json;

namespace Vectors;

public readonly struct Vec2(double x, double y)
{
    public override string ToString() => $"({X}, {Y})";

    public readonly double X = x;
    public readonly double Y = y;

    public Vec2(double x) : this(x, x) { }

    public static Vec2 Up => new Vec2(0, -1);
    public static Vec2 Down => new Vec2(0, 1);
    public static Vec2 Left => new Vec2(-1, 0);
    public static Vec2 Right => new Vec2(1, 0);

    [JsonIgnore] public Vec2 YX => new(Y, X);

    public static Vec2 operator +(Vec2 a, Vec2 b) => new(a.X + b.X, a.Y + b.Y);

    public static Vec2 operator +(Vec2 a, double b) => new(a.X + b, a.Y + b);

    public static Vec2 operator +(double b, Vec2 a) => a + b; // Commutative addition


    public static Vec2 operator -(Vec2 a, Vec2 b) => new(a.X - b.X, a.Y - b.Y);

    public static Vec2 operator -(Vec2 a, double b) => new(a.X - b, a.Y - b);

    public static Vec2 operator -(double b, Vec2 a) => new(b - a.X, b - a.Y);


    public static Vec2 operator *(Vec2 a, Vec2 b) => new(a.X * b.X, a.Y * b.Y);

    public static Vec2 operator *(Vec2 a, double b) => new(a.X * b, a.Y * b);

    public static Vec2 operator *(double b, Vec2 a) => a * b; // Commutative multiplication


    public static Vec2 operator /(Vec2 a, Vec2 b) => new(a.X / b.X, a.Y / b.Y);

    public static Vec2 operator /(Vec2 a, double b) => new(a.X / b, a.Y / b);

    public static Vec2 operator /(double b, Vec2 a) => new(b / a.X, b / a.Y);


    public double Length => Math.Sqrt(X * X + Y * Y);

    public double DotProduct(Vec2 b) => X * b.X + Y * b.Y;

    public Vec2 Normalise() => this / Length;

    public static implicit operator Vector2(Vec2 vec2) => new Vector2((float)vec2.X, (float)vec2.Y);
    public static implicit operator Vec2(Vector2 vec2) => new Vec2(vec2.X, vec2.Y);
}