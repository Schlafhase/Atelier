using System.Numerics;
using Raylib_cs;
using Vectors;

namespace Atelier.Interfaces;

public abstract class TwoDCameraScene : Scene
{
    private Camera2D _camera = new()
    {
        Zoom = 1
    };

    private bool _panning;
    private Vec2 _panStart;
    private Vec2 _panStartCamera;

    public bool EnableDefaultCameraControls = true;

    public Camera2D Camera
    {
        get => _camera;
        private set => _camera = value;
    }

    public Vec2 ToWorldSpace(Vec2 pointInScreenSpace)
    {
        return (pointInScreenSpace - (Vec2)_camera.Offset) / _camera.Zoom;
    }

    public Vec2 ToScreenSpace(Vec2 pointInScreenSpace)
    {
        return pointInScreenSpace * _camera.Zoom + (Vec2)_camera.Offset;
    }

    public override void Tick(double dt = 16.6)
    {
        base.Tick(dt);

        if (!EnableDefaultCameraControls)
        {
            return;
        }

        // Panning
        if (Raylib.IsMouseButtonDown(MouseButton.Middle))
        {
            if (_panning)
            {
                _camera.Offset = _panStartCamera + (Vec2)Raylib.GetMousePosition() - _panStart;
                return;
            }

            _panStart = Raylib.GetMousePosition();
            _panStartCamera = _camera.Offset;
            _panning = true;
        }
        else
        {
            _panning = false;
        }

        float deltaY = Raylib.GetMouseWheelMoveV().Y * -1;

        if (Math.Abs(deltaY) > 0.5)
        {
            Vec2 mousePos = Raylib.GetMousePosition();
            Vec2 worldPos = (mousePos - (Vec2)_camera.Offset) / _camera.Zoom;

            _camera.Zoom -= deltaY / 10 * _camera.Zoom;

            Vec2 newScreenPos = worldPos * _camera.Zoom + (Vec2)_camera.Offset;

            _camera.Offset += (Vector2)mousePos - (Vector2)newScreenPos;
        }
    }

    public override void Render()
    {
        Raylib.BeginMode2D(Camera);

        foreach (AObject obj in Objects)
        {
            if (obj is INoCameraObject)
            {
                Raylib.EndMode2D();
                obj.Render();
                Raylib.BeginMode2D(Camera);
                continue;
            }

            obj.Render();
        }

        Raylib.EndMode2D();
    }
}