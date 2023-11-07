using System.Security.Principal;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> list = new List<string> { "chair ", "window ", "floor", "lock", "stone" };
        IEnumerable<string> query = list.Where(word => word.Length > 4);
        Console.WriteLine(query.GetType());
        var query2 = list.Where(word => word.StartsWith("w"));
        list.ForEach(word => Console.WriteLine(word));
        Console.WriteLine(query2.GetType());

        string[] words = { "keys", "coat", "laptop", "bottle" };
        var question = words
            .Where(word => word.Length > 4)
            .OrderBy(word => word)
            .Select(word => word.ToUpper());

        var question2 = from word in words
                        where word.Length > 4
                        orderby word
                        select word.ToUpper();
        Console.WriteLine(question.ToList()[1].Equals(question2.ToList()[1]));
        Console.WriteLine("End");

        // *******************************************************************************************
        List<int> intList = new List<int>();
        intList.AddRange(new int[] { 20, 1, 4, 8, 9, 44, 5 });
        //Lambda-expression
        List<int> evenInts = intList.FindAll(number => number % 2 == 0);
        evenInts.ForEach(number => Console.WriteLine($"Even number: {number}"));
        Console.WriteLine("Stopper");

        QueryOverStrings();



        Console.WriteLine("Stopper");
        QueryOverStringWithQuerySyntax();
        Console.WriteLine("Stopper");
        QueryOverStringWithoutLinq();
        List<Car> cars = new List<Car>()
{
    new Car{ Make = "Skoda", Color = "Röd", MaxSpeed = 230},
    new Car{ Make = "BMW", Color = "Silver", MaxSpeed = 250},
    new Car{ Make = "Volvo", Color ="Smurfblå", MaxSpeed = 180},
    new Car{ Make = "Ferrari", Color = "Röd", MaxSpeed = 300}
};
        CarQuery(cars);

        Car car = new Car { MaxSpeed = 11 };
        int value = car.CompareTo(new Car { Color = "Black", MaxSpeed = 5 });
        Console.WriteLine("Stopper");
        void CarQuery(List<Car> cars)
        {
            var colors = cars.OrderByDescending(car => car.MaxSpeed).Select(car => car.Color).ToList();
            colors.ForEach(car => Console.WriteLine(car));
            // List<string> carColors = SortedCars(cars);
        }

        List<string> SortedCars(List<Car> cars)
        {
            List<string> colors = new List<string>();
            cars.Sort();
            foreach (Car car in cars)
            {
                colors.Add(car.Color);
            }
            return colors;
        }

        void QueryOverStrings()
        {
            string[] oldVideoGames = { "Morrowind", "Fallout 3", "Crusader Kings II", "Duke Nukem", "Halflife" };
            // Build a query that finds elements with embedded space " "
            var containsSpace = oldVideoGames.Where(game => game.Contains(" ")).OrderByDescending(game => game);
            foreach (var game in containsSpace)
            {
                Console.WriteLine(game);
            }
        }
        void QueryOverStringWithQuerySyntax()
        {
            string[] oldVideoGames = { "Morrowind", "Fallout 3", "Crusader Kings II", "Duke Nukem", "Halflife" };
            var games = from game in oldVideoGames
                        where game.Contains(" ")
                        orderby game descending
                        select game;
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
        }

        void QueryOverStringWithoutLinq()
        {
            string[] oldVideoGames = { "Morrowind", "Fallout 3", "Crusader Kings II", "Duke Nukem", "Halflife" };
            List<string> games = new List<string>();
            foreach (var game in oldVideoGames)
            {
                if (game.Contains(" "))
                {
                    games.Add(game);
                }
            }
            games.Sort();

            games.ForEach(game => Console.WriteLine(game));
        }
    }
}

public class Car : IComparable<Car>
{
    public string Make { get; set; }
    public string Color { get; set; }
    public int MaxSpeed { get; set; }

    public int CompareTo(Car? other)
    {
        if (this.MaxSpeed > other.MaxSpeed)
        { return -1; }
        if (this.MaxSpeed < other.MaxSpeed)
        { return 1; }
        else return 0;
    }
}
