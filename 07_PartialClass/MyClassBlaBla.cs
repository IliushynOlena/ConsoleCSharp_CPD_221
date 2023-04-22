using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07_PartialClass
{
    partial class MyClassBlaBla
    {
        private double mark;
        public string Name { get; set; } = "Olena";
        public string SurName { get; set; } = "Ilishyn";

        public void SetMark(ref double m)
        {
            this.mark = m;
        }



    }
}
