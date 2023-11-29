using System.Collections.Generic;
using chainblock.Enumerations;

namespace chainblock.Models.Interfaces
{
    public interface ITransaction
    {
        int Id { get; set; }

        TransactionStatus Status { get; set; }

        string From { get; set; }

        string To { get; set; }

        decimal Amount { get; set; }
    }
}
