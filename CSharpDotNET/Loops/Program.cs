// See https://aka.ms/new-console-template for more information
for (int i = 0; i < 257; i++)
{
    System.Console.WriteLine(i);
}

Random rand = new Random();
int sum = 0;
for (int i = 0; i <= 5; i++)
{
    sum += rand.Next(10, 20);
}
System.Console.WriteLine(sum);


for (int i = 1; i <= 100; i++)
{
    if ((i % 3 == 0 || i % 5 == 0) && !(i % 3 == 0 && i % 5 == 0))
        Console.WriteLine(i);
}


for (int i = 0; i < 101; i++)
{
    if (i % 3==0){
        System.Console.WriteLine("fizz");
    }
    if(i % 5 ==0){
        System.Console.WriteLine("buzz");
    }

    
}
for (int i = 0; i < 101; i++)
{
    if (i % 3==0){
        System.Console.WriteLine("fizz");
    }
    if(i % 5 ==0){
        System.Console.WriteLine("buzz");
    }if(i % 3==0 && i % 5 ==0){
        System.Console.WriteLine("fizzbuzz");
    }
    
}
for (int i = 0; i < 101; i++)
{
    if (i % 3==0 && i % 5==0)
    {
        ;
        
    }
    else if (i %3 ==0){
        System.Console.WriteLine(i);

    }else if(i % 5 ==0){
        System.Console.WriteLine(i);
    }
    
}
