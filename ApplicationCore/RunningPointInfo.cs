using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RunningApp.ApplicationCore
{
    public class RunningPointInfo : BaseEntity
    {
        public User User { get; set; }
        public RunningInfo RunningInfo { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
    }
}