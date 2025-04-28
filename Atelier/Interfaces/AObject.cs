using SkiaSharp;

namespace Atelier.Interfaces;

public abstract class AObject
{
	public abstract void Render(SKCanvas canvas);
	public virtual void Tick() { }
	
	public double X { get; set; }
	public double Y { get; set; }
}