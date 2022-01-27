using Converter;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(UnitConverter.Convert("1 kilometers", "millimeters"));
            Console.WriteLine(UnitConverter.Convert("12 inches", "feet"));
            Console.WriteLine(UnitConverter.Convert("5 kilometers", "inches"));
            Console.WriteLine(UnitConverter.Convert("1 meters", "feet"));
            Console.WriteLine(UnitConverter.Convert("3 kiloinches", "meters"));
            Console.WriteLine(UnitConverter.Convert("256 bits", "bytes"));
            Console.WriteLine(UnitConverter.Convert("128 bytes", "bits"));
            Console.WriteLine(UnitConverter.Convert("640 kilobytes", "gigabytes"));
            Console.WriteLine(UnitConverter.Convert("32 fahrenheit", "celsius"));
            Console.WriteLine(UnitConverter.Convert("100 celsius", "fahrenheit"));
            Console.WriteLine(UnitConverter.Convert("-128.6 fahrenheit", "celsius"));
            Console.WriteLine(UnitConverter.Convert("56.7 celsius", "fahrenheit"));
        }
    }
}
