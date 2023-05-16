using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of values:");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Enter the values:");
            int[] items = new int[n];
            for(int i=0;i<n; i++)
            {
                items[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(items);
     
            median(items, n);

            mode(items);

            q3(items, n);

            p90(items, n);

            int range = items[n-1] - items[0];
            Console.WriteLine("Range is:" + range);
        } 
        public static void median(int []items3,int s)
        {
            if (s % 2 != 0)
            {
                Console.WriteLine("Median is:" + items3[s / 2]);
            }
            else
            {
                double z = (double)(items3[(s - 1) / 2] + items3[s / 2]) / 2;
                Console.WriteLine("Median is:" + z);
            }
        }
        public static void mode(int[]items3)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();
            int mostfreq = 0;
            for(int j = 0; j < items3.Length; j++)
            {
                if (freq.ContainsKey(items3[j])==false)
                {
                    freq[items3[j]] = 1;
                }
                else
                {
                    freq[items3[j]]= freq[items3[j]]+1;
                }
                if (freq[items3[j]] > mostfreq)
                {
                    mostfreq = freq[items3[j]];
                }
            }
            if (freq.Count == 1)
            {
                Console.Write("Mode = ");
                foreach(var n in freq)
                {
                    Console.WriteLine(n.Key);
                }
                return;
            }
            bool isAllSamefreq = true;
            foreach(var n in freq)
            {
                if(n.Value!=mostfreq)
                {
                    isAllSamefreq = false;
                    break;
                }
            }
            if (isAllSamefreq == true)
            {
                Console.WriteLine("No mode as all have same frequency");
                return;
            }
            Console.Write("Mode = { ");
            foreach(var n in freq)
            {
                if (n.Value == mostfreq)
                {
                    Console.Write(n.Key + " ");
                }
            }
            Console.WriteLine("}");
        }
        public static void q3(int[]items4,int f)
        {
            double q1 , q3 , iqr ;
            if ((f / 2) % 2 == 0)
            {
                int s = (int)(0.25 * f);
                double b = (0.75 * f);
                int j=(int)Math.Ceiling(b);
                q1 = (items4[ s-1 ] + items4[s]) / 2;
                q3 = (items4[j] + items4[j - 1]) / 2;
            }
            else
            {
                int s = (int)(0.25 * f);
                int b = (int)(0.75 * f);
                q1 = items4[s];
                q3 = items4[b];
            }
            Console.WriteLine("Q1 is:" + q1);
            Console.WriteLine("Q3 is:" + q3);
            iqr = q3 - q1;
            Console.WriteLine("IQR is:" + iqr);
            outlier(q1,q3,iqr,items4);
        }
        public static void outlier(double t,double v,double o, int[] items5)
        {
            double d = t - (1.5 * o);
            double w = v + (1.5 * o);
            Console.WriteLine("the boundaries of the outlier is: [{0},{1}]",d,w);
            for(int i = 0; i <items5.Length; i++)
            {
                if (items5[i] < d)
                {
                    Console.WriteLine("the outlier is: " + items5[i]);
                }
                else if(items5[i] > w)
                {
                    Console.WriteLine("the outlier is: " + items5[i]);
                }
                else if(i==(items5.Length-1))
                {
                    Console.WriteLine("There is no outlier!");
                }
            } 
        }
        public static void p90(int[]items6,int q)
        {
            double p90 = 0.9*q;
            p90 = Math.Round(p90);
            for(int i = 0; i < items6.Length; i++)
            {
                if (p90 == i)
                {
                    Console.WriteLine("p90 is: " + items6[i]);
                }
            }
        }
    }
}
