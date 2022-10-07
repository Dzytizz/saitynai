namespace saitynai_server.Entities
{
    public partial class Advertisement
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string Description { get; set; } = null!;
        public int Condition { get; set; }
        public decimal Price { get; set; }
        public string Photos { get; set; } = null!;
        public int? ExchangeTo { get; set; }
        public int FkGameId { get; set; }
        public int FkClientId { get; set; }
    }
}
