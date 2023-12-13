public class PositionView
{
    public Asset Asset { get; set; }
    public string Ticker { get; set; }
    public string AssetClass { get; set; }
    public string Description { get; set; }
    public decimal WeightInPortfolio { get; set; }
    public string WeightInPortfolioStr { get; set; }
}