using Atelier.Interfaces.Events;
using Raylib_cs;

namespace Atelier.Interfaces;

public abstract class Scene : IDisposable
{
	public event ResizeEventHandler OnResize;
	
	public double Width { get; private set; } = 1;
	public double Height { get; private set; } = 1;
	
	public virtual List<AObject> Objects { get; protected set; } = [];

	public virtual void Init()
	{
		foreach (AObject obj in Objects)
		{
			obj.Parent = this;
			obj.Init();
		}
	}

	public virtual void Render()
	{
		foreach (AObject obj in Objects)
		{
			obj.Render();
		}
	}

	public virtual void Tick(double dt = 16.6)
	{
		foreach (AObject obj in Objects)
		{
			obj.Tick(dt);
		}
	}

	public void Resize(double width, double height)
	{
		if ((int)Width == (int)width && (int)Height == (int)height)
		{
			return;
		}
		Width = width;
		Height = height;
		OnResize?.Invoke(new ResizeEventArgs(width, height));
	}

	public void Dispose()
	{
		foreach (AObject obj in Objects)
		{
			if (obj is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}
}