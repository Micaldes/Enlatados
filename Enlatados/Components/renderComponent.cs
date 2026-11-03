using System;

public class renderComponent : IRenderComponent
{
	public void Render(Vector2 position, Texture2D texture){
        Raylib.DrawTextureV(
            texture,
            position,
            Color.White
        );
    }
}
