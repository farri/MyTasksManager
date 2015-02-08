using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MyTasksManager.Models
{
    public class TasksDetail
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        [DataType(DataType.Date)]
        public DateTime dueDate { get; set; }
        public int hoursLeft { get; set; }
        public bool priority { get; set; }
    }
    public class TasksDetailContext : DbContext
    {
        public DbSet<TasksDetail> TasksDetails
        {
            get;
            set;
        }
    }
}