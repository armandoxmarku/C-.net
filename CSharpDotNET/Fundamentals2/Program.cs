// See https://aka.ms/new-console-template for more information
        int[] integerArray = new int[10];
        for (int i = 0; i < 10; i++)
        {
            integerArray[i] = i;
        }


        string[] stringArray = { "Tim", "Martin", "Nikki", "Sara" };

        bool[] booleanArray = new bool[10];
        for (int i = 0; i < 10; i++)
        {
            booleanArray[i] = i % 2 == 0; 
        }
        
        Console.WriteLine("Integer Array: " + string.Join(", ", integerArray));
        Console.WriteLine("String Array: " + string.Join(", ", stringArray));
        Console.WriteLine("Boolean Array: " + string.Join(", ", booleanArray));
        
    