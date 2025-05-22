namespace Ostad_Helper.Models
{
    public class CachedStudyPlanInfo
    {
        public string BatchId { get; set; }
        public List<string> StudyPlanIds { get; set; }
    }

    public class CachedStudyPlanList
    {
        public List<CachedStudyPlanInfo> Items { get; set; } = new();
    }

}
