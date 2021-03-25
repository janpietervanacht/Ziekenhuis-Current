using Background.Managers;
//using System.Configuration;

namespace BackGround
{
    //public class Program DIT WAS DE ORIGINELE CODE
    public static class ProgrammaBackGround // Veranderd, HIERDOOR aanroepbaar geworden vanuit MVC
    {
        // public static void Main(string[] args)
        public static void Main()
        {
            // Opstarten Dependency Injection en processen
            // is verplaatst naar een non-static method: StartBackGround(). 
            var backgroundManager = new StartManager(); // hierbinnen: DI
            backgroundManager.StartBackGround(); 
        }
    }
}

