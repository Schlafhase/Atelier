namespace Atelier.Interfaces.Events;

public delegate void ClickEventHandler(ClickEventArgs e);

public class ClickEventArgs(MouseButton button, double x, double y, double movementX, double movementY) : EventArgs
{
    public MouseButton Button { get; } = button;
    public double X { get; } = x;
    public double Y { get; } = y;
    public double MovementX { get; } = movementX;
    public double MovementY { get; } = movementY;
}

[Flags]
public enum MouseButton
{
    Left = 1,
    Right = 2,
    Middle = 4,
    MB4 = 8,
    MB5 = 16
}