using CollegeCourses.Business;
using System;
using System.Linq;

namespace CollegeCourses
{
    /// <summary>
    /// Developer Interview Project: College Course Prerequisites
    /// </summary>
    /// <remarks>
    /// To switch between valid/invalid input, change the Debug > Command line arguments in the
    /// console application's properties.
    ///
    /// Valid Args:
    /// "Introduction to Paper Airplanes:" "Advanced Throwing Techniques: Introduction to Paper Airplanes" "History of Cubicle Siege Engines: Rubber Band Catapults 101" "Advanced Office Warfare: History of Cubicle Siege Engines" "Rubber Band Catapults 101:" "Paper Jet Engines: Introduction to Paper Airplanes"
    ///
    /// Invalid Args:
    /// "Intro to Arguing on the Internet: Godwin’s Law" "Understanding Circular Logic: Intro to Arguing on the Internet" "Godwin’s Law: Understanding Circular Logic
    /// </remarks>
    internal class Program
    {
        private static void Main(string[] args)
        {
            int count = 0;
            var mapper = new Mapper();
            var engine = new Engine(mapper);

            Console.WriteLine("Arguments:");
            args.ToList().ForEach(cla => Console.WriteLine(string.Format("Arg #{0}: {1}", count, cla)));

            Console.WriteLine("\n\nPreferred Class Order:\n\n");
            var result = string.Join(", ", engine.DetermineClassOrder(args));
            Console.WriteLine(result);

            Console.WriteLine("\n\n\nHit [ENTER] to continue. . .");
            Console.ReadLine();
        }
    }
}