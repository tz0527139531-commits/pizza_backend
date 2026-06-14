
internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Console.WriteLine("Bagin");

        var task1 = Task.Run(() => PrintOne());
        var task2 = Task.Run(() => PrintTow());

        await Task.WhenAll(task1, task2);
        Console.WriteLine("the taskes finish!");


        int[]arr = { 1, 2, 3 };

        var task1_1=Task.Run(() => PrintSum(arr));
        var task2_2 = Task.Run(() => PrintMax(arr));

        await Task.WhenAll(task1_1, task2_2);


    }

        public static void PrintOne()
        {
        Console.WriteLine("Task 1 begain");
         
        for(int i = 1; i < 6; i++) 
        {
            Console.WriteLine(i);
        }

        }

        public static void PrintTow()
        {
        Console.WriteLine("Task 2 begain");
        for (int i = 1; i < 6; i++)
        {
            Console.WriteLine(i);
        }
    }

         public static void PrintSum(int[] arr) 
         {
        Console.WriteLine("sum");
        int sum = 0;
           for (int i = 0; i < arr.Length; i++)
            {
               sum+= arr[i];
            }
           Console.WriteLine(sum);
    }

        public static void PrintMax(int[] arr)
        {
        Console.WriteLine("max");
        int big = 0;
            for (int i = 0; i < arr.Length; i++)
            {
            if (arr[i] > big)
                big = arr[i];
            }
        Console.WriteLine(big);
    }

}