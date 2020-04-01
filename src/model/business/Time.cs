using System.Collections.Generic;

namespace DailyMealPlanner.model.business
{
    public class Time
    {
        private static readonly Dictionary<string, Time> AllTimes = new Dictionary<string, Time>();

        public string Name { get; set; }

        private Time()
        {
        }

        private Time(string name)
        {
            this.Name = name;
        }

        public static Time GetInstance(string nameTime)
        {
            if (AllTimes.TryGetValue(nameTime, out Time resultTime)) return resultTime;
            Time bufTime = new Time(nameTime);
            AllTimes.Add(nameTime, bufTime);
            return bufTime;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == this) return true;
            if (!(obj is Time) && obj == null  ) return false;
            Time time = (Time) obj;
            return this.Name == time.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}