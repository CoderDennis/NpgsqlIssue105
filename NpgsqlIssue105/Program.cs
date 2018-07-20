using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NpgsqlIssue105
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new Context())
            {
                var setting = context.Settings.Find(Guid.NewGuid(), SettingType.ValueA);
            }
            Console.ReadKey();
        }
    }

    public enum SettingType
    {
        ValueA = 1
    }

    public class Setting
    {
        [Key]
        [Column(Order = 1)]
        public Guid UserId { get; set; }

        [Key]
        [Column(Order = 2)]
        public SettingType SettingType { get; set; }

        public string SettingValue { get; set; }
    }

    public class Context : DbContext
    {
        public Context() : base("Default") { }

        public DbSet<Setting> Settings { get; set; }
    }
}
