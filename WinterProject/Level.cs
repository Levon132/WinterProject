using System.Numerics;
using Raylib_cs;

// namespace WinterProject;

public class Level
{
    public List<Skeleton> Enemies;
    public int LevelNumber;

    Texture2D skeletonSpriteSheet = Raylib.LoadTexture("assets\\Skeleton idle.png");

    public Level(int levelNumber)
    {
        LevelNumber = levelNumber;
        Enemies = new List<Skeleton>();
    }

    public void SpawnEnemies()
    {
        // spawnar "enemies" här
        Enemies.Add(new Skeleton(skeletonSpriteSheet, Vector2.Zero, 100));
    }

    public void Draw()
    {
        Enemies[0].Draw();
    }


    public void IsLevelComplete()
    {
        // kollar om "enemy" är döda
    }
}


