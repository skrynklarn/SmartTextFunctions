using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartFunctions
{
    class TextHandler
    {
        public const int INPUTTYPE_INT = 0;
        public const int INPUTTYPE_STRING = 1;
        public const String SEPERATOR_COLON = ",";
        public const String SEPERATOR_SEMICOLON = ";";

        protected static String GetTextFromClipboard()
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
            {
                return Clipboard.GetText(TextDataFormat.Text);
            }
            else
            {
                MessageBox.Show("Clipboard content was not text!", "SmartTextFunction - Error!");
                return "";
            }
        }

        protected static void SetTextToClipboard(String text)
        {
            if (!String.IsNullOrEmpty(text))
            {
                Clipboard.SetText(text);
            }
        }

        public static void JiraTable(bool header)
        {
            String input = GetTextFromClipboard();

            if (!String.IsNullOrEmpty(input))
            {
                String[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                int i = 0;
                String output = "";

                foreach (String line in lines)
                {
                    String[] columns = line.Split(new[] { "\t" }, StringSplitOptions.None);

                    for(int x = 0;  x < columns.Length; x++)
                    {
                        if (String.IsNullOrEmpty(columns[x]))
                        {
                            columns[x] = " ";
                        }
                    }

                    String separator = (header && i == 0) ? "||" : "|";
                    String prefix = separator;
                    String suffix = separator + Environment.NewLine;

                    output += prefix + String.Join(separator, columns) + suffix;
                    i++;
                }
                SetTextToClipboard(output);
            }
        }

        // Make a comma-separated values string devided by each line in the input string.
        public static void CSV(String seperator, Boolean addStringWrapper = false)
        {
            String input = GetTextFromClipboard();

            if (!String.IsNullOrEmpty(input))
            {
                String[] lines = input.Trim().Split(new[] { "\r\n", "\r", "\n", "\t" }, StringSplitOptions.RemoveEmptyEntries);

                if (addStringWrapper)
                {
                    for(int n = 0; n < lines.Length; n++)
                    {
                        lines[n] = "'" + lines[n] + "'";
                    }
                }

                String output = String.Join(seperator, lines);
                SetTextToClipboard(output);
            }
        }

        public static string SQLIn(int inputtype)
        {
            String input = GetTextFromClipboard();
            string output = "";
            if (input != null)
            {
                if (inputtype == INPUTTYPE_INT)
                {
                    output = "IN (" + input.Trim().Replace("\n", ", ") + ")";
                }
                else if (inputtype == INPUTTYPE_STRING)
                {
                    output = "IN ('" + input.Trim().Replace("\n", "', '") + "')";
                }

            }
            return output;
        }

        public static void StringInformation()
        {
            String input = GetTextFromClipboard();
            StringBuilder message = new StringBuilder();

            if (String.IsNullOrEmpty(input))
            {
                message.AppendLine("String is empty!");
            }
            else
            {
                message.AppendLine(String.Format("String length is {0} characters.", input.Length));
                message.AppendLine(String.Format("String has {0} rows.", Regex.Matches(input, "\n").Count + 1)); // Count linebreaks and then add 1 form last line.
                message.AppendLine(String.Format("String has {0} spaces.", Regex.Matches(input, " ").Count));
                message.AppendLine(String.Format("String has {0} tabs.", Regex.Matches(input, "\t").Count));
            }

            MessageBox.Show(message.ToString(), "String information");
        }
    }
}
