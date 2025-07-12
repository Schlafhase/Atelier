using Atelier.Interfaces.Events;
using Raylib_cs;

namespace Atelier.Interfaces;

public abstract class Scene : IDisposable
{
	public event ResizeEventHandler OnResize;
	
	public double Width { get; private set; } = 1;
	public double Height { get; private set; } = 1;
	
	public virtual List<AObject> Objects { get; protected set; } = [];
	public virtual void OnLoad() { }

	private Image _blankImage;
	public Texture2D BlankTexture { get; private set; }

	public void Init()
	{
		updateTexture();
	}

	private void updateTexture()
	{
		Raylib.UnloadTexture(BlankTexture);
		_blankImage = Raylib.GenImageColor((int)Width, (int)Height, Color.White);
		BlankTexture = Raylib.LoadTextureFromImage(_blankImage);
		Raylib.UnloadImage(_blankImage);
	}
	
	public virtual void Render()
	{
		foreach (AObject obj in Objects)
		{
			obj.Parent = this;
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
		if (Math.Abs(Width - width) < 1 && Math.Abs(Height - height) < 1)
		{
			return;
		}
		Width = width;
		Height = height;
		OnResize?.Invoke(new ResizeEventArgs(width, height));
		updateTexture();
	}

	public void Dispose()
	{
		Raylib.UnloadTexture(BlankTexture);
		foreach (AObject obj in Objects)
		{
			if (obj is IDisposable disposable)
			{
				disposable.Dispose();
			}
		}
	}
}