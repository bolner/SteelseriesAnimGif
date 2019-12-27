/*
    Copyright 2019 Tamas Bolner
    
    Licensed under the Apache License, Version 2.0 (the "License");
    you may not use this file except in compliance with the License.
    You may obtain a copy of the License at
    
      http://www.apache.org/licenses/LICENSE-2.0
    
    Unless required by applicable law or agreed to in writing, software
    distributed under the License is distributed on an "AS IS" BASIS,
    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    See the License for the specific language governing permissions and
    limitations under the License.
*/
using System;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing;

namespace SteelSeriesAnimGif {
    public class Program {
        public static int Main(string[] args) {
            try {
                if (args.Length < 1) {
                    throw new Exception("Usage:\n\n\tdotnet run [path/fileName.txt]");
                }

                string source = args[0];
                string target = Regex.Replace(source, @"\.txt$", ".gif", RegexOptions.IgnoreCase);
                if (source == target) {
                    throw new Exception("The input must be a text file with '.txt' extension.");
                }

                var text = Kaypro2Font.ConvertText(File.ReadAllText(source));

                using(var gif = AnimatedGif.AnimatedGif.Create(target, 100))
                using(var img = new Bitmap(128, 40)) {
                    for (int y = 0; y > -text.Length*12; y--) {
                        using(var graphics = Graphics.FromImage(img)) {
                            graphics.Clear(Color.Black);
                        }

                        for (int a = 0; a < 16; a++) {
                            for (int b = 0; b < text.Length * 2; b++) {
                                Kaypro2Font.DrawCharacter(img, text.Data[a, b % text.Length], a * 8, b * 12 + y, Color.White, 1);
                            }
                        }

                        gif.AddFrame(img);
                    }
                }
            } catch (Exception ex) {
                Console.Error.WriteLine($"{ex.Message}\n\n");
                return 1;
            }

            return 0;
        }
    }
}
