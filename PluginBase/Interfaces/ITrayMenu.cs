using System.Windows.Forms;

namespace PluginBase.Interfaces
{
    public interface ITrayMenu
    {
        bool Add(ToolStripMenuItem addingItem);

        void AddSeparator();

        void Replace(ToolStripMenuItem oldItem, ToolStripMenuItem newItem);

        bool Remove(ToolStripMenuItem removingItem);
    }
}