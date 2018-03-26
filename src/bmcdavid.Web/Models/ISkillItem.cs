namespace bmcdavid.Web.Models
{
    public interface ISkillItem
    {
        string Name { get; }

        string Link { get; }

        string Description { get; }

        string Image { get; }

        SkillLevel SkillLevel { get; }
    }

    public enum SkillLevel
    {
        Expert,
        Proficient,
        Beginner
    }
}
