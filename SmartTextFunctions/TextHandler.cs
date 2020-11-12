using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SmartTextFunctions
{
    class TextHandler
    {
        public const int INPUTTYPE_INT = 0;
        public const int INPUTTYPE_STRING = 1;
        public const String SEPERATOR_COLON = ",";
        public const String SEPERATOR_SEMICOLON = ";";

        /// <summary>
        /// Get text content from clipboard. If not text in clipboard it return null.
        /// </summary>
        /// <returns>string of text otherwise null.</returns>
        protected static String GetTextFromClipboard()
        {
            if (Clipboard.ContainsText(TextDataFormat.Text))
                return Clipboard.GetText();

            MessageBox.Show("Clipboard content was not text!", "SmartTextFunctions", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        protected static void SetTextToClipboard(String text)
        {
            if (!String.IsNullOrEmpty(text))
                Clipboard.SetText(text);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="header"></param>
        public static void JiraTable(bool header)
        {
            String input = GetTextFromClipboard();

            if (!String.IsNullOrEmpty(input))
            {
                String[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int n = 0; n < lines.Length; n++)
                {
                    String[] columns = lines[n].Split(new[] { "\t" }, StringSplitOptions.None);

                    for(int x = 0;  x < columns.Length; x++)
                    {
                        // if value is empty, add a space instead for the jira table to work.
                        if (String.IsNullOrEmpty(columns[x]))
                            columns[x] = " ";
                    }

                    String separator = (header && n == 0) ? "||" : "|";
                    lines[n] = AddWrapper(String.Join(separator, columns), separator);
                }

                String output = String.Join(Environment.NewLine, lines);
                SetTextToClipboard(output);
            }
        }

        /// <summary>
        /// Make a comma-separated values string devided by each line in the input string.
        /// </summary>
        /// <param name="seperator"></param>
        /// <param name="addStringWrapper"></param>
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
                        lines[n] = AddWrapper(lines[n], "'");
                    }
                }

                String output = String.Join(seperator, lines);
                SetTextToClipboard(output);
            }
        }

        /// <summary>
        /// Format text as SQL multi insert format like
        /// (aa, bb, cc),
        /// (xx, yy, zz);
        /// </summary>
        public static void SQLMultiInsertFormat()
        {
            String input = GetTextFromClipboard();

            if (!String.IsNullOrEmpty(input))
            {
                // Split all linebreaks.
                String[] lines = input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < lines.Length; i++)
                {
                    // Split on each tab.
                    String[] columns = lines[i].Split(new[] { "\t" }, StringSplitOptions.None);

                    for (int x = 0; x < columns.Length; x++)
                    {
                        // If value is NOT int then add '' around the value.
                        if (!IsStringInt(columns[x]))
                            columns[x] = AddWrapper(columns[x], "'");
                    }

                    // Add ( ) around each line and , between each tab.
                    lines[i] = AddWrapper(String.Join(",", columns), "(", ")");
                }

                // Adds , and linebreak between all lines.
                // Last line gets ; in the end.
                String output = String.Join(",\n", lines) + ";";

                SetTextToClipboard(output);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void StringInformation()
        {
            String input = GetTextFromClipboard();
            StringBuilder message = new StringBuilder();

            if (!String.IsNullOrEmpty(input))
            {
                message.AppendLine(String.Format("String length is {0} characters.", input.Length));
                message.AppendLine(String.Format("String has {0} rows.", Regex.Matches(input, "\n").Count + 1)); // Count linebreaks and then add 1 form last line.
                message.AppendLine(String.Format("String has {0} spaces.", Regex.Matches(input, " ").Count));
                message.AppendLine(String.Format("String has {0} tabs.", Regex.Matches(input, "\t").Count));
                MessageBox.Show(message.ToString(), "String information");
            }
        }

        /// <summary>
        /// Check if string value is int or not. 
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Returns true if string is int.</returns>
        protected static bool IsStringInt(string str)
        {
            // return true if int otherwise false
            return int.TryParse(str, out int i);  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="wrapper"></param>
        /// <returns></returns>
        protected static string AddWrapper(string str, string wrapper)
        {
            return AddWrapper(str, wrapper, wrapper);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        protected static string AddWrapper(string str, string prefix, string suffix)
        {
            return prefix + str + suffix;
        }
    }
}
