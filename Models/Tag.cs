namespace AD_Asignment_GroupD_T2207E.Models
{
    public class Tag
    {
        public string Id { get; set; } = string.Empty;
        public string TagName { get; set; } = string.Empty;
        public int Searchs { get; set; }
        public ICollection<PhotoTag>? PhotoTags { get; set; }
    }
}
