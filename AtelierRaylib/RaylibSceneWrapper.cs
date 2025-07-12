using Atelier.Interfaces;
using Raylib_cs;

namespace AtelierRaylib;

public static class RaylibSceneWrapper
{
    /// <summary>
    /// Opens a Raylib window rendering the scene
    /// </summary>
    /// <param name="scene">The scene to be rendered</param>
    /// <param name="mspf">Milliseconds per frame</param>
    /// <param name="title">Title of the window</param>
    public static void OpenWindow(Scene scene, double mspf, string title = "Raylib")
    {
        Raylib.SetConfigFlags(ConfigFlags.TransparentWindow);
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);
        Raylib.InitWindow(800, 600, "AtelierRaylib");
        scene.Init();

        double lastFrame = Raylib.GetTime();
        Color transparent = new Color(0, 0, 0, 0);

        double actualMspf = 0;

        while (!Raylib.WindowShouldClose())
        {
            double now = Raylib.GetTime();
            double dt = (now - lastFrame) * 1000; // delta time in milliseconds
            if (dt < mspf) continue;
            
            Raylib.BeginDrawing();
            Raylib.ClearBackground(transparent);
            
            scene.Resize(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
            scene.Render();
            
            Raylib.DrawText(actualMspf.ToString("F2"), 20, 20, 20, Color.White);
            Raylib.EndDrawing();
            
            scene.Tick(dt);
            
            now = Raylib.GetTime();
            actualMspf = (now - lastFrame) * 1000;
            lastFrame = now;
        }
        
        scene.Dispose();
        Raylib.CloseWindow();
    }
}
