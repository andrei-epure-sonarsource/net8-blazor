public enum AssetClass { Stock, ETF };
public record GeoWeight(string Area, decimal percentage);
public record Asset(string Ticker, AssetClass AssetClass, string Description, List<GeoWeight> GeoAllocation);
public record Position(Asset Asset, decimal WeightInPortfolio);
