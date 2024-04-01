using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;


public class CalendarDb : DbContext
{
    public DbSet<Leapnes> Leapness { get; set; }
    public DbSet<Interval> Intervals { get; set; }
    public DbSet<DayWeek> DayOfWeeks { get; set; }

    public CalendarDb(DbContextOptions<CalendarDb> options) : base(options) { }

    public CalendarDb() : base(new DbContextOptionsBuilder<CalendarDb>().UseSqlite($"Data Source={GetPath()}").Options) { }

    public static String GetPath()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        string path = Environment.GetFolderPath(folder);
        string dbPath = System.IO.Path.Join(path, "CalendarDotNetProject", "calendar3.db");
        Console.WriteLine(dbPath);
        return dbPath;
    }
}

[PrimaryKey(nameof(Leapnes_id))]
public class Leapnes
{
    public int Leapnes_id { get; set; }
    public int year { get; set; }

    public bool leap { get; set; }
}

[PrimaryKey(nameof(interval_id))]
public class Interval
{
    public int interval_id { get; set; }
    public DateTime date1 { get; set; }
    public DateTime date2 { get; set; }
    public int interval { get; set; }
}

[PrimaryKey(nameof(DayWeekId))]
public class DayWeek
{
    public int DayWeekId { get; set; }
    public DateTime date { get; set; }

    public int dayWeek { get; set; }
}