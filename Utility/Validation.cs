using BaiTapOceanTech.DB;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BaiTapOceanTech.Utility;

public class Validation<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public Validation(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<string> CheckAndUpdateAPIAsync(T entity, string currentValue, string newValue, Expression<Func<T, bool>> predicate)
    {
        if (!string.IsNullOrEmpty(newValue) && newValue != "string" && newValue != currentValue)
        {
            bool exist = await _context.Set<T>().AnyAsync(predicate);
            if (exist)
            {
                throw new Exception($"Giá trị {newValue} đã tồn tại!");
            }
            return newValue;
        }
        return currentValue;
    }

    public async Task<DateTime> CheckAndUpdateDateAsync(T entity, DateTime oldValue, DateTime? newValue, DateTime? otherDate, bool isStartDate)
    {
        if (newValue.HasValue && newValue.Value != oldValue)
        {
            if (isStartDate && otherDate.HasValue && newValue.Value > otherDate.Value)
            {
                throw new Exception("Ngày tạo không thể diễn ra sau ngày hết hạn.");
            }
            if (!isStartDate && otherDate.HasValue && newValue.Value < otherDate.Value)
            {
                throw new Exception("Ngày hết hạn không thể diễn ra trước ngày tạo.");
            }
            return newValue.Value;
        }
        return oldValue;
    }

    public async Task<DateTime> CheckAndUpdateDate2Async(T entity, DateTime oldValue, DateTime? newValue)
    {

        if (newValue.HasValue && newValue != oldValue)
        {
            return newValue.Value;
        }
        return oldValue;
    }

    public async Task<int> CheckAndUpdateQuantityAsync<T>(T entity, int currentValue, int newValue, Func<T, bool> predicate)
    {
        if (predicate(entity))
        {
            return newValue;
        }
        return currentValue;
    }

    public async Task<string> CheckAndUpdateAPI2Async(T entity, string currentValue, string newValue, Expression<Func<T, bool>> predicate)
    {
        if (!string.IsNullOrEmpty(newValue) && newValue != "string" && newValue != currentValue)
        {
            bool exist = await _context.Set<T>().AnyAsync(predicate);
            if (exist)
            {
                throw new Exception($"Giá trị {newValue} đã tồn tại!");
            }
            return newValue;
        }
        return currentValue;
    }
    

}
