namespace Atelier.Interfaces.Events;

public delegate void ResizeEventHandler(ResizeEventArgs e);

public class ResizeEventArgs(double width, double height) : EventArgs
{
    public double Width { get; } = width;
    public double Height { get; } = height;
}