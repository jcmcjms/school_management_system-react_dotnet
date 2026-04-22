namespace Domain.Enums;

public enum MenuCategory
{
    Breakfast,
    Lunch,
    Snacks,
    Dinner,
    Beverages
}

public enum MealType
{
    Breakfast,
    Lunch,
    Snacks,
    Dinner
}

public enum DietaryTagType
{
    Allergen,
    Preference,
    Restriction
}

public enum OrderType
{
    PreOrder,
    WalkIn
}

public enum OrderStatus
{
    Pending,
    Paid,
    Confirmed,
    Preparing,
    Ready,
    Served,
    Cancelled,
    Refunded
}

public enum TransactionType
{
    Credit,
    Debit
}

public enum TransactionSource
{
    Cash,
    Online,
    SalaryDeduction,
    Refund,
    Transfer
}

public enum InventoryTransactionType
{
    In,
    Out,
    Adjustment,
    Waste
}

public enum PurchaseOrderStatus
{
    Draft,
    Sent,
    PartiallyReceived,
    Received,
    Cancelled
}