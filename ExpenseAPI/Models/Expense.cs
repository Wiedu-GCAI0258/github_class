// 這個是用來代表一筆支出的 Entity
// 這個 Entity 會對應到資料庫中的一個 Table
// 用 Entity Framework Core 來建立資料庫中的 Table
// 這個 Entity 有幾個欄位，分別是 Id, Date, Description, Amount, CategoryId
// Id 是一個唯一的識別碼，Date 是支出的日期，Description 是支出的描述，Amount 是支出的金額，CategoryId 是支出的類別

namespace ExpenseAPI.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string? Category { get; set; }
    }
}