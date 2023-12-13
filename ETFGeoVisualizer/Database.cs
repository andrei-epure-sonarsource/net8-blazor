public interface Database
{
    List<Asset> RetrieveAssetsMatchingPattern(string tickerRegex, Dictionary<string, Asset> assetsBySearchableKey);
}

