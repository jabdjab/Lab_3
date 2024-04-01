public class Db_work
{
    public CalendarDb db;

    public Db_work(CalendarDb db_)
    {
        db = db_;
    }
    // leapnes
    public void Create(bool leap_, int year_)
    {
        Console.WriteLine("SaveToDatabase: leap by year");
        db.Add(new Leapnes { leap = leap_, year = year_ });
        db.SaveChanges();
    }

    public bool? Read(int year_)
    {
        Console.WriteLine("read");
        return db.Leapness.FirstOrDefault(b => b.year == year_)?.leap;
    }

    public void Remove(int year_)
    {
        Console.WriteLine("remove");
        var entries = db.Leapness.Where(b => b.year == year_).ToList();
        for (int i = 0; i < entries.Count; ++i)
        {
            Console.WriteLine($"Removing Leapnes({entries[i].Leapnes_id}, {entries[i].year}, {entries[i].leap})");
            db.Remove(entries[i]);
        }
        db.SaveChanges();
    }

    // Interval
    public void Create(DateTime date1_, DateTime date2_, int interval_)
    {
        Console.WriteLine("SaveToDatabase: distanse by dates");
        db.Add(new Interval { date1 = date1_, date2 = date2_, interval = interval_ });
        db.SaveChanges();
    }

    public int? Read(DateTime date1_, DateTime date2_)
    {
        Console.WriteLine("read");
        return db.Intervals.FirstOrDefault(b => b.date1 == date1_ && b.date2 == date2_)?.interval;
    }
    public void Remove(DateTime date1_, DateTime date2_)
    {
        Console.WriteLine("remove");
        var entries = db.Intervals.Where(b => b.date1 == date1_ && b.date2 == date2_).ToList();
        for (int i = 0; i < entries.Count; ++i)
        {
            Console.WriteLine($"Removing Intervals({entries[i].interval_id}, {entries[i].date1}, {entries[i].date2}, {entries[i].interval})");
            db.Remove(entries[i]);
        }
        db.SaveChanges();
    }

    // Day Of a Week
    public void Create(DateTime date_, int dayWeek_)
    {
        Console.WriteLine("SaveToDatabase: dayweek by date");
        db.Add(new DayWeek { date = date_, dayWeek = dayWeek_ });
        db.SaveChanges();
    }

    public int? Read(DateTime date_)
    {
        Console.WriteLine("read");
        return db.DayOfWeeks.FirstOrDefault(b => b.date == date_)?.dayWeek;
    }
    public void Remove(DateTime date_)
    {
        Console.WriteLine("remove");
        var entries = db.DayOfWeeks.Where(b => b.date == date_).ToList();
        for (int i = 0; i < entries.Count; ++i)
        {
            Console.WriteLine($"Removing DayOfWeeks({entries[i].DayWeekId}, {entries[i].date}, {entries[i].dayWeek})");
            db.Remove(entries[i]);
        }
        db.SaveChanges();
    }
}