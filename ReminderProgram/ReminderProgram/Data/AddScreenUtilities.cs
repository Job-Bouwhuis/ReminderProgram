using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReminderProgram.Data
{
    internal class AddScreenUtilities
    {
        public static List<string> GetPriorities()
        {
            List<string> strings = new();
            foreach (string name in Enum.GetNames(typeof(Priority)))
            {
                strings.Add(name);
            }
            return strings;
        }
    }

    public enum Priority
    {
        Unimportant,
        Normal,
        Important,
        HighPriority,
    }
}
