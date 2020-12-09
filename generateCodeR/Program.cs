using System;
using System.Text;

namespace generateCodeR
{
    class Program
    {
        static void Main(string[] args)
        {
            first:
            Console.WriteLine("Please Enter your Precode : \n");
            string precode = Console.ReadLine().ToUpper();
            if (precode == "")
                goto first;

            char[] precodeChar = precode.ToCharArray(); // Convert Precode to Char Array
            byte[] getBytePrecode = Encoding.ASCII.GetBytes(precodeChar); // Convert Char Array to ASCII and assigning into Byte Array
            int x = getBytePrecode[1] + (getBytePrecode[0] * 5 * 2 - 698);
            int y = getBytePrecode[3] + (getBytePrecode[2] * 5 * 2 + x) - 0x210;
            decimal z = ((y << 3) - y) % 100;
            string generat_code = Convert.ToString(Math.Floor(z / 10) + (z % 10) * 5 * 2 + ((0x103 % x) % 100) * 5 * 5 * 4);
            string output = "";
            if (generat_code.Length == 3)
            {
                output += "0" + generat_code;
                Console.WriteLine("Code : " + output);
            }
                
            else if (generat_code.Length == 2)
            {
                output += "00" + generat_code;
                Console.WriteLine("Code : " + output);
            }
                
            else
            {
                if (generat_code.Length == 1)
                    generat_code = "000" + generat_code;
                Console.WriteLine("Code : " + generat_code);
            }
            
            goto first;
        }
    }
}
