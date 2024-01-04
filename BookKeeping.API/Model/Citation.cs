namespace BookKeeping.API.Model
{
    public class Citation
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public string SourceTitle { get; set; }
        public int StartPageNo { get; set; }
        public int EndPageNo { get; set; }
        public int VolumeNo { get; set; }
        public string URL { get; set; }
    }
}
