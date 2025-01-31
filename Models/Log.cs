using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace cb_agent;

public partial class Log
{
    [JsonIgnore]
    public int Log_id { get; set; }

    public int ProgramId { get; set; }

    public string? Level { get; set; }

    public string? Title { get; set; }

    public string? Mensage { get; set; }
    public DateTime Date { get; set; }
}
