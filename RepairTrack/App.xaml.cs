﻿using RepairTrack.Database;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RepairTrack
{
    public partial class App : Application
    {
        public static RepairTrackDBEntities dBEntities = new RepairTrackDBEntities();
    }
}
