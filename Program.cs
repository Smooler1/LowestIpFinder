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
            uint a = uint.Parse(parts[0]);
            uint b = uint.Parse(parts[1]);
            uint c = uint.Parse(parts[2]);
            uint d = uint.Parse(parts[3]);

            return a * 256 * 256 * 256 + b * 256 * 256 + c * 256 + d;
        }


        static string IntToIp(uint num)
        {
            uint a = num / (256 * 256 * 256);
            num %= 256 * 256 * 256;
            uint b = num / (256 * 256);
            num %= 256 * 256;
            uint c = num / 256;
            uint d = num % 256;

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

            uint desiredIp = 0;
            for (int i = 0; i < usedIPsInt.Count - 1; i++)
            {   
            uint current = usedIPsInt[i];
            uint next = usedIPsInt[i + 1];

                if (next > current + 1 ) 
                { 
                    desiredIp = current + 1;
                    
                    break; 
                }

                if(desiredIp == 0) { desiredIp = usedIPsInt.Last() + 1; }

                if(desiredIp %  256 == 0) { desiredIp++; }    
            
            }
            return IntToIp(desiredIp);
        }
    }
    }

