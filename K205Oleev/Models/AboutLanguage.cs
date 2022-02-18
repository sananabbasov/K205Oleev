namespace K205Oleev.Models
{
    public class AboutLanguage : Base
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string LangCode { get; set; }
        public int AboutID { get; set; }
        public virtual About About { get; set; }
    }
}
