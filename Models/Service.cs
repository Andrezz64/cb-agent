using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace cb_agent;

public partial class Service
{
    public int Service_id { get; set; }

    public string Name { get; set; } = null!;

    public string Exe_path { get; set; } = null!;

    public string Params { get; set; } = null!;
    public string? Status { get; set; }
    public int Auto_start {get; set;}
}
