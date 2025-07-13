using Atelier.Interfaces;
using Vectors;

namespace Physics;

public abstract class PhysicsObject
{
    public Vec2 Position { get; set; }
    public Vec2 Size { get; set; }
    public Vec2 Center => Position + Size / 2;
    public bool KeepPosition { get; set; }
    
    public Vec2 Velocity { get; set; }

    public virtual AObject? DisplayObject { get; set; }

    public virtual CollisionInfo Collides(PhysicsObject other)
    {
        // Default code for collision detection. Just checks the bounding boxes

        double xIntersection = Math.Min((Position.X + Size.X), (other.Position.X + other.Size.X)) -
                               Math.Max(Position.X, other.Position.X);
        double yIntersection = Math.Min((Position.Y + Size.Y), (other.Position.Y + other.Size.Y)) -
                               Math.Max(Position.Y, other.Position.Y);

        if (xIntersection > 0 && yIntersection > 0)
        {
            int up = (Position.Y < other.Position.Y) ? 1 : -1;
            int left = (Position.X < other.Position.X) ? 1 : -1;
            
            return new CollisionInfo()
            {
                Collides = true,
                CollisionNormal = xIntersection > yIntersection ? Vec2.Up * up : Vec2.Left * left
            };
        }

        return new CollisionInfo()
        {
            Collides = false,
        };
    }

    public virtual void PrepareForRender()
    {
        if (DisplayObject is null)
        {
            return;
        }
        
        DisplayObject.X = Position.X;
        DisplayObject.Y = Position.Y;
    }
}