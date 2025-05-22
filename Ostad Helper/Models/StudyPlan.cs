namespace Ostad_Helper.Models
{
    public partial class StudyPlanRoot
    {
        public long code { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
        public StudyPlanData data { get; set; }
    }

    public partial class StudyPlanData
    {
        public StudyPlanCountLive count_live_breakdown { get; set; }
        public StudyPlanCountExamBreakdown count_exam_breakdown { get; set; }
        public StudyPlanCountLive count_live_recordings { get; set; }
        public StudyPlanAiProperty ai_property { get; set; }
        public StudyPlan[] study_plans { get; set; }
        public StudyPlanTutor[] tutors { get; set; }
        public object[] support_tutors { get; set; }
        public object[] optional_head_tutors { get; set; }
        public object end_date { get; set; }
        public string batch_code { get; set; }
        public object assigned_to { get; set; }
        public string status { get; set; }
        public long venue { get; set; }
        public long count_resource { get; set; }
        public long count_live { get; set; }
        public long count_live_premium { get; set; }
        public long count_assignment { get; set; }
        public long count_project { get; set; }
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
        public StudyPlanSupportInfo[] support_info { get; set; }
        public bool has_report_card { get; set; }
        public object piku_inbox_id { get; set; }
        public object piku_website_token { get; set; }
        public bool enable_piku { get; set; }
        public object skill_map { get; set; }
        public object friend_batch { get; set; }
        public bool enable_live_recording_copy { get; set; }
        public string _id { get; set; }
        public long batch_no { get; set; }
        public StudyPlanSchedule schedule { get; set; }
        public DateTimeOffset schedule_date { get; set; }
        public long schedule_type { get; set; }
        public StudyPlanCourse course { get; set; }
        public StudyPlanCourseSnapshot course_snapshot { get; set; }
        public long max_capacity { get; set; }
        public StudyPlanClassRoutine[] class_routine { get; set; }
        public long idx { get; set; }
        public object[] report_recommendations { get; set; }
        public StudyPlanNextSupport next_support { get; set; }
        public long count_playlist_recording { get; set; }
    }

    public partial class StudyPlanAiProperty
    {
        public object designation { get; set; }
        public object prompt_file { get; set; }
        public string engine { get; set; }
    }

    public partial class StudyPlanClassRoutine
    {
        public DateTimeOffset[] days_and_times { get; set; }
        public string title { get; set; }
    }

    public partial class StudyPlanCountExamBreakdown
    {
        public long quiz { get; set; }
        public long written { get; set; }
        public long live_coding_test { get; set; }
        public long practice_coding_test { get; set; }
    }

    public partial class StudyPlanCountLive
    {
        public long main { get; set; }
        public long concept { get; set; }
        public long support { get; set; }
        public long custom { get; set; }
    }

    public partial class StudyPlanCourse
    {
        public string title { get; set; }
        public long rating_sum { get; set; }
        public long rating_count { get; set; }
        public string _id { get; set; }
    }

    public partial class StudyPlanCourseSnapshot
    {
        public string title { get; set; }
        public string description { get; set; }
        public string tagline { get; set; }
        public StudyPlanDuration duration { get; set; }
        public string requirements { get; set; }
        public object live_price { get; set; }
        public object live_price_real { get; set; }
        public long live_plus_price { get; set; }
        public long live_plus_price_real { get; set; }
        public string photo_url { get; set; }
        public string thumb_url { get; set; }
        public string slug { get; set; }
        public string course_kind { get; set; }
        public string pricing_type { get; set; }
    }

    public partial class StudyPlanDuration
    {
        public string unit { get; set; }
        public long count { get; set; }
    }

    public partial class StudyPlanNextSupport
    {
        public StudyPlanButtonTextClass button_text { get; set; }
        public object live_logo { get; set; }
        public object course { get; set; }
        public object level_submission { get; set; }
        public string study_plan { get; set; }
        public object free_course { get; set; }
        public string batch { get; set; }
        public object meeting_uuid { get; set; }
        public string platform { get; set; }
        public string live_class_type { get; set; }
        public object custom_name { get; set; }
        public string live_status { get; set; }
        public bool is_published { get; set; }
        public bool is_expired { get; set; }
        public DateTimeOffset start_date_time { get; set; }
        public long duration { get; set; }
        public long count_watching { get; set; }
        public object[] topics { get; set; }
        public object weight { get; set; }
        public long count_orientation_booked { get; set; }
        public string _id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset updatedAt { get; set; }
        public long idx { get; set; }
        public long __v { get; set; }
    }

    public partial class StudyPlanButtonTextClass
    {
        public string en { get; set; }
        public string bn { get; set; }
    }

    public partial class StudyPlanSchedule
    {
        public long avg_class_duration { get; set; }
        public long count_purchase { get; set; }
        public object[] weekends { get; set; }
        public string[] class_days { get; set; }
        public string _id { get; set; }
        public string course { get; set; }
        public DateTimeOffset date { get; set; }
        public long type { get; set; }
        public StudyPlanMisc misc { get; set; }
        public object[] special_timings { get; set; }
        public DateTimeOffset createdAt { get; set; }
        public DateTimeOffset updatedAt { get; set; }
        public long idx { get; set; }
        public long __v { get; set; }
    }

    public partial class StudyPlanMisc
    {
        public string title { get; set; }
        public StudyPlanTiming[] timing { get; set; }
        public string desc { get; set; }
    }

    public partial class StudyPlanTiming
    {
        public string start_time { get; set; }
        public long duration { get; set; }
        public string[] days { get; set; }
        public string topic { get; set; }
    }

    public partial class StudyPlan
    {
        public string updated_by { get; set; }
        public string description { get; set; }
        public bool is_week { get; set; }
        public string[] resources { get; set; }
        public string[] assignments { get; set; }
        public string[] exams { get; set; }
        public object[] lives { get; set; }
        public StudyPlanLivePremium[] live_premiums { get; set; }
        public string[] vods { get; set; }
        public object date { get; set; }
        public bool is_module { get; set; }
        public DateTimeOffset start_date { get; set; }
        public DateTimeOffset end_date { get; set; }
        public object module_color { get; set; }
        public string instructions { get; set; }
        public DateTimeOffset? vods_date_from { get; set; }
        public DateTimeOffset? vods_date_to { get; set; }
        public string vods_title { get; set; }
        public string vods_description { get; set; }
        public bool is_holiday { get; set; }
        public string button_text { get; set; }
        public bool is_free { get; set; }
        public bool is_on_demand { get; set; }
        public string module_type { get; set; }
        public bool is_published { get; set; }
        public bool is_ai_boosted { get; set; }
        public string _id { get; set; }
        public object course { get; set; }
        public string title { get; set; }
        public long day_no { get; set; }
        public string subtitle { get; set; }
        public string extra_description { get; set; }
        public string added_by { get; set; }
        public string batch { get; set; }
        public long idx { get; set; }
        public Dictionary<string, long> count { get; set; }
        public string progress_status { get; set; }
        public bool is_reviewed { get; set; }
    }

    public partial class StudyPlanLivePremium
    {
        public string live_class_type { get; set; }
        public string live_status { get; set; }
        public string[] recordings { get; set; }
        public DateTimeOffset start_date_time { get; set; }
        public long duration { get; set; }
        public string _id { get; set; }
        public long idx { get; set; }
    }

    public partial class StudyPlanSupportInfo
    {
        public string title { get; set; }
        public DateTimeOffset start_time { get; set; }
        public DateTimeOffset end_time { get; set; }
        public string wa_number { get; set; }
        public string phone_number { get; set; }
    }

    public partial class StudyPlanTutor
    {
        public string name { get; set; }
        public string photo_url { get; set; }
        public string signature_url { get; set; }
        public string _id { get; set; }
    }

}