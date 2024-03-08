using PublisherData;
using PublisherDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherConsole
{
    public class DataLogic
    {
    ApplicationDbContext _context;

        public DataLogic(ApplicationDbContext context)
        {
            _context = context;
        }

        public DataLogic()
        {
            _context = new ApplicationDbContext();
        }

        public int ImportAuthors(Dictionary<string, string> authorsList)
        {
            foreach (var author in authorsList)
            {
                _context.Authors.Add(
                    new Author { FirstName = author.Key, LastName = author.Value });
            }
            return _context.SaveChanges();  
        }
    }
}
