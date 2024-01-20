namespace Week_01_lab_02_Cars_W
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car(2022, "Toyota Camry", 25000);
            Car car2 = new Car(2021, "Honda Accord", 23000, false);
            Car car3 = new Car(2023, "Ford Mustang", 45000);
            Car car4 = new Car(2020, "Chevrolet Malibu", 20000, true);

            Console.WriteLine("Car 1: " + car1);
            Console.WriteLine("Car 2: " + car2);
            Console.WriteLine("Car 3: " + car3);
            Console.WriteLine("Car 4: " + car4);
        }
    }


    public class Car
    {
        private readonly int year;
        private readonly string _model;
        private readonly double _price;
        private readonly bool _isDrivable;

        public Car(int year, string model, double price, bool isDrivable = true)
        {
            this.year = year;
            _model = model;
            _price = price;
            _isDrivable = isDrivable;
        }

        public override string ToString()
        {
            return $"Year: {year}, Model: {_model}, Is Drivable: {_isDrivable}, Price: {_price}";
        }
    }
}
