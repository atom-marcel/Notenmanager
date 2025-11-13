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
            Normal = Application.Driver.MakeAttribute(Color.BrightGreen, Color.Black),
            HotNormal = Application.Driver.MakeAttribute(Color.BrightGreen, Color.Black)
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
    }
}

