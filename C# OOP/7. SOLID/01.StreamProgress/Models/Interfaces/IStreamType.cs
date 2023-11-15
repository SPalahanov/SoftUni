using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamProgress.Models.Interfaces
{
    public interface IStreamType
    {
        public int Length { get; }

        public int BytesSent { get; }
    }
}
