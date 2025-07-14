using Atelier.Interfaces;
using Physics;
using Raylib_cs;
using Vectors;
using Rectangle = Atelier.ObjectTemplates.Rectangle;

namespace AtelierTestObjects;

public sealed class TestScene : TwoDCameraScene
{
    private readonly ConwaysGameOL _cgol = new();
    private readonly Mandelbrot _mandelbrot = new();
    private readonly PhysicsWorld _physWorld = new();
    private readonly Rectangle _rect = new() { Color = Color.Red, Width = 100, Height = 100 };
    private bool _drawing;
    private Vec2 _lastDrawPos;

    public TestScene()
    {
        _physWorld.PhysicsObjects.Add(new PhysicsRectangle
        {
            Position = new Vec2(20, 20),
            Size = new Vec2(100, 100)
        });

        _physWorld.PhysicsObjects.Add(new PhysicsRectangle
        {
            Position = new Vec2(200, 20),
            Size = new Vec2(100, 100)
        });

        _physWorld.PhysicsObjects.Add(new PhysicsRectangle
        {
            Position = new Vec2(0, 200),
            Size = new Vec2(1000, 100),
            KeepPosition = true
        });

        Objects = [_rect, _mandelbrot, _physWorld, _cgol];
    }

    public override void Tick(double dt = 16.6)
    {
        base.Tick(dt);

        if (Raylib.IsMouseButtonPressed(MouseButton.Right))
        {
            _lastDrawPos = ToWorldSpace(Raylib.GetMousePosition()) - 0.5;
            _drawing = true;
        }

        if (Raylib.IsMouseButtonReleased(MouseButton.Right))
        {
            _drawing = false;
        }

        if (_drawing)
        {
            Vec2 pos = ToWorldSpace(Raylib.GetMousePosition()) - 0.5;

            int x = (int)Math.Round(_lastDrawPos.X);
            int y = (int)Math.Round(_lastDrawPos.Y);

            while (x != (int)Math.Round(pos.X))
            {
                _cgol.Occupied.Add((x, y));
                x += (int)Math.Round(_lastDrawPos.X) > (int)Math.Round(pos.X) ? -1 : 1;
            }

            while (y != (int)Math.Round(pos.Y))
            {
                _cgol.Occupied.Add((x, y));
                y += (int)Math.Round(_lastDrawPos.Y) > (int)Math.Round(pos.Y) ? -1 : 1;
            }

            _cgol.Occupied.Add(((int)Math.Round(pos.X), (int)Math.Round(pos.Y)));

            _lastDrawPos = pos;
        }

        if (Raylib.IsKeyPressed(KeyboardKey.Space))
        {
            _cgol.Paused = !_cgol.Paused;
        }

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

    public override void Render()
    {
        _cgol.VisibleBoundsStart = ToWorldSpace(new Vec2(0)) - 1;
        _cgol.VisibleBoundsEnd = ToWorldSpace(new Vec2(Raylib.GetRenderWidth(), Raylib.GetRenderHeight()));

        base.Render();
        if (_cgol.Paused)
        {
            Raylib.BeginMode2D(Camera);

            Vec2 start = ToWorldSpace(new Vec2(0)) - 1;
            Vec2 end = ToWorldSpace(new Vec2(Raylib.GetRenderWidth(), Raylib.GetRenderHeight())) + 1;
            Vec2 count = end - start;

            for (int x = (int)start.X; x <= count.X + start.X; x++)
            {
                Raylib.DrawLine(x, (int)start.Y, x, (int)end.Y, Color.LightGray);
            }

            for (int y = (int)start.Y; y < count.Y + start.Y; y++)
            {
                Raylib.DrawLine((int)start.X, y, (int)end.X, y, Color.LightGray);
            }

            Raylib.EndMode2D();
        }

        Vec2 mousePos = ToWorldSpace(Raylib.GetMousePosition());
        Raylib.DrawText(mousePos.ToString(), 160, 20, 20, Color.White);
    }
}