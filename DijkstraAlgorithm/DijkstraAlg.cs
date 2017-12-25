using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class DijkstraData
    {
        // как мы пришли в вершину
        public Node Previous { get; set; }
        // стоимость для этой вершины
        public double Price { get; set; }
    }

    class DijkstraAlg
    {
        private Graph graph;
        private Dictionary<Edge, double> weights;

        public DijkstraAlg(Graph graph, Dictionary<Edge, double> weights)
        {
            this.graph = graph;
            this.weights = weights;
        }

        public List<Node> Dijkstra(Node start, Node end)
        {
            // не посещённые вершины
            var notVisited = graph.Nodes.ToList();
            // словарь, вершина и ее Dijkstradata
            var track = new Dictionary<Node, DijkstraData>();
            // инициализация первой вершины
            track[start] = new DijkstraData { Price = 0, Previous = null };

            while (true)
            {
                // вершина, которую будем "открывать"
                Node toOpen = null;
                // наименьшая цена 
                var bestPrice = double.PositiveInfinity;
                // выбираем вершину из не посещённых с наименьшей ценой
                foreach (var e in notVisited)
                {
                    if (track.ContainsKey(e) && track[e].Price < bestPrice)
                    {
                        bestPrice = track[e].Price;
                        toOpen = e;
                    }
                }

                if (toOpen == null) return null;
                if (toOpen == end) break;

                foreach (var e in toOpen.IncidentEdges.Where(z => z.From == toOpen))
                {
                    var currentPrice = track[toOpen].Price + weights[e];
                    var nextNode = e.OtherNode(toOpen);
                    if (!track.ContainsKey(nextNode) || track[nextNode].Price > currentPrice)
                    {
                        track[nextNode] = new DijkstraData { Previous = toOpen, Price = currentPrice };
                    }
                }

                notVisited.Remove(toOpen);
            }

            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = track[end].Previous;
            }
            result.Reverse();
            return result;
        }
    }
}
