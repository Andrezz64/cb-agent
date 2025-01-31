using System;
using System.Collections.Generic;

namespace cb_agent;

public partial class Config
{
    public int ConfigId { get; set; }

    public int FirstRun { get; set; }

    public string AdminServer { get; set; } = null!;

    public string ApiKey { get; set; } = null!;
}
