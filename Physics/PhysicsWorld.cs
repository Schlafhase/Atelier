using Atelier.Interfaces;
using Vectors;

namespace Physics;

public class PhysicsWorld : AObject
{
    private bool _mouseDown;
    public List<PhysicsObject> PhysicsObjects { get; set; } = [];

    public override void Tick(double dt = 16.6)
    {
        foreach (PhysicsObject obj in PhysicsObjects.Where(obj => !obj.KeepPosition))
        {
            obj.Velocity += Vec2.Down * 9.81 * dt;
            obj.Velocity = new Vec2(obj.Velocity.X, Math.Max(obj.Velocity.Y, 48));

            foreach (PhysicsObject other in PhysicsObjects)
            {
                if (obj == other)
                {
                    continue;
                }

                if (obj.Collides(other) is { Collides: true, CollisionNormal: not null } collisionInfo)
                {
                    obj.Velocity = new Vec2(obj.Velocity.X, obj.Velocity.Y * 0);
                    while (obj.Collides(other).Collides)
                    {
                        obj.Velocity += (Vec2)collisionInfo.CollisionNormal * 0.01;
                        obj.Position += obj.Velocity;

                        if (!other.KeepPosition)
                        {
                            other.Velocity = new Vec2(other.Velocity.X, other.Velocity.Y + obj.Velocity.X * 0.2);
                            other.Velocity += (Vec2)collisionInfo.CollisionNormal * -0.01;
                        }

                        obj.Velocity = new Vec2(obj.Velocity.X * 0.8, obj.Velocity.Y);
                    }
                }
            }

            obj.Position += obj.Velocity * 0.0003 * dt;
        }
    }

    public override void Render()
    {
        foreach (PhysicsObject obj in PhysicsObjects)
        {
            if (obj.DisplayObject is { } aObject)
            {
                obj.PrepareForRender();
                aObject.Render();
            }
        }
    }
}