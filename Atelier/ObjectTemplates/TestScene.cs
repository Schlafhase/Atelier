using Atelier.Interfaces;
using SkiaSharp;

namespace Atelier.ObjectTemplates;

public class TestScene : Scene
{
	private Rectangle rect = new() { Color = SKColors.Red, Width = 100, Height = 100, ParentWidth = 100 };

	public TestScene()
	{
		Objects = [rect];
	}

	public override void Render(SKCanvas canvas)
	{
		canvas.Clear(SKColors.Transparent);
		base.Render(canvas);
	}
}