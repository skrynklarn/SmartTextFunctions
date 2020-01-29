using SmartFunctions.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            ToolStripSeparator sep;

            
            item = new ToolStripMenuItem();
            item.Text = "Jira Table (with header)";
            item.Click += new EventHandler(JiraTableHeader);
            // item.Image = Resources.Explorer;
            item.ToolTipText = "Adds | to start/end of line and in every tab.";
            menu.Items.Add(item);

            
            item = new ToolStripMenuItem();
            item.Text = "Jira Table";
            item.Click += new EventHandler(JiraTable);
            // item.Image = Resources.About;
            item.ToolTipText = "Adds | to start/end of line and in every tab.";
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "CSV (,) int";
            item.Click += new EventHandler(CSV_Comma);
            item.ToolTipText = "Add , in every line break/tab.";
            // item.Image = Resources.About;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "CSV (,) string";
            item.Click += new EventHandler(CSV_CommaString);
            item.ToolTipText = "Add , in every line break/tab.";
            // item.Image = Resources.About;
            menu.Items.Add(item);

            item = new ToolStripMenuItem();
            item.Text = "CSV (;) int";
            item.Click += new EventHandler(CSV_Semicolon);
            item.ToolTipText = "Add ; in every line break/tab.";
            // item.Image = Resources.About;
            menu.Items.Add(item);

            // längd på text
            item = new ToolStripMenuItem();
            item.Text = "String information";
            item.Click += new EventHandler(StringInformation);
            item.ToolTipText = "Information about the string";
            // item.Image = Resources.About;
            menu.Items.Add(item);

            // Separator.
            sep = new ToolStripSeparator();
            menu.Items.Add(sep);

            // Info
            item = new ToolStripMenuItem();
            item.Text = "Info";
            item.Text = "Version 1.1.0";
            //item.Click += new System.EventHandler(Info_Click);
            // item.Image = Resources.Exit;
            menu.Items.Add(item);

            // Exit.
            item = new ToolStripMenuItem();
            item.Text = "Exit";
            item.Click += new System.EventHandler(Exit_Click);
            // item.Image = Resources.Exit;
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

        void Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.1.0", "Info");
        }
    }
}
