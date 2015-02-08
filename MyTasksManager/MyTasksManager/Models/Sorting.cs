using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace MyTasksManager.Models
{
    public class Sorting
    {
        [Key]
        public int Id { get; set; }
        public string SortField { get; set; }
        public string SortDirection { get; set; }
       
    }
    public class SortingContext : DbContext
    {
        public DbSet<Sorting> SortingDetails
        {
            get;
            set;
        }
    }
}