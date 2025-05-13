namespace Ostad_Helper.Models
{

    public class BatchRoot
    {
        public long code { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
        public BatchData data { get; set; }
    }

    public class BatchData
    {
        public object first_page { get; set; }
        public object previous { get; set; }
        public object next { get; set; }
        public object last_page { get; set; }
        public long size { get; set; }
        public BatchResult[] results { get; set; }
        public long total { get; set; }
    }

    public class BatchResult
    {
        public string _id { get; set; }
        public BatchCountLive count_live_breakdown { get; set; }
        public BatchCountExamBreakdown count_exam_breakdown { get; set; }
        public BatchCountLive count_live_recordings { get; set; }
        public BatchAiProperty ai_property { get; set; }
        public object[] support_tutors { get; set; }
        public object[] optional_head_tutors { get; set; }
        public object end_date { get; set; }
        public string batch_code { get; set; }
        public object assigned_to { get; set; }
        public string status { get; set; }
        public object rank { get; set; }
        public long venue { get; set; }
        public long count_resource { get; set; }
        public long count_live { get; set; }
        public long count_live_premium { get; set; }
        public long count_assignment { get; set; }
        public long? count_project { get; set; }
        public long count_exam { get; set; }
        public long count_vod { get; set; }
        public object[] weekends { get; set; }
        public string[] class_days { get; set; }
        public string course_kind { get; set; }
        public bool completion_cert_for_all { get; set; }
        public bool batch_finish_image_provided { get; set; }
        public bool is_module { get; set; }
        public Uri whatsapp_group_url { get; set; }
        public Uri fb_group_url { get; set; }
        public object discord_group_url { get; set; }
        public object[] playlists { get; set; }
        public bool has_pro_batch { get; set; }
        public bool is_pro_batch { get; set; }
        public object playground_id { get; set; }
        public object welcome_text { get; set; }
        public bool is_on_demand { get; set; }
        public object is_bundle { get; set; }
        public object tag { get; set; }
        public object batch_code_ref { get; set; }
        public bool is_published { get; set; }
        public object[] topics { get; set; }
        public BatchSupportInfo[] support_info { get; set; }
        public bool? has_report_card { get; set; }
        public long? piku_inbox_id { get; set; }
        public string piku_website_token { get; set; }
        public bool? enable_piku { get; set; }
        public BatchSkillMap skill_map { get; set; }
        public object friend_batch { get; set; }
        public bool? enable_live_recording_copy { get; set; }
        public long batch_no { get; set; }
        public string schedule { get; set; }
        public DateTimeOffset schedule_date { get; set; }
        public long schedule_type { get; set; }
        public string course { get; set; }
        public BatchCourseSnapshot course_snapshot { get; set; }
        public long max_capacity { get; set; }
        public BatchClassRoutine[] class_routine { get; set; }
        public object[] report_recommendations { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset updatedAt { get; set; }
        public long idx { get; set; }
        public long __v { get; set; }
        public long count_modules { get; set; }
        public long count_learners { get; set; }
        public long count_days { get; set; }
        public string head_tutor { get; set; }
        public BatchSkillMap skillMap { get; set; }
        public string cert_title_text { get; set; }
    }

    public class BatchAiProperty
    {
        public object designation { get; set; }
        public object prompt_file { get; set; }
        public string engine { get; set; }
    }

    public class BatchClassRoutine
    {
        public DateTimeOffset[] days_and_times { get; set; }
        public string title { get; set; }
    }

    public class BatchCountExamBreakdown
    {
        public long quiz { get; set; }
        public long written { get; set; }
        public long practice_coding_test { get; set; }
        public long live_coding_test { get; set; }
    }

    public class BatchCountLive
    {
        public long main { get; set; }
        public long concept { get; set; }
        public long support { get; set; }
        public long custom { get; set; }
    }

    public class BatchCourseSnapshot
    {
        public string title { get; set; }
        public BatchDuration duration { get; set; }
        public long? live_price { get; set; }
        public long? live_price_real { get; set; }
        public long live_plus_price { get; set; }
        public long? live_plus_price_real { get; set; }
        public string photo_url { get; set; }
        public string thumb_url { get; set; }
        public string slug { get; set; }
        public string course_kind { get; set; }
        public string pricing_type { get; set; }
    }

    public class BatchDuration
    {
        public string unit { get; set; }
        public long count { get; set; }
    }

    public class BatchSkillMap
    {
    }

    public class BatchSupportInfo
    {
        public string title { get; set; }
        public DateTimeOffset start_time { get; set; }
        public DateTimeOffset end_time { get; set; }
        public string wa_number { get; set; }
        public string phone_number { get; set; }
    }
}
