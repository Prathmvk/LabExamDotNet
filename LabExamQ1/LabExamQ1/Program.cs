namespace LabExamQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Data Source (List of integers)
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Query Creation
            var query = from num in numbers
                        where num % 2 == 0
                        select num;

            // Query Execution
            List<int> evenNumbers = query.ToList();

            // Display the results
            Console.WriteLine("Original list: " + string.Join(", ", numbers));
            Console.WriteLine("Even numbers: " + string.Join(", ", evenNumbers));
        }
    }
}