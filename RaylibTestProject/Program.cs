// See https://aka.ms/new-console-template for more information

using Atelier.Interfaces;
using AtelierTestObjects;

internal class Program
{
    public static void Main(string[] args)
    {
        TestScene scene = new();

        RaylibSceneWrapper.OpenWindow(scene, 16.6);
    }
}