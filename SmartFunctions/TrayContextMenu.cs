using System;
using System.Windows.Forms;

namespace SmartFunctions
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
                Text = "Jira Table (with header)",
                ToolTipText = "Adds | to start/end of line and in every tab."
            };
            item.Click += new EventHandler(JiraTableHeader);
            // item.Image = Resources.Explorer;
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "Jira Table",
                ToolTipText = "Adds | to start/end of line and in every tab."
            };
            item.Click += new EventHandler(JiraTable);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "CSV (,) int",
                ToolTipText = "Add , in every line break/tab."
            };
            item.Click += new EventHandler(CSV_Comma);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "CSV (,) string",
                ToolTipText = "Add , in every line break/tab."
            };
            item.Click += new EventHandler(CSV_CommaString);
            menu.Items.Add(item);

            item = new ToolStripMenuItem
            {
                Text = "CSV (;) int",
                ToolTipText = "Add ; in every line break/tab."
            };
            item.Click += new EventHandler(CSV_Semicolon);
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

            // Info
            item = new ToolStripMenuItem
            {
                Text = string.Format("Version {0}", Application.ProductVersion)
            };
            menu.Items.Add(item);

            // Exit
            item = new ToolStripMenuItem
            {
                Text = "Exit"
            };
            item.Click += new System.EventHandler(Exit_Click);
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

        void CSV_Comma(object sender, EventArgs e)
        {
            TextHandler.CSV(TextHandler.SEPERATOR_COLON);
        }

        void CSV_CommaString(object sender, EventArgs e)
        {
            TextHandler.CSV(TextHandler.SEPERATOR_COLON, true);
        }

        void CSV_Semicolon(object sender, EventArgs e)
        {
            TextHandler.CSV(TextHandler.SEPERATOR_SEMICOLON);
        }

        void StringInformation(object sender, EventArgs e)
        {
            TextHandler.StringInformation();
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
