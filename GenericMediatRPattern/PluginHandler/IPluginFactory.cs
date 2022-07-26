namespace GenericMediatRPattern.PluginHandler
{
    public interface IPluginFactory
    {
        T GetService<T>(string localeType);
        void Initialize();
    }
}
