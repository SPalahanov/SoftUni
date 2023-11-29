using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using chainblock.Enumerations;
using chainblock.Exceptions;
using chainblock.Models.Interfaces;

namespace chainblock.Models
{
    public class Transaction : ITransaction
    {
        private int id;
        private string from;
        private string to;
        private decimal amount;
        
        public Transaction(int id, TransactionStatus status, string from, string to, decimal amout)
        {
            this.Id = id;
            this.Status = status;
            this.From = from;
            this.To = to;
            this.Amount = amout;
        }

        public int Id 
        {
            get => id;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(TransactionExceptionMessage.IdNotPositiveNumber);
                }

                id = value;
            }
        }

        public TransactionStatus Status { get; set; }

        public string From 
        {
            get => from;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptionMessage.FromNullOrWhiteSpace);
                }

                from = value;
            }
        }

        public string To 
        {
            get => to;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(TransactionExceptionMessage.ToNullOrWhiteSpace);
                }

                to = value;
            }
        }

        public decimal Amount 
        {
            get => amount;
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(TransactionExceptionMessage.AmountNotPositiveNUmber);
                }

                amount = value;
            }
        }
    }
}
