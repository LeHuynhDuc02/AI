using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    internal class Pair : ICloneable
    {
        public int a { get; set; }
        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}