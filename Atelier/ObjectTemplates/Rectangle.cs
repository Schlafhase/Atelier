using Atelier.Interfaces;
using Raylib_cs;

namespace Atelier.ObjectTemplates;

public class Rectangle : AObject
{
    public Color Color { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }


    public override void Render()
    {
        Raylib.DrawRectangle((int)X, (int)Y, (int)Width, (int)Height, Color);
    }
}