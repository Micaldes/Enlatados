using Enlatados.Components;
using Raylib_cs;
using System;

public interface IRenderComponent
{
    public Texture2D texture { get; set; }
    public void Render();
}
