using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- shapes-test ---");

            //read from csv files 

            using (var reader = new StreamReader(@"C:\shapes.csv"))
            {

                List<Triangle> tShapes = new List<Triangle>();
                List<Circle> cShapes = new List<Circle>();

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');

                    if (values[0] == "T")
                    {
                        Triangle shape = new Triangle();
                        shape.Cordinates = values.ToList();
                        tShapes.Add(shape);
                    }
                    else
                    {
                        Circle shape = new Circle();
                        shape.Cordinates = values.ToList();
                        cShapes.Add(shape);
                    }
                }

                Console.WriteLine("total number of shapes: {0}", tShapes.Count + cShapes.Count);
                Console.WriteLine("total number of Triangles: " + tShapes.Count);
                Console.WriteLine("total number of Circles: " + cShapes.Count);

                Console.WriteLine("Calculate the largest triangle area:");
                var item = tShapes.Max(x => x.GetArea());
                //var item1 = tShapes.Min(x => x.GetArea());
                Console.WriteLine(item);
                //Console.WriteLine(item1);

                Console.WriteLine("Calculate the largest circle area:");
                //var itemC = cShapes.Max(x => x.GetArea());
                //Console.WriteLine(itemC);

            }


            Console.Read();
        }


    }
    public interface IShapes
    {
        double GetArea();
        List<string> Cordinates { get; set; }
    }
    public class Triangle : IShapes
    {
        public List<string> Cordinates { get; set; }

        public double GetArea()
        {
            double a = Math.Abs(double.Parse(Cordinates[3], CultureInfo.InvariantCulture) - double.Parse(Cordinates[5], CultureInfo.InvariantCulture));
            double h = Math.Abs(double.Parse(Cordinates[4], CultureInfo.InvariantCulture) - double.Parse(Cordinates[2], CultureInfo.InvariantCulture));

            double s = (double)a * h / 2;

            return s;
        }
    }
    public class Circle : IShapes
    {
        public List<string> Cordinates { get; set; }

        public double GetArea()
        {
            throw new NotImplementedException();
        }
    }
}
