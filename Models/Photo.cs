using System.ComponentModel.DataAnnotations;

namespace AD_Asignment_GroupD_T2207E.Models
{
    public class Photo
    {
        [Key]
        public string Id { get; set; }
        public string Thumbnail { get; set; }
        public string Camera { get; set; }
        public int Views { get; set; }
        public int Downloads { get; set; }
        public int Likes { get; set; }
        public DateTime Publish { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Extension { get; set; }
        public string UserId { get; set; }

    }
}