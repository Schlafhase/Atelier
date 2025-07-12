using Atelier.Interfaces;
using Raylib_cs;

namespace AtelierTestObjects;

public sealed class Mandelbrot : AObject, IDisposable
{
    private Shader _shader;
    private int resLoc;

    public void Init()
    {
        _shader = Raylib.LoadShaderFromMemory(File.ReadAllText("baseVert.glsl"),
            File.ReadAllText("mandelbrot.glsl"));
        resLoc = Raylib.GetShaderLocation(_shader, "u_resolution");
    }


    public override void Render()
    {
        if (Parent is null)
        {
            return;
        }
        
        Raylib.SetShaderValue(_shader, resLoc, [(float)Parent.Width, (float)Parent.Height], ShaderUniformDataType.Vec2);
        
        Raylib.BeginShaderMode(_shader);
        Raylib.DrawTexture(Parent.BlankTexture, 0, 0, Color.White);
        Raylib.EndShaderMode();
    }

    public void Dispose()
    {
        Raylib.UnloadShader(_shader);
    }
}