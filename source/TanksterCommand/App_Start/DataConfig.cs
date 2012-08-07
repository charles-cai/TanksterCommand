using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TanksterCommand.Models;

namespace TanksterCommand
{
    public class DataConfig
    {


        public static void ConfigureDatabase()
        {
            Database.SetInitializer<TanksterContext>(new CreateDatabaseIfNotExists<TanksterContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TanksterContext, Migrations.Configuration>());
        }


    }
}