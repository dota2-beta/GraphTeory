using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace TEST4LABA
{
    public partial class EdgeWeightedDigraph
    {
        public int V; // vertices
        public int E; // edges
        public List<DirectedEdge>[] adj;
        private int[] Indegree;
        private void ValidateVertex(int v)
        {
            if (v < 0 || v >= V + 1) throw new ArgumentException("vertex " + v + " is not between 0 and " + V);
        }
        private bool inGraph(DirectedEdge e)
        {
            foreach (var lists in adj)
                foreach (var someE in lists)
                    if (someE == e)
                        return true;
            return false;
        }
        public void AddEdge(DirectedEdge e)
        {
            if (!inGraph(e))
            {
                int v = e.From();
                int w = e.To();
                ValidateVertex(v);
                ValidateVertex(w);
                adj[v].Add(e);
                Indegree[w]++;
                E++;
            }
        }
        public IEnumerable<DirectedEdge> GetAdj(int v)
        {
            ValidateVertex(v);
            return adj[v];
        }
        public int GetOutDegree(int v)
        {
            ValidateVertex(v);
            return adj[v].Count;
        }
        public int GetIndegree(int v)
        {
            ValidateVertex(v);
            return Indegree[v];
        }       
        public EdgeWeightedDigraph(string filepath)
        {
            try
            {
                if (!File.Exists(filepath)) { throw new Exception("no file with such filepath"); }
                using (StreamReader sr = new StreamReader(filepath))
                {
                    int i = 0;
                    while (sr.Peek() >= 0)
                    {
                        if (i == 0)
                        {
                            V = Convert.ToInt32(sr.ReadLine());
                            adj = new List<DirectedEdge>[V];
                            Indegree = new int[V];
                            for (int v = 0; v < V; v++)
                            {
                                adj[v] = new List<DirectedEdge>();
                            }
                            i++;
                        }
                        else
                            if (i == 1)
                        {
                            E = Convert.ToInt32(sr.ReadLine());
                            if (E < 0) throw new ArgumentException("number of edges in a Graph must be nonnegative");
                            i++;
                        }
                        else
                        {
                            string s = sr.ReadLine();
                            Char delimiter = ' ';
                            String[] substrings = s.Split(delimiter);
                            int v = Convert.ToInt32(substrings[0]);
                            int w = Convert.ToInt32(substrings[1]);
                            double weight = Convert.ToDouble(substrings[2]);
                            ValidateVertex(v);
                            ValidateVertex(w);
                            DirectedEdge e = new DirectedEdge(v, w, weight);
                            AddEdge(e);
                        }

                    }
                }
            }
            catch (Exception e) { Console.WriteLine("The process failed: {0}", e.ToString()); };
        }
        public EdgeWeightedDigraph(int V, int D, List<double[]> lst)
        {
            this.V = V;
            this.E = D;
            adj = new List<DirectedEdge>[V];
            Indegree = new int[V];
            for (int v = 0; v < V; v++)
            {
                adj[v] = new List<DirectedEdge>();
            }
            foreach (var someAdj in lst)
            {
                int v = Convert.ToInt32(someAdj[0]);
                int w = Convert.ToInt32(someAdj[1]);
                double weight = Convert.ToDouble(someAdj[2]);
                ValidateVertex(v);
                ValidateVertex(w);
                DirectedEdge e = new DirectedEdge(v, w, weight);
                AddEdge(e);
                DirectedEdge ee = new DirectedEdge(w, v, weight);
                AddEdge(ee);
            }
        }
        public void DFS(int x, List<int> used, List<int> path)
        {
            used[x] = 1;
            path.Add(x);
            foreach (var p in adj[x])
            {
                if (used[p.To()] != 1)
                    DFS(p.To(), used, path);
            }
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            s.Append("Verticles: " + V + " " + "Edges: " + E / 2 + "\n"); // E%2 because each edge twice in verticle
            for (int v = 0; v < V; v++)
            {
                //s.Append(v + ": ");
                foreach (DirectedEdge e in adj[v])
                {
                    s.Append(e.From() + " -> " + e.To() + "  ");
                }
                s.Append("\n");
            }
            return s.ToString();
        }
        public List<int> BFS(int start) //обход в ширину
        {
            List<int> used = new List<int>();
            List<int> path = new List<int>();
            for (int i = 0; i < V; ++i)
            {
                used.Add(0);
            }
            used[start] = 1;
            path.Add(start);
            //used[x] = 1; //x - посещенная вершина
            Queue<int> h = new Queue<int>();
            h.Enqueue(start);
            while (h.Count != 0)
            { //пока очередь не пуста
                int v = h.Dequeue();
                foreach (var u in adj[v])
                    if (used[u.To()] == 0)
                    {
                        used[u.To()] = 1;
                        path.Add(u.To());
                        h.Enqueue(u.To());
                    }
            }
            return path;
        }
    }
}
