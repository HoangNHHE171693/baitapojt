namespace BaiTapOceanTech.Utility;


public class GenerateCode
{
    private static readonly Random random = new Random();
    public static string GenerateEmployeeCode()
    {
        int empRand = random.Next(10000000, 99999999);
        return "EMP" + empRand;
    }
}
