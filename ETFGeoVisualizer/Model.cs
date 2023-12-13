public enum AssetClass { Stock, ETF };
public class GeoWeight
{
    public GeoWeight(string area, decimal percentage)
    {
        Area = area;
        Percentage = percentage;
    }

    public string Area { get; set; }
    public decimal Percentage { get; set; }
}
public class Asset
{
    public Asset(string ticker, AssetClass assetClass, string description, List<GeoWeight> geoAllocation)
    {
        Ticker = ticker;
        AssetClass = assetClass;
        Description = description;
        GeoAllocation = geoAllocation;
    }

    public string Ticker { get; set; }
    public AssetClass AssetClass { get; set; }
    public string Description { get; set; }
    public List<GeoWeight> GeoAllocation { get; set; }
}

public class Position
{
    public Position(Asset asset, decimal weightInPortfolio)
    {
        Asset = asset;
        WeightInPortfolio = weightInPortfolio;
    }

    public Asset Asset { get; set; }
    public decimal WeightInPortfolio { get; set; }
}
