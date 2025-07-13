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

        (DisplayObject as Rectangle)!.Width = Size.X;
        (DisplayObject as Rectangle)!.Height = Size.Y;
    }
}