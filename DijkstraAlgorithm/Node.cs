﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DijkstraAlgorithm
{
    class Node
    {
        // список инцидентных рёбер
        readonly List<Edge> edges = new List<Edge>();
        public readonly int NodeNumber;

        public Node(int number)
        {
            NodeNumber = number;
        }

        // перечисление инцидентных вершин
        public IEnumerable<Node> IncidentNodes
        {
            get
            {
                // возвращает для смежного ребра вторую вершину
                return edges.Select(z => z.OtherNode(this));
            }
        }

        // перечисление инцидентных рёбер
        public IEnumerable<Edge> IncidentEdges
        {
            get
            {
                // возвращает ребра из списка смежных
                foreach (var e in edges) yield return e;
            }
        }

        public static Edge Connect(Node node1, Node node2, Graph graph)
        {
            if (!graph.Nodes.Contains(node1) || !graph.Nodes.Contains(node2)) throw new ArgumentException();
            var edge = new Edge(node1, node2);
            node1.edges.Add(edge);
            node2.edges.Add(edge);
            return edge;
        }

        public static void Disconnect(Edge edge)
        {
            edge.From.edges.Remove(edge);
            edge.To.edges.Remove(edge);
        }
    }
}
