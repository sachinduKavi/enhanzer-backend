namespace Enhanzer.Application.Service.PurchaseBill;

// Mirrors the Angular calculations (double maths, rounded half up to 2 decimals)
// so the saved totals always match what the user saw before saving.
public static class PurchaseBillCalculator
{
  public static decimal Margin(decimal standardCost, decimal standardPrice) =>
    Round((double)standardPrice - (double)standardCost);

  // (Standard Cost × Qty) less Discount %, e.g. 100 × 5 less 20% = 400.
  public static decimal TotalCost(decimal standardCost, decimal qty, decimal discount) =>
    Round((double)standardCost * (double)qty * (1 - (double)discount / 100));

  public static decimal TotalSelling(decimal standardPrice, decimal qty) =>
    Round((double)standardPrice * (double)qty);

  public static decimal Sum(IEnumerable<decimal> values) =>
    Round(values.Aggregate(0d, (sum, value) => sum + (double)value));

  private static decimal Round(double value) => (decimal)(Math.Floor(value * 100 + 0.5) / 100);
}
