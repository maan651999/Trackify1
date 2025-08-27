using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trackify.Application.Interfaces
{
    public interface IReport
    {

        Task<(IEnumerable<(DateTime date, decimal protein)> protein,
           IEnumerable<(DateTime date, decimal calories)> calories)>
        GetWeeklyNutritionAsync(int userId, DateTime start);
    }
}
