using Raylib_cs;

namespace Atelier.Interfaces;

public static class RaylibSceneWrapper
{
    /// <summary>
    ///     Opens a Raylib window rendering the scene
    /// </summary>
    /// <param name="scene">The scene to be rendered</param>
    /// <param name="mspf">Milliseconds per frame</param>
    /// <param name="title">Title of the window</param>
    public static void OpenWindow(Scene scene, double mspf, string title = "Raylib")
    {
        Raylib.SetConfigFlags(ConfigFlags.TransparentWindow);
        Raylib.SetConfigFlags(ConfigFlags.ResizableWindow);
        Raylib.SetConfigFlags(ConfigFlags.MaximizedWindow);
        Raylib.InitWindow(800, 400, "AtelierRaylib");
        Raylib.SetExitKey(KeyboardKey.Null);
        scene.Init();

        Color transparent = new(0, 0, 0, 0);

        double actualMspf = 0;

        while (!Raylib.WindowShouldClose())
        {
            double frameStart = Raylib.GetTime();

            scene.Tick(actualMspf);

            Raylib.BeginDrawing();
            Raylib.ClearBackground(transparent);

            scene.Resize(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
            scene.Render();

            Raylib.DrawText(actualMspf.ToString("F2"), 20, 20, 20, Color.White);
            Raylib.EndDrawing();

            double frameEnd = Raylib.GetTime();
            double frameDuration = frameEnd - frameStart;


            if ((frameDuration * 1000) < mspf)
            {
                actualMspf = mspf;
                Thread.Sleep((int)(mspf - (frameDuration * 1000)));
                continue;
            }

            actualMspf = frameDuration * 1000;
        }

        scene.Dispose();
        Raylib.CloseWindow();
    }
}