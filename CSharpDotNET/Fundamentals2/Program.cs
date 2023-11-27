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
System.Console.WriteLine("String Array: " + string.Join(", ", stringArray));
System.Console.WriteLine("Boolean Array: " + string.Join(", ", booleanArray));
System.Console.WriteLine("Integer Array: " + string.Join(", ", integerArray));


List<string> iceCreamFlavors = new List<string>
    {
        "Chocolate", "Vanilla", "Strawberry", "Mint Chocolate Chip", "Cookie Dough", "Rocky Road"
    };


System.Console.WriteLine("Initial Length of the List: " + iceCreamFlavors.Count);


System.Console.WriteLine("Third Flavor in the List: " + iceCreamFlavors[2]);

iceCreamFlavors.RemoveAt(2);

System.Console.WriteLine("Length of the List after removal: " + iceCreamFlavors.Count);



string[] names2 = { "Alice", "Bob", "Charlie", "David", "Eva" };
List<string> iceCreamFlavors2 = new List<string> { "Chocolate", "Vanilla", "Strawberry", "Mint Chocolate Chip", "Cookie Dough", "Rocky Road" };


Dictionary<string, string> userDictionary = new Dictionary<string, string>();


Random random = new Random();
foreach (string name in names2)
{
    int randomIndex = random.Next(iceCreamFlavors2.Count);
    string randomFlavor = iceCreamFlavors2[randomIndex];
    userDictionary.Add(name, randomFlavor);
}


foreach (var keyValue in userDictionary)
{
    System.Console.WriteLine($"{keyValue.Key}'s favorite ice cream flavor is {keyValue.Value}.");
}