namespace AD_Asignment_GroupD_T2207E.Models
{
	public class PhotoTag
	{
		public string PhotoId { get; set; } = string.Empty;
		public virtual Photo? Photo { get; set; }
		public string TagId { get; set; } = string.Empty;
		public Tag? Tag { get; set; }
	}
}
