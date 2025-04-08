namespace gradtest.Controllers
{
    public class Content
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string? Title { get; set; }
        public int Type { get; set; }
        public string? Thumbnail { get; set; }
        public byte Category { get; set; }
        //({blog},NULL,1,NULL,{count})
    }
}
