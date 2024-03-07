using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherDomain
{
    public class Book
    {
        public virtual int BookId { get; set; }
        public virtual string Title { get; set; }
        public virtual DateOnly PublishDate { get; set; }
        public virtual decimal BasePrice { get; set; }

        public virtual Author Author { get; set; }
         public virtual  int AuthorId { get; set; }

        public Cover Cover { get; set; }
         //public int AuthorFK { get; set; }


    }
}
