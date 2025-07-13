using Atelier.Interfaces;
using Raylib_cs;
using Vectors;
using Rectangle = Atelier.ObjectTemplates.Rectangle;

namespace Physics;

public sealed class PhysicsRectangle : PhysicsObject
{
    public PhysicsRectangle()
    {
        DisplayObject = new Rectangle()
        {
            Width = Size.X,
            Height = Size.Y,
            Color = Color.Lime
        };
    }

    public override void PrepareForRender()
    {
        base.PrepareForRender();

        if (Raylib.IsMouseButtonDown(MouseButton.Left))
        {
            Vec2 mousePos = Raylib.GetMousePosition();
            if (mousePos.X > Position.X && mousePos.Y > Position.Y
                                        && mousePos.X < Position.X + Size.X && mousePos.Y < Position.Y + Size.Y)
            {
                Position = mousePos - Size/2;
                Velocity = new Vec2(0);
            }
        }

        (DisplayObject as Rectangle)!.Width = Size.X;
        (DisplayObject as Rectangle)!.Height = Size.Y;
    }
}