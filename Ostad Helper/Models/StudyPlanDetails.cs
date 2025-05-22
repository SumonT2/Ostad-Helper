namespace Ostad_Helper.Models
{

    public partial class StudyPlanDetailsRoot
    {
        public long code { get; set; }
        public string status { get; set; }
        public string msg { get; set; }
        public StudyPlanDetailsData data { get; set; }
    }

    public partial class StudyPlanDetailsData
    {
        public string updated_by { get; set; }
        public string description { get; set; }
        public bool is_week { get; set; }
        public object[] resources { get; set; }
        public object[] assignments { get; set; }
        public object[] exams { get; set; }
        public object[] lives { get; set; }
        public object[] live_premiums { get; set; }
        public StudyPlanDetailsVod[] vods { get; set; }
        public object date { get; set; }
        public bool is_module { get; set; }
        public DateTimeOffset start_date { get; set; }
        public DateTimeOffset end_date { get; set; }
        public object module_color { get; set; }
        public object instructions { get; set; }
        public object vods_date_from { get; set; }
        public object vods_date_to { get; set; }
        public object vods_title { get; set; }
        public object vods_description { get; set; }
        public bool is_holiday { get; set; }
        public string button_text { get; set; }
        public bool is_free { get; set; }
        public bool is_on_demand { get; set; }
        public string module_type { get; set; }
        public bool is_published { get; set; }
        public bool is_ai_boosted { get; set; }
        public string _id { get; set; }
        public StudyPlanDetailsBatch batch { get; set; }
        public string title { get; set; }
        public long day_no { get; set; }
        public string extra_description { get; set; }
        public string added_by { get; set; }
        public object course { get; set; }
        public long idx { get; set; }
        public Dictionary<string, long> count { get; set; }
        public StudyPlanDetailsProgressItems progress_items { get; set; }
        public StudyPlanDetailsTimeline[] timeline { get; set; }
        public string progress_status { get; set; }
    }

    public partial class StudyPlanDetailsBatch
    {
        public bool is_on_demand { get; set; }
        public string _id { get; set; }
        public StudyPlanDetailsCourseSnapshot course_snapshot { get; set; }
    }

    public partial class StudyPlanDetailsCourseSnapshot
    {
        public string title { get; set; }
    }

    public partial class StudyPlanDetailsProgressItems
    {
        public bool project { get; set; }
        public bool quiz { get; set; }
        public bool live_premium_main { get; set; }
    }

    public partial class StudyPlanDetailsTimeline
    {
        public StudyPlanDetailsButtonText button_text { get; set; }
        public string[] tutors { get; set; }
        public string live_logo { get; set; }
        public object photo_url { get; set; }
        public object course { get; set; }
        public object level_submission { get; set; }
        public string updated_by { get; set; }
        public string study_plan { get; set; }
        public object free_course { get; set; }
        public string batch { get; set; }
        public object meeting_uuid { get; set; }
        public string platform { get; set; }
        public string type { get; set; }
        public string live_class_type { get; set; }
        public string custom_name { get; set; }
        public string live_status { get; set; }
        public string[] recordings { get; set; }
        public bool? is_published { get; set; }
        public bool? is_expired { get; set; }
        public DateTimeOffset? start_date_time { get; set; }
        public long? duration { get; set; }
        public bool? is_orientation { get; set; }
        public object[] topics { get; set; }
        public string _id { get; set; }
        public string description { get; set; }
        public string title { get; set; }
        public string added_by { get; set; }
        public long idx { get; set; }
        public string item_type { get; set; }
        public DateTimeOffset sort_date { get; set; }
        public bool? is_attendance_counted { get; set; }
        public bool? has_attendance { get; set; }
        public string format_type { get; set; }
        public object[] playlists { get; set; }
        public bool? is_final_assessment { get; set; }
        public DateTimeOffset? submission_start_date { get; set; }
        public DateTimeOffset? last_submission_date { get; set; }
        public object[] content { get; set; }
        public string instructions { get; set; }
        public object settings { get; set; }
        public bool? is_coding_test { get; set; }
        public bool? judge_with_ai { get; set; }
        public bool? is_judgeable { get; set; }
        public object[] sections { get; set; }
        public long? score_portion { get; set; }
        public bool? grace_period_over { get; set; }
        public long? submission_deduction { get; set; }
        public string submission_id { get; set; }
        public long? submission_status { get; set; }
      //  public long? submission_marks { get; set; }
        public bool? has_completed { get; set; }
        public bool? is_late_submission { get; set; }
    }

    public partial class StudyPlanDetailsButtonText
    {
        public string en { get; set; }
        public string bn { get; set; }
    }

    public partial class StudyPlanDetailsVod
    {
        public string title { get; set; }
        public object vod_type { get; set; }
        public object section { get; set; }
        public string _id { get; set; }
        public long idx { get; set; }
    }
}
