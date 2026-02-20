using System;
using System.Collections.Generic;

namespace oraii.Models;

public partial class File
{
    public int Id { get; set; }

    public byte[] FileData { get; set; } = null!;

    public string FilName { get; set; } = null!;

    public string ContentType { get; set; } = null!;
}
