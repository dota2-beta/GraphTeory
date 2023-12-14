using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST4LABA
{
    public partial class DirectedEdge
    {
        private int v;
        private int w;
        private double weight;
        public DirectedEdge(int v, int w, double weight)
        {
            if (v < 0) throw new ArgumentException("Vertex names must be nonnegative integers");
            if (w < 0) throw new ArgumentException("Vertex names must be nonnegative integers");
            if (Double.IsNaN(weight)) throw new ArgumentException("Weight is NaN");
            this.v = v;
            this.w = w;
            this.weight = weight;
        }
        public int From()
        {
            return v;
        }
        public int To()
        {
            return w;
        }
        public double GetWeight()
        {
            return weight;
        }
        public static bool operator ==(DirectedEdge e1, DirectedEdge e2)
        {
            return e1.v == e2.v && e1.w == e2.w;
        }
        public static bool operator !=(DirectedEdge e1, DirectedEdge e2)
        {
            return e1.v != e2.v || e1.w != e2.w;
        }
    }
}
