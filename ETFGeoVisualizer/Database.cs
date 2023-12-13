public interface IDatabase
{
    List<Asset> RetrieveAssetsMatchingPattern(string tickerRegex);
}

