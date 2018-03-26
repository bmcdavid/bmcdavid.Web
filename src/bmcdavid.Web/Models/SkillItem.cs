namespace bmcdavid.Web.Models
{
    public class SkillItem : ISkillItem
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public SkillLevel SkillLevel { get; set; }
    }
}
