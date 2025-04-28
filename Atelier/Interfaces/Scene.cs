using Atelier.Interfaces.Events;
using SkiaSharp;

namespace Atelier.Interfaces;

public abstract class Scene
{
	public event ResizeEventHandler OnResize;
	
	public double Width { get; set; } = 100;
	public double Height { get; set; } = 100;
	
	public virtual List<AObject> Objects { get; protected set; } = [];
	public virtual void OnLoad() { }

	public virtual void Render(SKCanvas canvas)
	{
		foreach (AObject obj in Objects)
		{
			obj.Render(canvas);
		}
	}

	public virtual void Tick()
	{
		foreach (AObject obj in Objects)
		{
			obj.Tick();
		}
	}

	public void Resize(double width, double height)
	{
		Width = width;
		Height = height;
		OnResize(new ResizeEventArgs(width, height));
	}
}