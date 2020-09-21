using System;
using System.Linq;
using System.Collections.Generic;

namespace codewars_hexagon_beam_max_sum
{
    class Program
    {
        public class Hexagon
        {
            public List<HexagonRow> body { get; set; }
            public int rowCount { get; set; }
            public Hexagon()
            {
                this.body = new List<HexagonRow>();
                this.rowCount = 0;
            }

            public void addRowCount(int count)
            {
                this.rowCount = count;
            }
        }

        public class HexagonRow
        {
            public List<int> rowData { get; set; }
            public int delta { get; set; }

            public int rowLen { get; set; }

            public HexagonRow()
            {
                this.rowData = new List<int>();
                this.delta = 0;
                this.rowLen = 0;
            }
        }


        public static int MaxHexagonBeam(int n, int[] seq)
        {
            /*Console.Write("n {0} ", n);
            foreach(int item in seq)
            { Console.Write("{0} ", item);}
            Console.WriteLine("");*/
            int counter = 0, seqCnt = 0, max;
            short step = 1;
            Hexagon hex = new Hexagon();
            for (int i = n; i >= n; i += step)
            {
                //Console.WriteLine(i);
                hex.body.Add(new HexagonRow());
                hex.body[counter].delta = step;
                hex.body[counter].rowLen = i;
                for (int j = 0; j < i; j++)
                { hex.body[counter].rowData.Add(seq[seqCnt++ % seq.Length]); }
                if (i == 2 * n - 1)
                {
                    hex.body[counter].delta = 0;
                    step = -1;
                }
                counter++;
            }
            hex.addRowCount(counter);

            max = hex.body[0].rowData.Sum();
            // check row sums
            for (int i = 1; i < hex.rowCount; i++)
            {
                int sum = hex.body[i].rowData.Sum();
                if (sum > max) { max = sum; }
            }

            // check beams top-right to down-left
            // starting from top side, without last cell
            for (int i = 0; i < n - 1; i++)
            {
                int sum = 0, x = i;
                for (int row = 0; ; row++)
                {
                    sum += hex.body[row].rowData[x];
                    if (hex.body[row].delta <= 0)
                    { x += -1; }
                    if (x < 0)
                    { break; }
                }
                //Console.WriteLine("sum: {0}", sum);
                if (sum > max) { max = sum; }
            }
            // starting from top right side
            for (int i = 0; hex.body[i].delta != -1; i++)
            {
                int x = hex.body[i].rowLen - 1;
                int sum = 0;
                //Console.WriteLine("startX: {0}", x);
                for (int row = i; row < 2 * n - 1; row++)
                {
                    if (hex.body[row].delta == -1)
                    { x += -1; }
                    //Console.WriteLine("row: {0}, x: {1}, val: {2}", row, x, hex.body[row].rowData[x]);
                    sum += hex.body[row].rowData[x];

                }
                if (sum > max) { max = sum; }
                //Console.WriteLine("sum: {0}", sum);
            }

            // check beams from top-left to bottom right
            // starting from top-left side
            for (int i = 0; hex.body[i].delta != -1; i++)
            {
                int x = 0;
                int sum = 0;
                for (int row = i; row < 2 * n - 1; row++)
                {

                    //Console.WriteLine("row: {0}, x: {1}, val: {2}", row, x, hex.body[row].rowData[x]);
                    sum += hex.body[row].rowData[x];
                    if (hex.body[row].delta == 1)
                    { x += 1; }

                }
                if (sum > max) { max = sum; }
                //Console.WriteLine("sum: {0}", sum);
            }
            // starting from top side, without first cell
            for (int i = 1; i < n; i++)
            {
                int sum = 0, x = i;
                for (int row = 0; ; row++)
                {
                    if (x > hex.body[row].rowLen - 1)
                    { break; }
                    sum += hex.body[row].rowData[x];
                    //Console.WriteLine("row: {0}, x: {1}, val: {2}", row, x, hex.body[row].rowData[x]);
                    if (hex.body[row].delta == 1)
                    { x += 1; }
                }
                //Console.WriteLine("sum: {0}", sum);
                if (sum > max) { max = sum; }
            }

            return max;

        }
        static void Main(string[] args)
        {
            int x = 0;
            x = MaxHexagonBeam(2, new int[] { -138 });
            Console.WriteLine("Hello World! {0}", x);
        }
    }
}

