using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Binary_search
{
    class Program
    {
        static void Main(string[] args)
        {
            // Before doing anything, we need to remove the headers from the file
            TrimColumnHeaders(args[0]);

            string[] records = GetFileRecords(args[0]);
            int usdot = Convert.ToInt32(args[1]);
            Stopwatch stopWatch = new Stopwatch();

            Console.WriteLine($"Starting linear search where USDOT = {usdot}");
            stopWatch.Start();
            Console.WriteLine(CarrierLinearSearch(usdot, records));
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            Console.WriteLine("Linear search took {0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds);
            stopWatch.Reset();
            stopWatch.Start();
            Console.WriteLine(CarrierBinarySearch(usdot, records));
            stopWatch.Stop();
            TimeSpan ts2 = stopWatch.Elapsed;
            Console.WriteLine("Binary search took {0:00}:{1:00}:{2:00}.{3:00}", ts2.Hours, ts2.Minutes, ts2.Seconds, ts2.Milliseconds);
            Console.WriteLine("Press any key to end application");
            Console.ReadLine();
        }

        static void TrimColumnHeaders(string file)
        {
            string tempFile = Path.Combine(Path.GetDirectoryName(file), "temp.csv");
            int lineNumber = 0;
            bool headerFound = false;
            
            using (StreamReader reader = new StreamReader(file))
            {
                string line = reader.ReadLine();
                lineNumber++;

                if (line.Contains("CARRIER_ID_NUMBER") && lineNumber == 1)
                {
                    headerFound = true;

                    using (StreamWriter writer = new StreamWriter(tempFile))
                    {
                        while (line != null)
                        {
                            if (!line.Contains("CARRIER_ID_NUMBER"))
                            {
                                writer.WriteLine(line);
                            }
                        }
                    }
                }
            }

            if (headerFound)
            {
                File.Delete(file);
                File.Copy(tempFile, file);
            }
        }

        static string[] GetFileRecords(string file)
        {
            return File.ReadAllLines(file);
        }

        static string CarrierLinearSearch(int usdot, string[] records)
        {
            int searchCount = 0;

            foreach (string record in records)
            {
                searchCount++;

                if (Convert.ToInt32(record.Split(',')[0]) == usdot)
                {
                    Console.WriteLine($"Searched through {searchCount} records");
                    return record;
                }
            }

            return $"Searched {searchCount} records. Record not found.";
        }

        static string CarrierBinarySearch(int usdot, string[] records)
        {
            int low = 0;
            int high = records.Length;
            int guess;
            int mid;
            int searchCount = 0;

            while (low <= high)
            {
                mid = (low + high)/2;
                guess = Convert.ToInt32(records[mid].Split(',')[0]);

                searchCount++;

                if (guess == usdot)
                {
                    Console.WriteLine($"Searched through {searchCount} records");
                    return records[mid];
                }
                if (guess > usdot)
                    high = mid - 1;
                else
                    low = mid + 1;
            }

            return $"Searched {searchCount} records. Record not found.";
        }
    }
}
