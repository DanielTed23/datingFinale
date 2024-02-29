using Dating.Data.Crud.Interface;
using Dating.Data.Models;

namespace Dating.Data.Crud
{
    public class EFCRUD : ICrud
    {
        private readonly DatingContext _context;

        public EFCRUD(DatingContext context)
        {
            _context = context;


        }

        public void Create(AccountProfile account)
        {
            // Tilføjer den nye 'account' entitet til DbContext, hvilket forbereder den til at blive gemt i databasen.
            _context.Add(account);

            // Gemmer ændringerne i databasen, inklusiv den nye 'account' entitet,
            // hvilket effektivt opretter den nye konto i databasen.
            _context.SaveChanges();
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void ReadAll()
        {
            throw new NotImplementedException();
        }

        public void ReadId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
