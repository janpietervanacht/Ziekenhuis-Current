using Ziekenhuis.Model;

namespace Ziekenhuis.DataAccess.Interfaces
{
    public interface IDoctorRepository
    {

        Doctor Get(int Id);

    }
}