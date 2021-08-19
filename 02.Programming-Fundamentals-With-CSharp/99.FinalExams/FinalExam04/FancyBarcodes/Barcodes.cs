namespace FancyBarcodes
{
    using System;
    using System.Text.RegularExpressions;

    public class Barcodes
    {
        static void Main(string[] args)
        {
            string barcodePattern = @"^@#+(?<barcode>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+$";
            string digitPattern = @"[0-9]";

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                if (Regex.IsMatch(input, barcodePattern))
                {
                    string barcode = Regex.Match(input, barcodePattern).Groups["barcode"].Value;
                    string group = "00";
                    if (Regex.IsMatch(barcode, digitPattern))
                    {
                        group = string.Empty;
                        foreach (Match match in Regex.Matches(barcode, digitPattern))
                        {
                            group += match.Value;
                        }
                    }

                    Console.WriteLine($"Product group: {group}");
                }
                else
                {
                    Console.WriteLine($"Invalid barcode");
                }
            }
        }
    }
}