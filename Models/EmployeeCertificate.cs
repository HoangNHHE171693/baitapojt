﻿using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models;

public class EmployeeCertificate
{
    public int Id { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public CertificateD Status { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }  
    public int CertificateId { get; set; }
    public virtual Certificate Certificate { get; set; }

}
