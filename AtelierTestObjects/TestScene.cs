using Atelier.Interfaces;
using Physics;
using Raylib_cs;
using Vectors;
using Rectangle = Atelier.ObjectTemplates.Rectangle;

namespace AtelierTestObjects;

public sealed class TestScene : Scene
{
	private readonly Rectangle _rect = new() { Color = Color.Red, Width = 100, Height = 100};
	private readonly Mandelbrot _mandelbrot = new();
	private readonly PhysicsWorld physWorld = new();

	public TestScene()
	{
		physWorld.PhysicsObjects.Add(new PhysicsRectangle()
		{
			Position = new Vec2(20, 20),
			Size = new Vec2(100, 100)
		});
		
		physWorld.PhysicsObjects.Add(new PhysicsRectangle()
		{
			Position = new Vec2(200, 20),
			Size = new Vec2(100, 100)
		});

		physWorld.PhysicsObjects.Add(new PhysicsRectangle()
		{
			Position = new Vec2(0, 200),
			Size = new Vec2(1000, 100),
			KeepPosition = true
		});
		
		Objects = [_rect, _mandelbrot, physWorld];
	}
}