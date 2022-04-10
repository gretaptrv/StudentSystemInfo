using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static public class Logger
    {
        static private List<String> currentSessionActivities = new List<String>();

        static public void LogActivity(String activity)
        {
            String activityLine = DateTime.Now + ";"
                + LoginValidation.currentUserUsername + ";"
                + LoginValidation.currentUserRole + ";"
                + activity + "\n";

            if(File.Exists("test.txt"))
            {
                File.AppendAllText("test.txt", activityLine);
            }
            currentSessionActivities.Add(activityLine);
        }

        static public IEnumerable<string> getLogActivity()
        {
            List<string> activities = new List<string>();

            StreamReader reader = new StreamReader("test.txt");
            while (!reader.EndOfStream)
            {
                activities.Add(reader.ReadLine());
            }
            reader.Close();

            return activities;
        }

        static public void deleteByDate(DateTime deleteBefore)
        {
            //expected format [mm/dd/yyyy]
            String data;
            List<string> logs = new List<string>();

            StreamReader reader = new StreamReader("test.txt");
            while (!reader.EndOfStream)
            {
                data = reader.ReadLine();
                logs.Add(data);
            }
            reader.Close();

            StringBuilder sb = new StringBuilder();

            logs.ForEach(line =>
            {
                string[] split = line.Split(';');
                DateTime dt = DateTime.Parse(split[0]);
                if (DateTime.Compare(dt, deleteBefore) >= 0)
                {
                    sb.AppendLine(line);
                };
                //Less than zero t1 is earlier than t2. Zero t1 is the same as t2. Greater than
                //zero t1 is later than t2.
            });

            File.WriteAllText("test.txt", sb.ToString());
        }



        static public IEnumerable<string> getCurrentSessionActivities(string filter)
        {
            return (from activity in currentSessionActivities
             where activity.Contains(filter)
             select activity).ToList();
        }

    }
}
