static void PrintList(List<string> MyList)
{
    foreach (var name in MyList)
    {
        System.Console.WriteLine(name);
    }
}
List<string> TestStringList = new List<string>() {"Harry", "Steve", "Carla", "Jeanne"};
PrintList(TestStringList);


static void SumOfNumbers(List<int> IntList)
{
    int sum = 0;
    foreach (var num in IntList)
    {
        sum+=num;
        
    }
    
    System.Console.WriteLine("Sum of numbers: " + sum);
    // Your code here
}
List<int> TestIntList = new List<int>() {2,7,12,9,3};
// You should get back 33 in this example
SumOfNumbers(TestIntList);


static int FindMax(List<int> IntList)
{
        int max = IntList[0];

        foreach (int number in IntList)
        {
            if (number > max)
            {
                max = number;
            }
        }
        System.Console.WriteLine("Max number is:" + max);

        return max;
    // Your code here
}
List<int> TestIntList2 = new List<int>() {-9,12,10,3,17,5};
// You should get back 17 in this example
FindMax(TestIntList2);


static List<int> SquareValues(List<int> IntList)
{

    // Your code here
    for (int i = 0; i < IntList.Count; i++)
    {
        IntList[i] = IntList[i]*IntList[i];
        
    }

    return IntList;
}
List<int> TestIntList3 = new List<int>() {1,2,3,4,5};
List<int> vler = SquareValues(TestIntList3);
foreach (var item in TestIntList3)
{
    System.Console.WriteLine(item);
}

static int[] NonNegatives(int[] IntArray)
{
    // Your code here
    for (int i = 0; i < IntArray.Length; i++)
    {
        if (IntArray[i] < 0)
        {
            IntArray[i]=0;
        }
    }
    
    return IntArray;
}
int[] TestIntArray = new int[] {-1,2,3,-4,5};
// You should get back [0,2,3,0,5], think about how you will show that this worked
int[] arr =NonNegatives(TestIntArray);
foreach (var item in TestIntArray)
{
    System.Console.WriteLine(item);
}

static void PrintDictionary(Dictionary<string,string> MyDictionary)
{
    foreach (var item in MyDictionary)
    {
        System.Console.WriteLine($"key is :{item.Key} and value is : {item.Value}");
    }
    // Your code here
}
Dictionary<string,string> TestDict = new Dictionary<string,string>();
TestDict.Add("HeroName", "Iron Man");
TestDict.Add("RealName", "Tony Stark");
TestDict.Add("Powers", "Money and intelligence");
PrintDictionary(TestDict);

static void FindKey(Dictionary<string,string> MyDictionary, string SearchTerm)
{
    // Your code here
    foreach (var item in MyDictionary )
    {
        if (item.Value == SearchTerm)
        {
            System.Console.WriteLine($" value : {SearchTerm} eshte tek key {item.Key}");
        }
    }
}
// Use the TestDict from the earlier example or make your own
// This should print true
FindKey(TestDict,"Iron Man");


static Dictionary<string,int> GenerateDictionary(List<string> listaMeFjale, List<int> listaMeInt){
    Dictionary<string,int> DictionaryQeDoKrijohet = new Dictionary<string, int>();

    for (int i = 0; i < listaMeFjale.Count; i++)
    {   
        DictionaryQeDoKrijohet.Add(listaMeFjale[i],listaMeInt[i]);
    }
    return DictionaryQeDoKrijohet;

}

Dictionary<string,int> newDictionary = GenerateDictionary(TestStringList,TestIntList3);

foreach (var item in newDictionary)
{
    System.Console.WriteLine($" {item.Key}  {item.Value}");
}