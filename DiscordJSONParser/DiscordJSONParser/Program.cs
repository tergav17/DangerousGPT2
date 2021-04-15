using System;
using DiscordJSONParser.parser;

namespace DiscordJSONParser {
    class Program {
        static void Main(string[] args) {

            string sfin = "";
            string sfout = "output.txt";
            
            //Switch so if you want to parse by name instead of by channel
            //You can implement this one if you want to Max
            bool names = false;
            
            //Parse args
            int acnt = 0;
            foreach (string arg in args) {
                if (arg.Length < 1) continue;

                if (arg.Equals("-n")) names = true;
                else if (!arg.StartsWith("-")) {
                    if (acnt == 0) {
                        acnt = 1;
                        sfin = arg;
                    } else if (acnt == 1) {
                        sfout = arg;
                        acnt = 2;
                    }
                }
            }

            if (acnt == 0) {
                Console.WriteLine("Discord JSON to GTP2 Text Parser");
                Console.Write("File: ");
                sfin = Console.ReadLine();
            }
            
            Console.WriteLine("Parsing " + sfin + " into " + sfout);
            
            //Parse the files
            Parser.Parse(sfin, sfout);

        }
    }
}