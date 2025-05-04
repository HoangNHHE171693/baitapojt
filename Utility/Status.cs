namespace BaiTapOceanTech.Utility;

public static class Status
{
    public enum Statuss
    {
        Active = 0, Inactive = 1,
        Pending_Approval = 2,
        Suspended = 3
    }

    public enum CertificateD
    {
        Active = 0, Expired = 1,
        
    }
    public enum EmployeeD
    {
        Alive = 0, Death = 1
    }

    public enum Ethnic
    {
        Kinh = 0, Tay = 1, Thai = 2, Muong = 3, Khmer = 4
    }
    public enum Job
    {
        GiaoVien = 0, BacSi = 1, KySu = 2, CongNhan = 3, LapTrinhVien = 4
    }
}
