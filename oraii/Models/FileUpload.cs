using System;
using System.Collections.Generic;

namespace oraii.Models;

public partial class FileUpload
{
    public int Id { get; set; }

    public byte[] FileData { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string ContentType { get; set; } = null!;
}
