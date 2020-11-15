using System;
using System.Text;
using System.Windows.Forms;

namespace SmartTextFunctions
{
    class TrayContextMenu
    {
        /// <summary>
        /// Creates this instance.
        /// </summary>
        /// <returns>ContextMenuStrip</returns>
        public ContextMenuStrip Create()
        {
            // Add the default menu options.
            ContextMenuStrip menu = new ContextMenuStrip();
            ToolStripMenuItem item;

            item = new ToolStripMenuItem
            {
                Text = "Jira table (with header)",
                ToolTipText = "Tableformated (with header) string for Jira"
			};
            item.Click += new EventHandler(JiraTableHeader);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "Jira table (without header)",
                ToolTipText = "Tableformated (without header) string for Jira"
			};
            item.Click += new EventHandler(JiraTable);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "CSV int",
				ToolTipText = "Example output: 0,1,2"
			};
            item.Click += new EventHandler(CSV_Comma);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "CSV string",
				ToolTipText = "Example output: 'a','b','c'"
			};
            item.Click += new EventHandler(CSV_CommaString);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "Semicolon-seperated int",
                ToolTipText = "Example output: 0;1;2"
			};
            item.Click += new EventHandler(CSV_Semicolon);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "SQL insert dataset",
                ToolTipText = "Format columns and lines in SQL multi insert format"
            };
            item.Click += new EventHandler(SQLMultiInsertFormat);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "String information",
                ToolTipText = "Information about the string"
            };
            item.Click += new EventHandler(StringInformation);
            menu.Items.Add(item);

            // Separator
            menu.Items.Add(new ToolStripSeparator());

            // About pop-up
            item = new ToolStripMenuItem
            {
                Text = string.Format("About")
            };
            item.Click += new EventHandler(About_Click);
            menu.Items.Add(item);   

            // Exit
            item = new ToolStripMenuItem
            {
                Text = "Exit"
            };
            item.Click += new EventHandler(Exit_Click);
            menu.Items.Add(item);

            return menu;
        }

        /// <summary>
        /// Handles the Click event of the Explorer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void JiraTableHeader(object sender, EventArgs e)
        {
            TextHandler.JiraTable(true);
        }

        /// <summary>
        /// Handles the Click event of the About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void JiraTable(object sender, EventArgs e)
        {
            TextHandler.JiraTable(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CSV_Comma(object sender, EventArgs e)
        {
            TextHandler.CSV(TextHandler.SEPERATOR_COLON);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CSV_CommaString(object sender, EventArgs e)
        {
            TextHandler.CSV(TextHandler.SEPERATOR_COLON, true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CSV_Semicolon(object sender, EventArgs e)
        {
            TextHandler.CSV(TextHandler.SEPERATOR_SEMICOLON);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void SQLMultiInsertFormat(object sender, EventArgs e)
        {
            TextHandler.SQLMultiInsertFormat();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void StringInformation(object sender, EventArgs e)
        {
            TextHandler.StringInformation();
        }

        /// <summary>
        /// Show some short about information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void About_Click(object sender, EventArgs e)
        {
            StringBuilder message = new StringBuilder();

            message.AppendLine("Homepage: " + "https://github.com/skrynklarn/SmartTextFunctions");
            message.AppendLine("Version: " + Application.ProductVersion);
            MessageBox.Show(message.ToString(), "About SmartTextFunctions");
        }

        /// <summary>
        /// Processes a menu item.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void Exit_Click(object sender, EventArgs e)
        {
            // Quit without further ado.
            Application.Exit();
        }
    }
}
