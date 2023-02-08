using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class User
    {
        private string name;
        private int minyt;
        private int sekynd;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Minyt
        {
            get { return minyt; }
            set { minyt = value; }
        }

        public int Sekynd
        {
            get { return sekynd; }
            set { sekynd = value; }
        }
        public User()
        {
        }
    }
}

