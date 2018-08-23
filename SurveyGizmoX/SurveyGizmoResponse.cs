// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using SurveyGizmoX.Parser;
//
//    var surveyGizmoResponse = SurveyGizmoResponse.FromJson(jsonString);

namespace SurveyGizmoX.Parser
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class SurveyGizmoResponse
    {
        [JsonProperty("is_test_data")]
        public bool IsTestData { get; set; }

        [JsonProperty("session_id")]
        public string SessionId { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("date_started")]
        public string DateStarted { get; set; }

        [JsonProperty("link_id")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LinkId { get; set; }

        [JsonProperty("url_variables")]
        [JsonConverter(typeof(UrlVariablesConverter))]
        public Dictionary<string, UrlVariable> UrlVariables { get; set; }

        [JsonProperty("ip_address")]
        public string IpAddress { get; set; }

        [JsonProperty("referer")]
        public string Referer { get; set; }

        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        [JsonProperty("response_time")]
        public long ResponseTime { get; set; }

        //[JsonProperty("data_quality")]
        //public object[] DataQuality { get; set; }

        [JsonProperty("survey_data")]
        public Dictionary<string, SurveyDatum> SurveyData { get; set; }
    }

    public partial class SurveyDatum
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("question")]
        public string Question { get; set; }

        [JsonProperty("section_id")]
        public long SectionId { get; set; }

        [JsonProperty("shown")]
        public bool Shown { get; set; }

        [JsonProperty("answer", NullValueHandling = NullValueHandling.Ignore)]
        public string Answer { get; set; }

        [JsonProperty("answer_id", NullValueHandling = NullValueHandling.Ignore)]
        public long? AnswerId { get; set; }
    }

    public partial class UrlVariable
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class SurveyGizmoResponse
    {
        public static SurveyGizmoResponse FromJson(string json) => JsonConvert.DeserializeObject<SurveyGizmoResponse>(json, SurveyGizmoX.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this SurveyGizmoResponse self) => JsonConvert.SerializeObject(self, SurveyGizmoX.Converter.Settings);
    }
}
