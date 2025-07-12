using Atelier.Interfaces;
using Raylib_cs;

namespace AtelierTestObjects;

public sealed class Mandelbrot : AObject, IDisposable
{
    private Shader _shader;
    private int resLoc;
    private int timeLoc;

    private Image _blankImage;
    private Texture2D _blankTexture;

    public override void Init()
    {
        if (Parent is null)
        {
            throw new InvalidOperationException("Parent should be set before initialising");
        }
        
        _shader = Raylib.LoadShaderFromMemory(File.ReadAllText("baseVert.glsl"),
            File.ReadAllText("mandelbrot.glsl"));
        resLoc = Raylib.GetShaderLocation(_shader, "u_resolution");
        timeLoc = Raylib.GetShaderLocation(_shader, "u_time");
        
        updateTexture();
        Parent.OnResize += _ => updateTexture();
    }
    
    private void updateTexture()
    {
        if (Parent is null)
        {
            return;
        }
        
        Raylib.UnloadTexture(_blankTexture);
        _blankImage = Raylib.GenImageColor((int)Parent.Width, (int)Parent.Height, Color.White);
        _blankTexture = Raylib.LoadTextureFromImage(_blankImage);
        Raylib.UnloadImage(_blankImage);
    }


    public override void Render()
    {
        if (Parent is null)
        {
            return;
        }

        float[] res =
        [
            (float)Parent.Width, (float)Parent.Height
        ];
        
        Raylib.SetShaderValue(_shader, resLoc, res, ShaderUniformDataType.Vec2);
        Raylib.SetShaderValue(_shader, timeLoc, (float)Raylib.GetTime(), ShaderUniformDataType.Float);
        
        Raylib.BeginShaderMode(_shader);
        Raylib.DrawTexture(_blankTexture, 0, 0, Color.White);
        Raylib.EndShaderMode();
    }

    public void Dispose()
    {
        Raylib.UnloadShader(_shader);
    }
}