using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace DiscordJSONParser.parser {
    public class Parser {
        public static void Parse(string input, string output) {
            if (!File.Exists(input)) {
                Console.WriteLine("Input does not exist!");
                Console.WriteLine("Parse failure, output not created!");
            }
            
            //Read in the input
            string json = File.ReadAllText(input);

            Console.WriteLine("Length: " + json.Length);

            //JsonConvert to dynamic type
            dynamic discord = JsonConvert.DeserializeObject(json);
            
            File.WriteAllText(output, "", Encoding.UTF8);

            int size = discord.messageCount.ToObject<int>();
            
            for (int i = 0; i < size; i++) {
                string line = discord.messages[i].content;
                string name = discord.messages[i].author.name;

                if (line.Contains("https://")) continue;
                if (line.Length < 5) continue;

                if (i % 1000 == 10) Console.Write(".");

                File.AppendAllText(output, '<' + name + ">: " + line +'\n' + "<|endoftext|>" + "\n", Encoding.UTF8);
            }
            
            Console.WriteLine('\n' + "Finished");
        }
    }
}