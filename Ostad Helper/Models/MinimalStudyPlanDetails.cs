namespace Ostad_Helper.Models
{
    namespace Ostad_Helper.Models
    {
        public class MinimalStudyPlanRoot
        {
            public long code { get; set; }
            public string status { get; set; }
            public string msg { get; set; }
            public MinimalStudyPlanData data { get; set; }
        }

        public class MinimalStudyPlanData
        {
            public MinimalStudyPlan[] study_plans { get; set; }
        }

        public class MinimalStudyPlan
        {
            public string _id { get; set; }
            public string title { get; set; }
        }
    }

}
