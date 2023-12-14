namespace TEST4LABA
{
    internal class ColorChange
    {
        public byte r;
        public byte g;
        public byte b;
        internal void ColorRedToGreen(int val)
        {
            double sat;
            this.b = 0;
            if (val < 0) val = 0;
            if (val > 1000) val = 1000;
            if (val <= 500)
            {
                sat = val / 500.0f;
                this.r = 255;
                this.g = (byte)(sat * 255.0f);
            }
            if (val >= 500)
            {
                if (val > 1000) val = 1000;
                sat = (val - 500) / 500.0;
                this.r = (byte)((1.0f - sat) * 255.0f);
                this.g = 255;
            }
        }
    }
}
