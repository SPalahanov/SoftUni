using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.ForU.Core.Enums;
using Log.ForU.Core.Exceptions;
using Log.ForU.Core.Utils;

namespace Log.ForU.Core.Models
{
    public class Message
    {
        private string createdTime;
        private string text;

        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        public string CreatedTime
        {
            get => createdTime;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyCreatedTimeException();
                }

                //if (!DateTimeValidator.ValidateDateTimeFormat(value))
                //{
                //    throw new InvalidDateTimeFormatException();
                //}

                createdTime = value;
            }
        }

        public string Text
        {
            get => text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new EmptyMessageTextException();
                }

                text = value;
            }
        }


        public ReportLevel ReportLevel { get; set; }


    }
}
