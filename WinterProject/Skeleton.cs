using System.Numerics;
using Raylib_cs;

// namespace WinterProject;
public class Skeleton
{
    public Vector2 Position;
    public Texture2D Texture;
    public Rectangle CollisionRectangle;
    public int Health;

    public Skeleton(Texture2D texture, Vector2 position, int health)
    {
        Texture = texture;
        Position = position;
        Health = health;
        CollisionRectangle = new Rectangle((int)position.X, (int)position.Y, texture.width, texture.height);
    }

    public void Update()
    {
        // Enemy movement  attack logic
    }

    public void Draw()
    {
        Raylib.DrawTexture(Texture, (int)Position.X, (int)Position.Y, Color.WHITE);

    }
}


