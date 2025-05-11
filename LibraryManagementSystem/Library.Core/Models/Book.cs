namespace Library.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Quantity { get; set; }
        public DateTime LastBorrowedDate { get; set; }
        public BorrowInfo? BorrowDetails { get; set; }

    }

    public class BorrowInfo
    {
        public DateTime BorrowDate { get; set; }
        public bool IsReturned { get; set; } = false;
        public double LateFee { get; set; } = 0;
    }
}
