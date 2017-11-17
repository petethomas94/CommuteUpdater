namespace CommuteUpdater
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class DisruptionResponse
    {
        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }

        [JsonProperty("affectedRoutes")]
        public List<AffectedRoute> AffectedRoutes { get; set; }

        [JsonProperty("affectedStops")]
        public List<AffectedStop> AffectedStops { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("categoryDescription")]
        public string CategoryDescription { get; set; }

        [JsonProperty("closureText")]
        public string ClosureText { get; set; }

        [JsonProperty("created")]
        public string Created { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("lastUpdate")]
        public string LastUpdate { get; set; }

        [JsonProperty("summary")]
        public string Summary { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public partial class AffectedRoute
    {
        [JsonProperty("destinationName")]
        public string DestinationName { get; set; }

        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lineId")]
        public string LineId { get; set; }

        [JsonProperty("lineString")]
        public string LineString { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("originationName")]
        public string OriginationName { get; set; }

        [JsonProperty("routeCode")]
        public string RouteCode { get; set; }

        [JsonProperty("routeSectionNaptanEntrySequence")]
        public List<RouteSectionNaptanEntrySequence> RouteSectionNaptanEntrySequence { get; set; }
    }

    public partial class RouteSectionNaptanEntrySequence
    {
        [JsonProperty("ordinal")]
        public long Ordinal { get; set; }

        [JsonProperty("stopPoint")]
        public AffectedStop StopPoint { get; set; }
    }

    public partial class AffectedStop
    {
        [JsonProperty("accessibilitySummary")]
        public string AccessibilitySummary { get; set; }

        [JsonProperty("additionalProperties")]
        public List<AdditionalProperty> AdditionalProperties { get; set; }

        [JsonProperty("children")]
        public List<PurpleChild> Children { get; set; }

        [JsonProperty("childrenUrls")]
        public List<string> ChildrenUrls { get; set; }

        [JsonProperty("commonName")]
        public string CommonName { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("hubNaptanCode")]
        public string HubNaptanCode { get; set; }

        [JsonProperty("icsCode")]
        public string IcsCode { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("indicator")]
        public string Indicator { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lineGroup")]
        public List<LineGroup> LineGroup { get; set; }

        [JsonProperty("lineModeGroups")]
        public List<LineModeGroup> LineModeGroups { get; set; }

        [JsonProperty("lines")]
        public List<Line> Lines { get; set; }

        [JsonProperty("lon")]
        public long Lon { get; set; }

        [JsonProperty("modes")]
        public List<string> Modes { get; set; }

        [JsonProperty("naptanId")]
        public string NaptanId { get; set; }

        [JsonProperty("naptanMode")]
        public string NaptanMode { get; set; }

        [JsonProperty("placeType")]
        public string PlaceType { get; set; }

        [JsonProperty("platformName")]
        public string PlatformName { get; set; }

        [JsonProperty("smsCode")]
        public string SmsCode { get; set; }

        [JsonProperty("stationNaptan")]
        public string StationNaptan { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("stopLetter")]
        public string StopLetter { get; set; }

        [JsonProperty("stopType")]
        public string StopType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class Line
    {
        [JsonProperty("crowding")]
        public Crowding Crowding { get; set; }

        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }
    }

    public partial class Crowding
    {
        [JsonProperty("passengerFlows")]
        public List<PassengerFlow> PassengerFlows { get; set; }

        [JsonProperty("trainLoadings")]
        public List<TrainLoading> TrainLoadings { get; set; }
    }

    public partial class TrainLoading
    {
        [JsonProperty("direction")]
        public string Direction { get; set; }

        [JsonProperty("line")]
        public string Line { get; set; }

        [JsonProperty("lineDirection")]
        public string LineDirection { get; set; }

        [JsonProperty("naptanTo")]
        public string NaptanTo { get; set; }

        [JsonProperty("platformDirection")]
        public string PlatformDirection { get; set; }

        [JsonProperty("timeSlice")]
        public string TimeSlice { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class PassengerFlow
    {
        [JsonProperty("timeSlice")]
        public string TimeSlice { get; set; }

        [JsonProperty("value")]
        public long Value { get; set; }
    }

    public partial class LineModeGroup
    {
        [JsonProperty("lineIdentifier")]
        public List<string> LineIdentifier { get; set; }

        [JsonProperty("modeName")]
        public string ModeName { get; set; }
    }

    public partial class LineGroup
    {
        [JsonProperty("lineIdentifier")]
        public List<string> LineIdentifier { get; set; }

        [JsonProperty("naptanIdReference")]
        public string NaptanIdReference { get; set; }

        [JsonProperty("stationAtcoCode")]
        public string StationAtcoCode { get; set; }
    }

    public partial class PurpleChild
    {
        [JsonProperty("additionalProperties")]
        public List<AdditionalProperty> AdditionalProperties { get; set; }

        [JsonProperty("children")]
        public List<FluffyChild> Children { get; set; }

        [JsonProperty("childrenUrls")]
        public List<string> ChildrenUrls { get; set; }

        [JsonProperty("commonName")]
        public string CommonName { get; set; }

        [JsonProperty("distance")]
        public long Distance { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("lat")]
        public long Lat { get; set; }

        [JsonProperty("lon")]
        public long Lon { get; set; }

        [JsonProperty("placeType")]
        public string PlaceType { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public partial class FluffyChild
    {
    }

    public partial class AdditionalProperty
    {
        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("modified")]
        public string Modified { get; set; }

        [JsonProperty("sourceSystemKey")]
        public string SourceSystemKey { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }

    public partial class DisruptionResponse
    {
        public static List<DisruptionResponse> FromJson(string json) => JsonConvert.DeserializeObject<List<DisruptionResponse>>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this List<DisruptionResponse> self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
