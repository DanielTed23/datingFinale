using Dating.Data.Models;

namespace Dating.Data.Crud.Interface
{
    public interface ICrud
    {
        void Create(Account account);

        void Delete(int id);

        void ReadAll();

        void ReadId(int id);


    }
}
