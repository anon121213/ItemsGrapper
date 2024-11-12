namespace _Scripts.Data.DataProvider
{
    public class DataProvider : IDataProvider
    {
        public DataProvider(AllData allData)
        {
            PlayerSettings = allData.DefaultPlayerSettings;
            ObjectsReferences = allData.ObjectsReferences;
            ItemsReferences = allData.ItemsReferences;
        }

        public DefaultPlayerSettings PlayerSettings { get; }
        public ObjectsReferences ObjectsReferences { get; }
        public ItemsReferences ItemsReferences { get; }
    }
}