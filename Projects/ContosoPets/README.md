# Project overview

This module guides you through the process of developing the data-centric features of the Contoso Pets application. You'll use selection and iteration statements to create sample data, list the animals in your care, and add new animals to your business. Throughout the application, you'll use variables and expressions to control the execution of code branches. You will also ensure that variables are scoped appropriately.

The application you develop will:

- Add predefined sample data to the pets array.
- Iterate a "menu options and user selection" code block to establish the outer loop of your application.
- Implement code branches corresponding to the user's menu selections.
- Display all the information contained in the array used to store pet data (based on user's menu selection).
- Iterate an "add new animal information" code block that enables the user to add one or more new animals to the pets array (based on user's menu selection).

You're working on the Contoso Pets application, an application that helps place pets in new homes. The specifications for your application are:

- Create a C# console application.

- Store application data in a multidimensional string array named ourAnimals.

- The ourAnimals array includes the following "pet characteristics" for each animal:

  - Pet ID #.
  - Pet species (cat or dog).
  - Pet age (years).
  - A description of the pet's physical condition/characteristics.
  - A description of the pet's personality.
  - The pet's nickname.

- Implement a sample dataset that represents dogs and cats currently in your care.

- Display menu options to access the main features of the application.

- The main features enable the following tasks:

  - List the pet information for all animals in the ourAnimals array.

  - Add new animals to the ourAnimals array. The following conditions apply:

    - The pet species (dog or cat) must be entered when a new animal is added to the ourAnimals array.
    - A pet ID must be programmatically generated when a new animal is added to the ourAnimals array.
    - Some physical characteristics for a pet may be unknown until a veterinarian's examination. For example: age, breed, and neutered/spayed status.
    - An animal's nickname and personality may be unknown when a pet first arrives.

  - Ensure animal ages and physical descriptions are complete. This may be required after a veterinarian's examination.

  - Ensure animal nicknames and personality descriptions are complete (this action can occur after the team gets to know a pet).

  - Edit an animal’s age (if a pet's birth date is known and the pet has a birthday while in our care).

  - Edit an animal’s personality description (a pet may behave differently after spending more time in our care).

  - Display all cats that meet user specified physical characteristics.

  - Display all dogs that meet user specified physical characteristics.

## Exercise - Write code to display all ourAnimals array data

### Specifications 1 : Guided project

An initial version of the application has already been completed. The Starter code project for this Guided project module includes a Program.cs file that provides the following code features:

- The code declares variables used to collect and process pet data and menu item selections.

- The code declares the ourAnimals array.

- The code uses a for loop around an if-elseif-else construct to populate the ourAnimals array with a sample dataset.

- The code displays the following main menu options for user selection:

  1. List all of our current pet information.
  2. Assign values to the ourAnimals array fields.
  3. Ensure animal ages and physical descriptions are complete.
  4. Ensure animal nicknames and personality descriptions are complete.
  5. Edit an animal’s age.
  6. Edit an animal’s personality description.
  7. Display all cats with a specified characteristic.
  8. Display all dogs with a specified characteristic.

  Enter menu item selection or type "Exit" to exit the program

- The code reads the user's menu item selection and displays a message echoing their selection.

Your goal is to develop the features that implement the first two menu options. To achieve this goal, you'll complete the following tasks:

1. Update the code that's used to create the sample data for the app.
2. Construct a loop around the main menu and create a selection statement that establishes a code branch for each menu option.
3. Write the code to display all ourAnimals array data (menu option 1).
4. Build a loop for entering new ourAnimals array data (menu option 2 - part 1).
5. Write code to read and save new ourAnimals array data (menu option 2 - part 2).

You'll test your application at each stage of the development process.

### Module Notes

As you can see, setting the _for initializer_ to `int i = 0;` aligns with the zero-based array index. Likewise, setting the _for condition_ to `i < maxPets;` aligns with the first dimension of the array. Finally, setting the _for iterator_ to `i++` will increment your loop control value by `1` for each iteration.

- Take a minute to consider the choice between a `for` statement and a `foreach` statement when iterating through the ourAnimals array.

  The goal is to iterate through each animal in the ourAnimals array one at a time. So why not use a `foreach` loop? After all, you know that the `foreach` statement is designed for cases when you want to iterate through each item in an array of items.

  The reason why you don't use a `foreach` loop in this situation is because the `ourAnimals` array is multidimensional array. Since `ourAnimals` is a multidimensional string array, each element contained within `ourAnimals` is a separate item of type string. If you used a `foreach` loop to iterate through `ourAnimals`, the `foreach` would recognize each string as a separate item in a list of 48 string items (8 x 6 = 48). The `foreach` statement wouldn't process the two array dimensions separately. In other words, a `foreach` loop won't recognize `8` rows of string elements, where each row contains a column of `6` items. Since you want to work with one animal at a time, and process all six animal characteristics during a single iteration, a `foreach` statement isn't the right choice.

  However, if the `ourAnimals` array was a jagged array configured as an array of string arrays, you could use a `foreach` statement. In this case, you would create a `foreach` for an outer loop and second `foreach` for an inner loop. The outer loop would iterate through the "string array" elements in the jagged array. The string arrays are the "rows" in the two-dimensional array. The inner loop would iterate through the "string" elements contained in the string arrays. The string elements in the string arrays are the "columns" in the two-dimensional array.

  The following code sample demonstrates the jagged array approach.

  ```csharp
  string[][] jaggedArray = new string[][]
  {
      new string[] { "one1", "two1", "three1", "four1", "five1", "six1" },
      new string[] { "one2", "two2", "three2", "four2", "five2", "six2" },
      new string[] { "one3", "two3", "three3", "four3", "five3", "six3" },
      new string[] { "one4", "two4", "three4", "four4", "five4", "six4" },
      new string[] { "one5", "two5", "three5", "four5", "five5", "six5" },
      new string[] { "one6", "two6", "three6", "four6", "five6", "six6" },
      new string[] { "one7", "two7", "three7", "four7", "five7", "six7" },
      new string[] { "one8", "two8", "three8", "four8", "five8", "six8" }
  };

  foreach (string[] array in jaggedArray)
  {
      foreach (string value in array)
      {
          Console.WriteLine(value);
      }
      Console.WriteLine();
  }
  ```

To create a Console.WriteLine() method that displays the petID inside the if statement's code block:

> Note: This is a good example for when != should be used. You don't care what value is assigned to petID as long as it's not the default value.

```csharp
for (int i = 0; i < maxPets; i++)
{
    if (ourAnimals[i, 0] != "ID #: ")
    {
        Console.WriteLine(ourAnimals[i, 0]);
    }
}
```

## Exercise - Build and test a loop for entering new pet data

In this exercise, you develop code that controls the input of new ourAnimals array data. You calculate the initial values of your loop control variables and construct the loop that collects user specified data for the animals. The detailed tasks that you complete during this exercise are:

- Calculate petCount: write code that counts the number of pets in the ourAnimals array that have assigned data.
- Conditional messages: write code to display message output when petCount is less than maxPets.
- Outer loop: build a loop structure that will be used for entering new ourAnimals array data.
- Exit criteria: write code that evaluates the exit condition for the "enter new ourAnimals array data" loop.
- Verification test: perform verification tests for the code you develop in this exercise.

### Variable scoping : Resources & Security impact

The scope of your variables should always be as narrow as possible. In the Contoso Pets application, you could scope `petCount` at the application level rather than scoping to the `case "2":` code block. The larger scope would enable you to access `petCount` from anywhere in the application. If `petCount` was scoped at the application level, you could assign it a value when you create the sample data and programmatically manage its value throughout the remainder of the application. For example, when you find a home for a pet and remove the pet from the `ourAnimals` array, you could reduce `petCount` by `1`. The question is, at what level should you scope a variable when you're unsure whether it will be used in other parts of your application? In this case, it's tempting to scope `petCount` at the application level even though you aren't using it anywhere else. After all, scoping `petCount` at the application level ensures that it's available if you do decide to use it elsewhere. Maybe you could scope other variables at the application level as well. That way, your variables are always in scope and accessible. So why not scope variables at the application level when you think they might be used later in the application? Scoping variables at a higher level than necessary can lead to problems. Elevated scope inflates the resource requirements of your application and may expose your application to unnecessary security risks. As your applications grow larger and more complex, they require more resources. Phones and computers allocate memory for these resources when they're in scope. As your applications become more "real-world", they become more accessible. Applications are often accessible from the cloud or other applications. Compounding these issues, applications are often left running when they aren't being used. It's important to keep an application's resource requirements under control and the security footprint as small as possible. Although today's operating systems do a great job of managing resources and securing applications, it's still best practice to keep your variables scoped to the level where they are actually needed. In your Contoso Pets app, if you decide to use `petCount` more broadly within the application, you can update your code to scope `petCount`at a higher level. Remember to keep your variables scoped as narrowly as possible, and only increase their scope when it becomes necessary.

### **Logic to keep in mind to continue testing**

- Take a minute to consider how `petCount` is used in your code.

  You need to understand your code logic before you can validate your code.

  In this case, your code logic relies on the relationship between `petCount` and `maxPets`. You know that `maxPets` is assigned a value of `8`, but what about `petCount`? The following items help to evaluate the logic you've implemented:

  - You know that `petCount` is `4` when you enter the first iteration of the `while` loop.
  - You know that `petCount` is incremented each time the `while` loop iterates.
  - You know that the value assigned to `petCount` and the way that `petCount` is incremented affect how data is stored in the `ourAnimals` array. The following items explain the relationship between `petCount` and the data stored in `ourAnimals`:

    - The application adds four pets to the `ourAnimals` array when it creates the sample data.
    - The application stores new data to the `ourAnimals` array when the value of `petCount` is `4`. This isn't a bug. The code makes sense when you recall that array elements are zero-based. For example, `ourAnimals[0,0]` contains the pet ID for animal `1` and `ourAnimals[3,0]` contains the pet ID for animal `4`. Therefore, when `petCount` is `4` you're storing data for the fifth pet.
    - The application will store pet data to the array before it increments `petCount`.
    - The application increments `petCount` before it prompts the user about adding another pet.
    - When the application displays the **Do you want to enter info for another pet (y/n)** prompt for the first time, `petCount` is already set to `5`.

  - If the user enters **y** at the first **Do you want to enter info for another pet (y/n)** prompt, you know that:

    - The `while (anotherPet == "y" && petCount < maxPets)` loop will iterate. You know the loop will iterate because `anotherPet == "y"` and `petCount < maxPets`.
    - The value assigned to `petCount` will be incremented (when the `while` loop iterates).
    - The value assigned to `petCount` will be `6` (after the user enters **y** the first time).

  Keep this analysis of the code logic in mind as you continue testing the application.

- Notice that the Terminal panel updates with the same "another pet?" message, but your code doesn't display an updated `petCount`.

  The Terminal panel should now show the following output:

  ```bash
  We currently have 4 pets that need homes. We can manage 4 more.
  Do you want to enter info for another pet (y/n)
  y
  Do you want to enter info for another pet (y/n)
  ```

- At the Terminal command prompt, enter **y**

  When you enter `y` a second time, `petCount` is incremented to `7`. So `petCount` is still less than `maxPets`

- At the Terminal command prompt, enter **y**

  When you enter `y` a third time, `petCount` is incremented to `8`. So `petCount` is now equal to `maxPets`

- Verify that your code exits the `while` loop when you enter **y** the third time.

  The Terminal panel should now show the following output:

  ```bash
  We currently have 4 pets that need homes. We can manage 4 more.
  Do you want to enter info for another pet (y/n)
  y
  Do you want to enter info for another pet (y/n)
  y
  Do you want to enter info for another pet (y/n)
  y
  We have reached our limit on the number of pets that we can manage.
  Press the Enter key to continue.
  ```

## Challenge - to create the app features aligned with menu options 3 and 4

### Specifications 2 : Challenge project

Your goal in this challenge is to create the app features aligned with menu options 3 and 4.

>Note
>New animals must be added to the ourAnimals array when they arrive. However, an animal's age and some physical characteristics for a pet may be unknown until after a veterinarian's examination. In addition, an animal's nickname and personality may be unknown when a pet first arrives. The new features that you're developing will ensure that a complete dataset exists for each animal in the ourAnimals array.

To ensure that animal ages and physical descriptions are complete, your code must:

- Assign a valid numeric value to petAge for any animal that has been assigned data in the ourAnimals array but has not been assigned an age.
- Assign a valid string to petPhysicalDescription for any animal that has been assigned data in the ourAnimals array but has not been assigned a physical description.
- Verify that physical descriptions have an assigned value. Assigned values cannot have zero characters. Any further requirement is up to you.

To ensure that animal nicknames and personality descriptions are complete, your code must:

- Assign a valid string to petNickname for any animal that has been assigned data in the ourAnimals array but has not been assigned a nickname.
- Assign a valid string to petPersonalityDescription for any animal that has been assigned data in the ourAnimals array but has not been assigned a personality description.
- Verify that nicknames and personality descriptions have an assigned value. Assigned values cannot have zero characters. Any further requirement is up to you.
