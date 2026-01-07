//NOTE this is not my code
using System;


    /// <summary>
    /// Třída OutputWriter odpovědná za výpis textů na konzoli.
    /// </summary>
    public class OutputWriter
    {
        readonly private string _divider = new string('*',50);

        /// <summary>
        /// Vypíše text na konzoli. Volitelně lze zadat barvu.
        /// </summary>
        /// <param name="text">Text k výpisu.</param>
        /// <param name="color">Volitelná barva textu.</param>
        public void Write(string text, ConsoleColor? color = null)
        {
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
                Console.Write(text);
                Console.ResetColor();
            }
            else
            {
                Console.Write(text);
            }
        }

        /// <summary>
        /// Vypíše text na konzoli s novým řádkem. Volitelně lze zadat barvu.
        /// </summary>
        /// <param name="text">Text k výpisu.</param>
        /// <param name="color">Volitelná barva textu.</param>
        public void WriteLine(string text, ConsoleColor? color = null)
        {
            if (color.HasValue)
            {
                Console.ForegroundColor = color.Value;
                Console.WriteLine(text);
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(text);
            }
        }

        /// <summary>
        /// Vypíše chybovou zprávu červenou barvou.
        /// </summary>
        /// <param name="text">Chybová zpráva.</param>
        public void WriteError(string text)
        {
            WriteLine(text, ConsoleColor.Red);
        }

        /// <summary>
        /// Vypíše úspěšnou zprávu zelenou barvou.
        /// </summary>
        /// <param name="text">Úspěšná zpráva.</param>
        public void WriteSuccess(string text)
        {
            WriteLine(text, ConsoleColor.Green);
        }

        /// <summary>
        /// Vypíše varovnou zprávu žlutou barvou.
        /// </summary>
        /// <param name="text">Varovná zpráva.</param>
        public void WriteWarning(string text)
        {
            WriteLine(text, ConsoleColor.Yellow);
        }

        /// <summary>
        /// Vypíše divider složený z 50 hvězdiček. Volitelně lze zadat barvu.
        /// </summary>
        /// <param name="color">Volitelná barva divideru.</param>
        public void WriteDivider(ConsoleColor? color = null)
        {
            WriteLine(_divider, color);
        }
    }
