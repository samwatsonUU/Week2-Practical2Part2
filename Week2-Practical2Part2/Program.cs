﻿
using System.ComponentModel.Design;

Main();
static void Main()
{
    bool exitPressed = false;
    int selection;

    while (!exitPressed)
    {

        selection = Menu();

        switch (selection)
        {
            case 1:
                Console.WriteLine("\nPlease enter a string:");
                string plainString = Console.ReadLine();
                Encrypt(plainString);
                break;

            case 2:
                Console.WriteLine("\nPlease enter a string:");
                string encryptedString = Console.ReadLine();
                Decrypt(encryptedString);
                break;

            case 3:
                Console.WriteLine("\nExiting... Goodbye");
                exitPressed = true;
                break;

        }

    }

    Environment.Exit(0);

}

static string Encrypt(string plainString)
{

    int rotations = 0;
    char[] chars = plainString.ToCharArray();
    string encryptedString = "";

    Console.WriteLine("\nHow many rotations would you like to make:");

    while (rotations <= 0)
    {

        rotations = Convert.ToInt32(Console.ReadLine());

        if (rotations <= 0)
        {

            Console.WriteLine("\nPlease enter a positve value.");

        }

    }

    rotations %= 26;

    for (int i = 0; i < chars.Length; i++)
    {

        if (chars[i] >= 'A' && chars[i] <= 'Z')
        {

            if (chars[i] + (rotations) > 'Z')
            {

                chars[i] = (char)(chars[i] + (rotations) - 26);


            }
            else
            {

                chars[i] = (char)(chars[i] + rotations); 

            }


        }
        else if (chars[i] >= 'a' && chars[i] <= 'z')
        {


            if (chars[i] + (rotations) > 'z')
            {

                chars[i] = (char)(chars[i] + (rotations) - 26);

            }
            else
            {

                chars[i] = (char)(chars[i] + rotations); 

            }


        }

        

    }

    encryptedString = new string(chars);

    Console.WriteLine($"\nOriginal string: {plainString}");
    Console.WriteLine($"Encrypted string: {encryptedString}");

    return encryptedString;

}

static string Decrypt(string encryptedString)
{

    int rotations = 0;
    char[] chars = encryptedString.ToCharArray();
    string originalString;

    Console.WriteLine("\nHow many rotations have been performed on this string:");

    while (rotations <= 0)
    {

        rotations = Convert.ToInt32(Console.ReadLine());

        if (rotations <= 0)
        {

            Console.WriteLine("\nPlease enter a positve value.");

        }

    }

    rotations %= 26;

    for (int i = 0; i < chars.Length; i++)
    {

        if (chars[i] >= 'A' && chars[i] <= 'Z')
        {

            if (chars[i] - (rotations) < 'A')
            {

                Console.WriteLine(rotations);
                chars[i] = (char)(chars[i] - (rotations) + 26);


            }
            else
            {

                chars[i] = (char)(chars[i] - rotations);

            }


        } else if (chars[i] >= 'a' && chars[i] <= 'z')
        {

            if (chars[i] - (rotations) < 'a')
            {

                chars[i] = (char)(chars[i] - (rotations) + 26);


            }
            else
            {

                chars[i] = (char)(chars[i] - rotations);

            }

        }

    }

    originalString = new string(chars);

    Console.WriteLine($"\nEncrypted string: {encryptedString}");
    Console.WriteLine($"Decrypted string: {originalString}");

    return originalString;

}

static int Menu()
{

    Console.WriteLine("\nPlease select one of the following options:");
    Console.WriteLine("1 - Encrypt");
    Console.WriteLine("2 - Decrypt");
    Console.WriteLine("3 - Exit");

    bool validInput = false;
    int selection = -1;

    while (!validInput)
    {

        try
        {

            selection = Convert.ToInt32(Console.ReadLine());

            if (selection > 0 && selection < 4)
            {

                validInput = true;
                

            } else
            {

                Console.WriteLine("\nPlease enter 1, 2 or 3");

            }

        }
        catch (FormatException e)
        {

            Console.WriteLine("\nError - please enter 1, 2 or 3");

        }

        
    }

    return selection;


}


