using System.Numerics;
using Raylib_cs;

namespace WinterProject;

public class HealthBar
{
    public int MaxHealth;
    public int CurrentHealth;

    public HealthBar(int maxHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void Draw(Vector2 position, int width, int height)
    {
        float healthPercentage = (float)CurrentHealth / (float)MaxHealth;
        Rectangle barRect = new Rectangle(position.X, position.Y, width * healthPercentage, height);
        Raylib.DrawRectangleRec(barRect, Color.RED);
        Raylib.DrawRectangleLinesEx(barRect, 2, Color.BLACK);
    }
}


