namespace PluginBase.Interfaces
{
    public interface IPlugin
    {
        bool Initialize(ITrayMenu menu);

        void Stop();
    }
}