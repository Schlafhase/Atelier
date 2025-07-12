namespace Atelier.Interfaces;

public abstract class AObject
{
	public abstract void Render();
	public virtual void Tick(double dt = 16.6) { }
	
	public double X { get; set; }
	public double Y { get; set; }
	
	public Scene? Parent { get; set; }
}