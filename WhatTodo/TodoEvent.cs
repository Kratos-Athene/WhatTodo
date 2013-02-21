using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo
{
    public enum Priority 
    {
        ASAP,
        DL,
        LAZY,
        CAL
    }
    class TodoEvent
    {
        public string pName { get; set; }
        public Priority pPriority { get; set; }
        public TimeSpan pRequired { get; set; }
        public DateTime pDeadline { get; set; }
        public string pInfo { get; set; }
        public Boolean pSplit { get; set; }

        public TodoEvent(string Name, Priority Priority, TimeSpan Required, DateTime Deadline, string Info, Boolean Split)
        {
            pName = Name;
            pPriority = Priority;
            pRequired = Required;
            pDeadline = Deadline;
            pInfo = Info;
            pSplit = Split;
        }
    }
}
