using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyTasksManager.Models;

namespace MyTasksManager.Models
{
    public class parentModel
    {
        public TasksDetail TasksDetail { get; set; }
        public Sorting Sorting { get; set; }
    }
}