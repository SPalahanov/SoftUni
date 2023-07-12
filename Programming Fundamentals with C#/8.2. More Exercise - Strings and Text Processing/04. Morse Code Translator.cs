using System.Text;

namespace _04._Morse_Code_Translator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] message = Console.ReadLine().Split('|');

            StringBuilder cod = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                StringBuilder sb = new StringBuilder();

                string[] word = message[i].Split();

                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == ".-") word[j] = "A";
                    if (word[j] == "-...") word[j] = "B";
                    if (word[j] == "-.-.") word[j] = "C";
                    if (word[j] == "-..") word[j] = "D";
                    if (word[j] == ".") word[j] = "E";
                    if (word[j] == "..-.") word[j] = "F";
                    if (word[j] == "--.") word[j] = "G";
                    if (word[j] == "....") word[j] = "H";
                    if (word[j] == "..") word[j] = "I";
                    if (word[j] == ".---") word[j] = "J";
                    if (word[j] == "-.-") word[j] = "K";
                    if (word[j] == ".-..") word[j] = "L";
                    if (word[j] == "--") word[j] = "M";
                    if (word[j] == "-.") word[j] = "N";
                    if (word[j] == "---") word[j] = "O";
                    if (word[j] == ".--.") word[j] = "P";
                    if (word[j] == ".-.") word[j] = "R";
                    if (word[j] == "...") word[j] = "S";
                    if (word[j] == "-") word[j] = "T";
                    if (word[j] == "..-") word[j] = "U";
                    if (word[j] == "...-") word[j] = "V";
                    if (word[j] == ".--") word[j] = "W";
                    if (word[j] == "-..-") word[j] = "X";
                    if (word[j] == "-.--") word[j] = "Y";
                    if (word[j] == "--..") word[j] = "Z";
                    
                    sb.Append(word[j]);
                }
                
                cod.Append(sb + " ");
            }

            Console.WriteLine(cod.ToString());
        }
    }
}