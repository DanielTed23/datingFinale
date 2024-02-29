using Dating.Data.Models;

namespace Dating.Data.Crud.Interface
{
    public interface ICrud
    {

        // Metoden 'Create' er ansvarlig for at oprette en ny entitet i databasen.
        // Den tager et objekt af typen 'AccountProfile' som parameter, hvilket repræsenterer den konto,
        // der skal oprettes. Implementeringen af denne metode vil typisk tilføje den givne 'account' til databasen.
        void Create(AccountProfile account);

        void Delete(int id);

        void ReadAll();

        void ReadId(int id);


    }
}
