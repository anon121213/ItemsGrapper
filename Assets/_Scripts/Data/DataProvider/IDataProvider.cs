namespace _Scripts.Data.DataProvider
{
    public interface IDataProvider
    {
        DefaultPlayerSettings PlayerSettings { get; }
        ObjectsReferences ObjectsReferences { get; }
        ItemsReferences ItemsReferences { get; }
    }
}