using Atelier.Interfaces;
using SkiaSharp;

namespace Atelier.ObjectTemplates;

public class Rectangle : AObject
{
	public SKColor Color { get; set; }
	public float Width { get; set; }
	public float Height { get; set; }
	
	public float ParentWidth { get; set; }

	private int step = 1;

	public override void Render(SKCanvas canvas)
	{
		canvas.DrawRect((float)X, (float)Y, Width, Height, new SKPaint() { Color = Color });
	}

	public override void Tick()
	{
		X += step;

		if (X >= ParentWidth || X <= 0)
		{
			step *= -1;
		}
	}
}