using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatTodo
{
    public enum Priority 
    {
        Now,
        DL,
        Def,
        Cal
    }
    class TodoEvent
    {
        public string Name { get; set; }
        
    }
}
