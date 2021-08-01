namespace Models
{
    public class Package
    {
        public string Id { set; get; }
        public string Name { set; get; }
        public string Icon { set; get; }
        public string ParentId { set; get; }
        public bool IsIncome { set; get; }
        public string AccountId { set; get; }
        public string WalletId { set; get; }
    }
}
