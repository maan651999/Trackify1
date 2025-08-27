using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.Interfaces
{
    public interface INutritionRepository
    {
        Task<(decimal protein, decimal carbs, decimal fats, decimal calories)>
         GetDailyTotalsAsync(int userId, DateTime date);
    }
}
