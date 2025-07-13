using Atelier.Interfaces;
using Physics;
using Raylib_cs;
using Vectors;
using Rectangle = Atelier.ObjectTemplates.Rectangle;

namespace AtelierTestObjects;

public sealed class TestScene : TwoDCameraScene
{
    private readonly Rectangle _rect = new() { Color = Color.Red, Width = 100, Height = 100 };
    private readonly Mandelbrot _mandelbrot = new();
    private readonly PhysicsWorld _physWorld = new();

    public TestScene()
    {
        _physWorld.PhysicsObjects.Add(new PhysicsRectangle()
        {
            Position = new Vec2(20, 20),
            Size = new Vec2(100, 100)
        });

        _physWorld.PhysicsObjects.Add(new PhysicsRectangle()
        {
            Position = new Vec2(200, 20),
            Size = new Vec2(100, 100)
        });

        _physWorld.PhysicsObjects.Add(new PhysicsRectangle()
        {
            Position = new Vec2(0, 200),
            Size = new Vec2(1000, 100),
            KeepPosition = true
        });

        Objects = [_rect, _mandelbrot, _physWorld];
    }

    public override void Tick(double dt = 16.6)
    {
        base.Tick(dt);

        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            foreach (PhysicsObject obj in _physWorld.PhysicsObjects)
            {
                Vec2 mousePos = ToWorldSpace(Raylib.GetMousePosition());
                if (mousePos.X > obj.Position.X &&
                    mousePos.Y > obj.Position.Y &&
                    mousePos.X < obj.Position.X + obj.Size.X &&
                    mousePos.Y < obj.Position.Y + obj.Size.Y)
                {
                    obj.Position = mousePos - obj.Size / 2;
                    obj.Velocity = new Vec2(0);
                }
            }
        }
    }
}