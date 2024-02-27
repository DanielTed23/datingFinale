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
            _context.Add(account);
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
