Console.CursorVisible = false;
int height = Console.WindowHeight - 1;
int width = Console.WindowWidth - 5;
bool shouldExit = false;

// Tracks which food characters have been overwritten by the player
bool[] foodCovered = Array.Empty<bool>();

// Console position of the player
int playerX = 0;
int playerY = 0;

// Console position of the food
int foodX = 0;
int foodY = 0;

// Available player and food strings
string[] states = { "('-')", "(^-^)", "(X_X)" };
string[] foods = { "@@@@@", "$$$$$", "#####" };

// Current player string displayed in the Console
string player = states[0];

// Index of the current food
int food = 0;

InitializeGame();
while (!shouldExit)
{
    if (TerminalResized())
    {
        Console.Clear();
        shouldExit = true;
        Console.WriteLine("Console was resized. Program exiting.");
        continue;
    }

    if (Console.KeyAvailable)
    {
        ConsoleKey keyPressed = Console.ReadKey(true).Key;

        if (ShouldFreezePlayer())
        {
            FreezePlayer();
        }
        else
        {
            int movementSpeed = ShouldIncreaseSpeed() ? 3 : 1;
            Move(keyPressed, movementSpeed);
        }
    }

    if (FoodConsumed())
    {
        ChangePlayer();
        ShowFood();
    }
}

// Returns true if the player is frozen
bool ShouldFreezePlayer()
{
    return player == states[2];
}

// Returns true if the player should move faster
bool ShouldIncreaseSpeed()
{
    return player == states[1];
}

// Returns true if the Terminal was resized 
bool TerminalResized()
{
    return height != Console.WindowHeight - 1 || width != Console.WindowWidth - 5;
}

// Displays random food at a random location
void ShowFood()
{
    // Update food to a random index
    food = Random.Shared.Next(0, foods.Length);

    // Update food position to a random location
    foodX = Random.Shared.Next(0, width - player.Length);
    foodY = Random.Shared.Next(0, height - 1);

    foodCovered = new bool[foods[food].Length];

    // Display the food at the location
    Console.SetCursorPosition(foodX, foodY);
    Console.Write(foods[food]);
}

// Changes the player to match the food consumed
void ChangePlayer()
{
    player = states[food];
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Temporarily stops the player from moving
void FreezePlayer()
{
    System.Threading.Thread.Sleep(1000);
    player = states[0];
}

// Reads directional input from the Console and moves the player
void Move(ConsoleKey keyPressed, int movementSpeed = 1)
{
    int lastX = playerX;
    int lastY = playerY;

    switch (keyPressed)
    {
        case ConsoleKey.UpArrow:
            playerY--;
            break;
        case ConsoleKey.DownArrow:
            playerY++;
            break;
        case ConsoleKey.LeftArrow:
            playerX -= movementSpeed;
            break;
        case ConsoleKey.RightArrow:
            playerX += movementSpeed;
            break;
        default:
            return; // ignore non-directional keys
    }

    Console.SetCursorPosition(lastX, lastY);
    for (int i = 0; i < player.Length; i++)
    {
        Console.Write(" ");
    }

    // Keep player position within the bounds of the Terminal window
    playerX = (playerX < 0) ? 0 : (playerX >= width ? width : playerX);
    playerY = (playerY < 0) ? 0 : (playerY >= height ? height : playerY);

    // Draw the player at the new location
    Console.SetCursorPosition(playerX, playerY);
    Console.Write(player);
}

// Clears the console, displays the food and player
void InitializeGame()
{
    Console.Clear();
    ShowFood();
    Console.SetCursorPosition(0, 0);
    Console.Write(player);
}

// if food consumed completely, redisplay food
// use position variables of food, player
// return useful value
// 
bool FoodConsumed()
{
    if (playerY == foodY)
    {
        int playerLeft = playerX;
        int playerRight = playerX + player.Length - 1;
        int foodLeft = foodX;
        int foodRight = foodX + foods[food].Length - 1;

        int overlapStart = Math.Max(playerLeft, foodLeft);
        int overlapEnd = Math.Min(playerRight, foodRight);

        if (overlapStart <= overlapEnd)
        {
            for (int x = overlapStart; x <= overlapEnd; x++)
            {
                foodCovered[x - foodLeft] = true;
            }
        }
    }

    for (int i = 0; i < foodCovered.Length; i++)
    {
        if (!foodCovered[i])
        {
            return false;
        }
    }

    return true;
}