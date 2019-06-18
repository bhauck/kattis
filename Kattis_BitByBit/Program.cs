using System;
using System.Collections.Generic;

namespace Kattis_BitByBit
{
    class Program
    {
        static void Main(string[] args)
        { 
            Utils utils = new Utils();
            LinkedList<string> results = new LinkedList<string>();

            string line;
            Console.ReadLine();

            while ((line = Console.ReadLine()) != null)
            {
                string[] cmd = line.Split(' ');

                int n;
                if (int.TryParse(cmd[0], out n)) {
                    results.AddLast(utils.toString());
                    utils.initRegister();
                    if (n == 0) break;
                }

                switch ( cmd[0] )
                {
                    case "SET":
                        utils.set(Int32.Parse(cmd[1]));
                        break;
                    case "CLEAR":
                        utils.clear(Int32.Parse(cmd[1]));
                        break;
                    case "OR":
                        utils.or(Int32.Parse(cmd[1]), Int32.Parse(cmd[2]));
                        break;
                    case "AND":
                        utils.and(Int32.Parse(cmd[1]), Int32.Parse(cmd[2]));
                        break;
                }
            }

            foreach( string r in results )
            {
                Console.WriteLine(r);
            }
        }
    }

    class Utils
    {
        int[] register = new int[32];

        public Utils()
        {
            initRegister();
        }

        public void initRegister()
        {
            for (int i = 0; i < register.Length; i++)
            {
                register[i] = -1;
            }
        }

        public void set(int i)
        {
            register[i] = 1;
        }

        public void clear(int i)
        {
            register[i] = 0;
        }

        public void or(int i, int j)
        {
            if (register[i] != -1 && register[j] != -1)
            {
                register[i] = Convert.ToBoolean(register[i]) || Convert.ToBoolean(register[j]) ? 1 : 0;
            } else
            {
                register[i] = (register[i] == 1 || register[j] == 1) ? 1 : -1;
            }
        }

        public void and(int i, int j)
        {
            if (register[i] != -1 && register[j] != -1)
            {
                register[i] = Convert.ToBoolean(register[i]) && Convert.ToBoolean(register[j]) ? 1 : 0;
            }
            else
            {
                register[i] = (register[i] == 0 || register[j] == 0) ? 0 : -1;
            }
        }

        public string toString()
        {
            string register_str = "";

            for (int i = register.Length-1; i >= 0; i--)
            {
                switch( register[i] )
                {
                    case -1:
                        register_str += "?";
                        break;
                    case 0:
                        register_str += "0";
                        break;
                    case 1:
                        register_str += "1";
                        break;
                }
            }

            return register_str;
        }
    }
}
