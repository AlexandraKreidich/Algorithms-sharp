﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    internal class Runner
    {
        public static void Main()
        {
            var graph = new Graph(4);
            var weights = new Dictionary<Edge, double>
            {
                [graph.Connect(0, 1)] = 1,
                [graph.Connect(0, 2)] = 2,
                [graph.Connect(0, 3)] = 6,
                [graph.Connect(1, 3)] = 4,
                [graph.Connect(2, 3)] = 2
            };

            var dijkstraAlg = new DijkstraAlg(graph, weights);

            var path = dijkstraAlg.Dijkstra(graph[0], graph[3]).Select(n => n.NodeNumber);

            foreach (var v in path)
                Console.WriteLine(v);

            Console.ReadKey();
        }
    }
}
