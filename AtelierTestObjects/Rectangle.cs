using Atelier.Interfaces;
using Raylib_cs;

namespace AtelierTestObjects;

public class Rectangle : AObject
{
	public Color Color { get; set; }
	public float Width { get; set; }
	public float Height { get; set; }
	
	
	private int _step = 10;

	public override void Render()
	{
		Raylib.DrawRectangle((int)X, (int)Y, (int)Width, (int)Height, Color);
	}

	public override void Tick(double dt = 16.6)
	{
		if (Parent is null)
		{
			return;
		}
		
		X += _step * (dt/16.6);

		if (X >= Parent.Width || X <= 0)
		{
			_step *= -1;
		}
	}
}