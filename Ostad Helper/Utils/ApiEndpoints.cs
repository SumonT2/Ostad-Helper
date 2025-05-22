namespace Ostad_Helper.Utils
{
    public static class ApiEndpoints
    {
        private const string BaseUrl = "https://api.ostad.app";

        public static string Batch => $"{BaseUrl}/api/v2/batch";

    public static string StudyPlan(string id) => $"{BaseUrl}/api/v2/batch/{id}";
    
        public static string StudyPlanDetails(string id) => $"{BaseUrl}/api/v2/study-plan/revised/{id}?criteria=all";
    }

}