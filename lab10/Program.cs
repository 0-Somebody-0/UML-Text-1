using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        
        File.Create(@".\input.txt").Close();
        File.Create(@".\output.txt").Close();

        FileInfo fi = new FileInfo(@".\input.txt");
        FileInfo fi_1 = new FileInfo(@".\output.txt");
        int max = -101;
        int min = 101;

        using (StreamWriter SW = new StreamWriter(@".\input.txt"))      //fi.AppendText())
        {
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int numb = rand.Next(-100, 101);
                SW.WriteLine($"{numb}");

                if (numb > max)
                { max = numb; }
                if (numb < min)
                { min = numb; }
            }
        }

        

        string[] text = File.ReadAllLines(fi.FullName);

        using (StreamWriter SW = new StreamWriter(@".\output.txt")) //fi_1.AppendText())
        {
            for (int i = 0; i < 20; i++)
            {
                if (int.Parse(text[i]) % 2 == 0)
                { text[i] = $"{Math.Abs(max - min)}"; }
                SW.WriteLine(text[i]);
            }
        }



    }

}