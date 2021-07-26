namespace Models
{
    public class Package
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public int ParentId { set; get; }
        public bool IsIncome { set; get; }
        public string AccountId { set; get; }
        public string WalletId { set; get; }
    }
}
