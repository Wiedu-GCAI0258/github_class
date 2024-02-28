namespace ExpenseAPITest;

// 這是用來測試 ExpenseController 的測試類別
// 只需要測試 ＰＯＳＴ 方法即可
// 使用 AAA 模式
// 每一個方法至少提供3個測試案例，1個正向 1個反向 1個邊界

//準備 ef core in memory db
//準備 ExpenseContext

using ExpenseAPI.Models; // Add the missing using directive

private readonly ExpenseContext _context;

public class ExpenseControllerTest
{
    [Fact]
    public void Test1()
    {

    }
}