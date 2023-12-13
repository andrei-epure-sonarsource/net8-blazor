using System.Text.RegularExpressions;

public class FakeDatabase : IDatabase
{
    // ETFs
    private static readonly List<GeoWeight> vwceGeoAllocation =
    [
        new("US", 0.56m),
        new("Europe", 0.17m),
        new("Japan", 0.08m),
        new("Pacific", 0.05m),
        new("Emerging Markets", 0.14m)
    ];

    private static readonly List<GeoWeight> exsaGeoAllocation =
    [
        new("Europe", 1m),
    ];

    private static readonly List<GeoWeight> iqqhGeoAllocation =
    [
        new("US", 0.32m),
        new("Europe", 0.23m),
        new("Japan", 0.03m),
        new("Pacific", 0.12m),
        new("Emerging Markets", 0.30m)
    ];

    // Stocks
    private static readonly List<GeoWeight> applGeoAllocation = [new("US", 1m)];
    private static readonly List<GeoWeight> nesnGeoAllocation = [new("Europe", 1m)];
    private static readonly List<GeoWeight> tmGeoAllocation = [new("Japan", 1m)];
    private static readonly List<GeoWeight> sonyGeoAllocation = [new("Japan", 1m)];
    private static readonly List<GeoWeight> msftGeoAllocation = [new("US", 1m)];

    private static readonly Dictionary<string, Asset> assetsBySearchableKey = new()
    {
        ["VWCE"] = new("VWCE", AssetClass.ETF, "Vanguard FTSE All-World UCITS ETF", vwceGeoAllocation),
        ["EXSA"] = new("EXSA", AssetClass.ETF, "iShares Core MSCI Europe UCITS ETF", exsaGeoAllocation),
        ["IQQH"] = new("IQQH", AssetClass.ETF, "iShares MSCI World UCITS ETF", iqqhGeoAllocation),

        ["AAPL"] = new("AAPL", AssetClass.Stock, "Apple Inc.", applGeoAllocation),
        ["NESN"] = new("NESN", AssetClass.Stock, "Nestlé S.A.", nesnGeoAllocation),
        ["TM"] = new("TM", AssetClass.Stock, "Toyota Motor Corporation", tmGeoAllocation),
        ["SNE"] = new("SNE", AssetClass.Stock, "Sony Corporation", sonyGeoAllocation),
        ["MSFT"] = new("MSFT", AssetClass.Stock, "Microsoft Corporation", msftGeoAllocation),
    };

    public List<Asset> RetrieveAssetsMatchingPattern(string tickerRegex)
    {
        var matchingAssets = new List<Asset>();
        foreach (var asset in assetsBySearchableKey.Values)
        {
            if (Regex.IsMatch(asset.Ticker, tickerRegex, RegexOptions.IgnoreCase))
            {
                matchingAssets.Add(asset);
            }
        }
        return matchingAssets;
    }
}

