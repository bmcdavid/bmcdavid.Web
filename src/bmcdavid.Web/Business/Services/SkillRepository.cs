using bmcdavid.Web.Models;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.IO;

namespace bmcdavid.Web.Business.Services
{
    public class SkillRepository
    {
        private const string SkillPath = "Data\\skills.json";
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly List<ISkillItem> _skills;

        public SkillRepository(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _skills = new List<ISkillItem>();
        }

        public virtual ICollection<ISkillItem> GetSkills()
        {
            if (_skills.Count > 0) return _skills;
            var dataInfo = _hostingEnvironment.ContentRootFileProvider.GetFileInfo(SkillPath);
            if (!dataInfo.Exists) throw new System.Exception("Unable to read skills");

            var dataString = File.ReadAllText(dataInfo.PhysicalPath);
            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SkillItem>>(dataString);
            _skills.AddRange(data);

            return _skills;
        }
    }
}
