using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    internal class DijkstraAlg
    {
        private readonly Graph graph;
        private readonly Dictionary<Edge, int> weights;

        public DijkstraAlg(Graph graph, Dictionary<Edge, int> weights)
        {
            this.graph = graph;
            this.weights = weights;
        }

        public List<Node> Dijkstra(Node start, Node end, IPriorityQueue queue)
        {
            // словарь
            var track = new Dictionary<Node, Node>
            {
                // инициализация первой вершины
                [start] = null
            };

            queue.Add(new BinaryNode(start, 0));

            while (true)
            {
                // вершина, которую будем "открывать"
                var binaryNode = queue.ExtractMin();

                if (binaryNode == null) return null;

                var toOpen = binaryNode.Node;
                var price = binaryNode.Priority;

                if (binaryNode.Node == end) break;

                foreach (var e in toOpen.IncidentEdges.Where(z => z.From == toOpen))
                {
                    var currentPrice = price + weights[e];
                    var nextNode = e.OtherNode(toOpen);
                    
                    if (queue.UpdateOrAdd(new BinaryNode(nextNode, price), currentPrice))
                        track[nextNode] = toOpen;
                }
            }

            return GetPathTo(end, track);
        }

        private static List<Node> GetPathTo(Node end, Dictionary<Node, Node> track)
        {
            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = track[end];
            }
            result.Reverse();
            return result;
        }
    }
}
