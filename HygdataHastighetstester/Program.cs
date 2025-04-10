using System.Diagnostics;
using System.Threading.Channels;

namespace HygdataHastighetstester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new HygdataContext())
            {

                //FÖRSÖK 1 
                Stopwatch sw1 = new Stopwatch();
                sw1.Start();
                var stars = context.HygdataV3s.ToList();
                var starsLum = context.HygdataV3s
                    .OrderBy(h => h.Lum)
                    .Select(h => new { h.Id, h.Lum })
                    .ToList();
                sw1.Stop();

                //FÖRSÖK 2
                Stopwatch sw2 = new Stopwatch();
                sw2.Start();
                var stars2 = context.HygdataV3s
                    .OrderBy(h => h.Lum)
                    .ToList();
                var starsLum2 = stars2.Select(h => new { h.Id, h.Lum }).ToList();
                sw2.Stop();

                //FÖRSÖK 3
                Stopwatch sw3 = new Stopwatch();
                sw3.Start();
                var stars3 = context.HygdataV3s
                    .Select(h => new { h.Id, h.Lum })
                    .ToList();

                var starsLum3 = stars3
                    .OrderBy(h => h.Lum);

                sw3.Stop();

                //FÖRSÖK 4
                Stopwatch sw4 = new Stopwatch();
                sw4.Start();
                var stars4 = context.HygdataV3s
                    .OrderBy(h => h.Lum)
                    .Select(h => new { h.Id, h.Lum })
                    .ToList();
                sw4.Stop();

                //FÖRSÖK 5
                Stopwatch sw5 = new Stopwatch();
                sw5.Start();
                var stars5 = context.HygdataV3s
                    .Select(h => new { h.Id, h.Lum })
                    .OrderBy(h => h.Lum)
                    .ToList();
                sw5.Stop();


                //RESULTAT
                Console.WriteLine("FÖRSÖK 1:");
                Console.WriteLine("    Steg 1: Hela tabellen hämtas.");
                Console.WriteLine("    Steg 2: Data sorteras efter Lum och kolumnerna väljs ut.");
                Console.WriteLine($"Resultat; {sw1.ElapsedMilliseconds} ms");
                Console.WriteLine();

                Console.WriteLine("FÖRSÖK 2:");
                Console.WriteLine("    Steg 1: Tabellen hämtas sorterad efter Lum.");
                Console.WriteLine("    Steg 2: Kolumnerna väljs ut.");
                Console.WriteLine($"Resultat; {sw2.ElapsedMilliseconds} ms");
                Console.WriteLine();


                Console.WriteLine("FÖRSÖK 3:");
                Console.WriteLine("    Steg 1: Tabellen hämtas med utvalda kolumner.");
                Console.WriteLine("    Steg 2: Tabellen sorteras efter Lum.");
                Console.WriteLine($"Resultat; {sw3.ElapsedMilliseconds} ms");
                Console.WriteLine();

                Console.WriteLine("FÖRSÖK 4:");
                Console.WriteLine("    Steg 1: Tabellen hämtas sorterad efter Lum och sedan väljs kolumnerna.");
                Console.WriteLine($"Resultat; {sw4.ElapsedMilliseconds} ms");
                Console.WriteLine();

                Console.WriteLine("FÖRSÖK 5:");
                Console.WriteLine("    Steg 1: Tabellen hämtas med valda kolumner och sedan sorterad efter Lum.");
                Console.WriteLine($"Resultat; {sw5.ElapsedMilliseconds} ms");
                Console.WriteLine();

                PresentWinner(sw1, sw2, sw3, sw4, sw5);
            }
        }

        private static void PresentWinner(Stopwatch sw1, Stopwatch sw2, Stopwatch sw3, Stopwatch sw4, Stopwatch sw5)
        {
            var times = new[]
                            {
                    sw1.ElapsedMilliseconds,
                    sw2.ElapsedMilliseconds,
                    sw3.ElapsedMilliseconds,
                    sw4.ElapsedMilliseconds,
                    sw5.ElapsedMilliseconds
                };

            var minTime = times.Min();
            var winnerIndex = Array.IndexOf(times, minTime);

            Console.WriteLine("\nVinnare: FÖRSÖK " + (winnerIndex + 1) + " med tiden: " + minTime + " ms");
        }
    }
}
