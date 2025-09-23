# Challenge project - Create a mini-game (methods in CSharp)
You want to move a character across the screen and make it consume an object. The object consume can affect the state of the player. To keep the game going, you wanted to regenerate the object in a new location once it has been consumed. You decide that you'll need to use methods to keep your game code organized. 
 
In this module, you'll develop the following features of a mini-game application: 
 
-   A feature to determine if the player consumed the food 
-   A feature that updates player status depending on the food consumed 
-   A feature that pauses movement speed depending on the food consumed 
-   A feature to regenerate food in a new location 
-   An option to terminate the game if an unsupported character is pressed 
-   A feature to terminate the game if the Terminal window was resized

## Project specification

The Starter code project for this module includes a Program.cs file with the following code features:


```
- The code declares the following variables:
    - Variables to determine the size of the Terminal window.
    - Variables to track the locations of the player and food.
    - Arrays `states` and `foods` to provide available player and food appearances
    - Variables to track the current player and food appearance

- The code provides the following methods:
    - A method to determine if the Terminal window was resized.
    - A method to display a random food appearance at a random location.
    - A method that changes the player appearance to match the food consumed.
    - A method that temporarily freezes the player movement.
    - A method that moves the player according to directional input.
    - A method that sets up the initial game state.

- The code doesn't call the methods correctly to make the game playable. The following features are missing:
    - Code to determine if the player has consumed the food displayed.
    - Code to determine if the food consumed should freeze player movement.
    - Code to determine if the food consumed should increase player movement.
    - Code to increase movement speed.
    - Code to redisplay the food after it's consumed by the player.
    - Code to terminate execution if an unsupported key is entered.
    - Code to terminate execution if the terminal was resized.
```

Your goal in this challenge is to use the existing features and create the missing features to make the game playable.