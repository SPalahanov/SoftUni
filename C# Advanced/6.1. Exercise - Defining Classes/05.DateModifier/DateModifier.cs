using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int GetDifferenceInDays(string start, string end)
        {

            DateTime startDate = DateTime.Parse(start);
            DateTime endDate = DateTime.Parse(end);

            var result = endDate - startDate;

            return Math.Abs(result.Days);
        }
    }
}