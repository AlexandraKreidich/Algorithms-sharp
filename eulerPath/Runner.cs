using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Runner
    {
         public static void Menu()
        {
        }

        public static void Main(string []args)
        {
            Algorithm alg = new Algorithm();
            Graph g = new Graph();
            Algorithm.SearchEulerPath(g);
            Graph.ShowEulerPath(g.EulerPath);
            Console.ReadKey();
        }
    }
}
