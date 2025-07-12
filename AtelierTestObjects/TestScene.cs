using Atelier.Interfaces;
using Raylib_cs;

namespace AtelierTestObjects;

public sealed class TestScene : Scene
{
	private readonly Rectangle _rect = new() { Color = Color.Red, Width = 100, Height = 100};
	private readonly Mandelbrot _mandelbrot = new();

	public TestScene()
	{
		Objects = [_rect, _mandelbrot];
	}
}