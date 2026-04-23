namespace Application.DTOs.Cashier;

public class DailySummaryDto
{
    public DateTime Date { get; set; }
    public int TotalOrders { get; set; }
    public decimal TotalRevenue { get; set; }
    public decimal TotalCashPayments { get; set; }
    public decimal TotalWalletPayments { get; set; }
    public decimal TotalRefunds { get; set; }
    public int WalkInOrders { get; set; }
    public int PreOrders { get; set; }
    public decimal OpeningCash { get; set; }
    public decimal ClosingCash { get; set; }
}