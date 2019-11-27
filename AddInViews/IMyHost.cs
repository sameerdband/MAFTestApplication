namespace AddInViews
{
    public interface IMyHost
    {
        string Name { get; }

        string Description { get; }

        void LogMessage(string message);

        string GetData();
    }
}
