namespace Atelier.Interfaces;

public abstract class AObject
{
    public abstract void Render();

    public virtual void Tick(double dt = 16.6)
    {
    }

    /// <summary>
    /// Initialises the component. Must be called after the raylib window and the parent scene have been initialised.
    /// </summary>
    public virtual void Init()
    {
    }

    public double X { get; set; }
    public double Y { get; set; }

    public Scene? Parent { get; set; }
}