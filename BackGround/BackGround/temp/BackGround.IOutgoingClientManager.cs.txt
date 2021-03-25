using BackGround.ConstantsAndEnums;

namespace Background.Interfaces
{
    public interface IOutgoingClientManager
    {
        void CreateOutgClientFile(TypeOfClient typeOfClient, TypeOfExport typeOfExport);
    }
}