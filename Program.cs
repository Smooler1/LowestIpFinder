using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_nearest_free_ip
{
    internal class Program
    {
        static public void Main(string[] args)
        {
            List<string> usedIPs = new List<string> { "1.2.3.5", "1.2.3.4", "1.2.3.9" };
            Console.WriteLine(LowestIp(usedIPs));

        }

        static uint IpToInt(string ip)
        {
            var parts = ip.Split('.');
            if (parts.Length != 4)
                throw new Exception("Неправильный формат IP");

            uint a = uint.Parse(parts[0]);
            uint b = uint.Parse(parts[1]);
            uint c = uint.Parse(parts[2]);
            uint d = uint.Parse(parts[3]);

            return a * 256u * 256u * 256u + b * 256u * 256u + c * 256u + d;
        }


        static string IntToIp(uint num)
        {
            uint a = num / (256u * 256u * 256u);
            num %= 256u * 256u * 256u;

            uint b = num / (256u * 256u);
            num %= 256u * 256u;

            uint c = num / 256u;
            uint d = num % 256u;

            return $"{a}.{b}.{c}.{d}";
        }


        static string LowestIp(List<string> usedIPs)
        {
            List<uint> usedIPsInt = new List<uint> { };
            for (int i = 0; i < usedIPs.Count; i++)
            {
                usedIPsInt.Add(IpToInt(usedIPs[i]));
            }

            usedIPsInt.Sort();

            uint desiredIp = usedIPsInt[0] + 1;
            for (int i = 0; i < usedIPsInt.Count; i++)
            {
                if (desiredIp == usedIPsInt[i])
                    desiredIp++;
            }

            if (desiredIp == 0) { desiredIp = usedIPsInt.Last() + 1; }

            if (desiredIp % 256 == 0) { desiredIp++; }


            if (IntToIp(desiredIp) == "0.0.0.1") return "Нет доступногог IP!";

            return IntToIp(desiredIp);
        }
    }
    }

