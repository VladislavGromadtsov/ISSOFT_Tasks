using System;
using Newtonsoft.Json;

namespace Task3
{
    public struct Vacation
    {
        [JsonProperty("start")]
        public DateTime Start { get; }
        [JsonProperty("end")]
        public DateTime End { get; }

        public Vacation(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }

        public bool IsInSecondHalfOf2016() => Start > new DateTime(2016, 6, 30) && End <= new DateTime(2016, 12, 31);

        public override string ToString() => $"{Start} : {End}";
    } 
}