using Terminal.Gui;

namespace Notenmanager
{
    internal class Program
    {
        public static ColorScheme GLOBAL_CS = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.Green, Color.Black),
            Focus = Application.Driver.MakeAttribute(Color.Green, Color.Magenta),
            HotNormal = Application.Driver.MakeAttribute(Color.Green, Color.Black),
            HotFocus = Application.Driver.MakeAttribute(Color.Green, Color.Magenta),
        };

        public static ColorScheme GLOBAL_CS_TITLE = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.BrightYellow, Color.Black)
        };

        public static ColorScheme GLOBAL_CS_ERROR = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.Red, Color.Gray),
            HotNormal = Application.Driver.MakeAttribute(Color.Red, Color.Gray)
        };

        public static ColorScheme GLOBAL_CS_FINE = new ColorScheme()
        {
            Normal = Application.Driver.MakeAttribute(Color.Green, Color.Gray),
            HotNormal = Application.Driver.MakeAttribute(Color.Green, Color.Gray)
        };

        static void Main(string[] args)
        {
            Application.Init();

            try
            {
                Application.Run(new MainView());
            }
            finally
            {
                Application.Shutdown();
            }
        }

        public static bool FindStringList(List<string> list, string match)
        {
            for(int i = 0; i < list.Count; i++)
            {
                if(list[i] == match)
                {
                    return true;
                }
            }

            return false;
        }

        public static int CompareStrings(string s1, string s2)
        {
            int lowestStringLength = s1.Length;
            if(s1.Length > s2.Length)
            {
                lowestStringLength = s2.Length;
            }

            for(int i = 0; i < lowestStringLength; i++)
            {
                if((int)s1[i] < (int)s2[i])
                {
                    return -1;
                }

                if ((int)s1[i] > (int)s2[i])
                {
                    return 1;
                }
            }

            if(s1.Length < s2.Length)
            {
                return -1;
            }

            return 0;
        }

        public static Int64 CompareInteger(Int64 num1, Int64 num2)
        {
            return num1 - num2;
        }

        public static List<Exam> SortExams(List<Exam> list, ExamFilter filter, bool desc = false)
        {
            if(list.Count < 2)
            {
                return list;
            }

            for (int i = list.Count - 1; i > 0; i--)
            {
                object s1;
                object s2;
                string type = "string";
                switch (filter)
                {
                    case ExamFilter.Name:
                        s1 = list[i - 1].Name;
                        s2 = list[i].Name;
                        type = "string";
                        break;
                    case ExamFilter.Percent:
                        s1 = (Int64)list[i - 1].Percent;
                        s2 = (Int64)list[i].Percent;
                        type = "num";
                        break;
                    case ExamFilter.Date:
                        s1 = list[i - 1].Date.Ticks;
                        s2 = list[i].Date.Ticks;
                        type = "num";
                        break;
                    case ExamFilter.LearningField:
                        s1 = list[i - 1].LearningField;
                        s2 = list[i].LearningField;
                        type = "string";
                        break;
                    case ExamFilter.Subject:
                        s1 = list[i - 1].Subject;
                        s2 = list[i].Subject;
                        type = "string";
                        break;
                    default:
                        s1 = list[i - 1].Name;
                        s2 = list[i].Name;
                        type = "string";
                        break;
                }

                if(type == "string")
                {
                    if (CompareStrings((string)s1, (string)s2) > 0)
                    {
                        // Tausche Listenelemente aus wenn nicht geordnet
                        Exam tmp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = tmp;
                        i += 2;

                        if (i > list.Count) i = list.Count;
                    }
                }

                if(type == "num")
                {
                    if(CompareInteger((Int64)s1, (Int64)s2) > 0)
                    {
                        // Tausche Listenelemente aus wenn nicht geordnet
                        Exam tmp = list[i - 1];
                        list[i - 1] = list[i];
                        list[i] = tmp;
                        i += 2;

                        if (i > list.Count) i = list.Count;
                    }
                }
            }

            if (desc) list.Reverse();

            return list;
        }
    }
}

