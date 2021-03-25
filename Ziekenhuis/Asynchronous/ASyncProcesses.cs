using BackGround;
using System.Threading.Tasks;

namespace Ziekenhuis.Asynchronous
{
    public class ASyncProcesses
    {
        async public void CallBackGround()
        {
            await Task.Run(() =>
            {
                ProgrammaBackGround.Main(); 
            });
        }
    }
}
