using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1600, 800, "Winter Fight");
Raylib.SetTargetFPS(60);

// Ladda in bakgrundsbilder
Texture2D startbackround = Raylib.LoadTexture("assets/backroundmenu2.png");
Texture2D gamebackround = Raylib.LoadTexture("assets/gamebackround2.png");
Texture2D Startbutton = Raylib.LoadTexture("assets/Startgamebutton-removebg-preview.png");

// bestämma gubbens storlek etc
int size = 80;
int currentFrame = 0;
int direction = 1;
float rightside = 2.75f;
double animationTimer = 0;
int currentAnimation = 0;

// Gubbens storlek , Gubbens bilder för animation etc
Rectangle playerRect = new Rectangle(0, 0, size, size);
Texture2D spriteSheet = Raylib.LoadTexture("assets/NightBorne.png");
Rectangle dest = new Rectangle(0, 0, 80, 80);
Rectangle src = new Rectangle(0, 80, size, size);

Texture2D enemysheet = Raylib.LoadTexture("assets/Skeleton/Sprite Sheets/Skeleton Walk.png");
Rectangle enemydest = new Rectangle(0, 0, 21, 35);



double framesPerSecond = 12;

Vector2 movement = new Vector2(0, 0);

Vector2 position = new Vector2(600, 450);

Rectangle startGameButton = new Rectangle(750, 300, 100, 100);

string scene = "start";


while (!Raylib.WindowShouldClose())
{
    if (scene == "start")
    {
        // Om man klickar på startknappen, gå till scen "game"
        if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), startGameButton)
            && Raylib.IsMouseButtonPressed(MouseButton.MOUSE_LEFT_BUTTON))
        {
            scene = "game";
        }

    }
    if (scene == "game")
    {
        // Så att man kan gå höger och vänster och så att gubben vänder på sig när man går motsatta hållet
        movement = Vector2.Zero;
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
        {
            movement.X = 10;
            direction = 1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
        {
            movement.X = -10;
            direction = -1;
        }

        position += movement;

        // Animation
        if (currentAnimation != 2)
        {
            currentAnimation = 0;
        }
        if (movement != Vector2.Zero)
        {
            currentAnimation = 1;
        }
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
        {
            currentAnimation = 2;
            animationTimer = 0.0f;
        }


        animationTimer += Raylib.GetFrameTime();
        if (animationTimer > (1.0f / (double)framesPerSecond))
        {
            int maxFrames = 1;
            switch (currentAnimation)
            {
                // Maxframes betyder hur många bilder den ska lägga in, varje case är för en animation var.
                case 0:
                    maxFrames = 8;
                    break;
                case 1:
                    maxFrames = 5;
                    break;
                case 2:
                    maxFrames = 11;
                    break;
                case 3:
                    maxFrames = 4;
                    break;
                case 4:
                    maxFrames = 22;
                    break;
            }
            if (currentFrame < maxFrames)
            {
                currentFrame++;
            }
            else
            {
                currentFrame = 0;
                if (currentAnimation == 2)
                {
                    currentAnimation = 0;
                }
            }
            animationTimer = 0.0f;
        }
        src = new Rectangle(currentFrame * size, currentAnimation * size, size * direction, size);
        // Så att man inte kan gå ut från mapen
        if (position.X < -100)
        {
            position.X = -100;
        }
        if (position.X > Raylib.GetScreenWidth() - playerRect.width * rightside)
        {
            position.X = Raylib.GetScreenWidth() - playerRect.width * rightside;
        }
    }

    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.WHITE);

    if (scene == "start")
    {
        // Bilder i "start"
        Raylib.DrawTexture(startbackround, 0, 0, Color.WHITE);
        Raylib.DrawTexture(Startbutton, 750, 300, Color.WHITE);

    }
    if (scene == "game")
    {
        // Bilder i scenen "game"
        Raylib.DrawTexture(gamebackround, 0, 0, Color.WHITE);
        dest = new Rectangle(position.X, position.Y, size * 4, size * 4);
        Raylib.DrawTexturePro(spriteSheet, src, dest, Vector2.Zero, 0.0f, Color.WHITE);
    }

    Raylib.EndDrawing();

}
Raylib.CloseWindow();