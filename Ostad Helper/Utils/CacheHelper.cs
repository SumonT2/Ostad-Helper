using Newtonsoft.Json;
using Ostad_Helper.Models;

namespace Ostad_Helper.Utils
{
    public class StudyPlanCacheHelper
    {
        private static readonly string CacheFilePath = Path.Combine("App_Data", "studyplan_cache.json");

        public static async Task<CachedStudyPlanList> LoadCacheAsync()
        {
            if (!File.Exists(CacheFilePath))
                return new CachedStudyPlanList();

            var json = await File.ReadAllTextAsync(CacheFilePath);
            return JsonConvert.DeserializeObject<CachedStudyPlanList>(json)
                   ?? new CachedStudyPlanList();
        }

        public static async Task SaveCacheAsync(CachedStudyPlanList cache)
        {
            Directory.CreateDirectory(Path.GetDirectoryName(CacheFilePath)!);
            var json = JsonConvert.SerializeObject(cache, Formatting.Indented);
            await File.WriteAllTextAsync(CacheFilePath, json);
        }
    }
}