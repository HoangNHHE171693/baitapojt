﻿using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO;

public class CertificateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CertificateD Status { get; set; }
    public int IdTinh { get; set; }
}
