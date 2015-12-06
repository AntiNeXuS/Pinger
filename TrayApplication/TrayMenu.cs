using System.Windows.Forms;
using PluginBase.Interfaces;

namespace TrayApp
{
    internal class TrayMenu : ITrayMenu
    {
        internal ContextMenuStrip ContextMenu { get; }

        public TrayMenu()
        {
            ContextMenu = new ContextMenuStrip();
        }

        #region ITrayMenu

        public bool Add(ToolStripMenuItem addingItem)
        {
            ContextMenu.Items.Add(addingItem);

            return true;
        }

        public void AddSeparator()
        {
            ContextMenu.Items.Add("-");
        }

        public void Replace(ToolStripMenuItem oldItem, ToolStripMenuItem newItem)
        {
            Remove(oldItem);
            Add(newItem);
        }

        public bool Remove(ToolStripMenuItem removingItem)
        {
            ContextMenu.Items.Remove(removingItem);

            return true;
        }

        #endregion
    }
}