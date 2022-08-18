using FootballField.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballField.Data
{
	public class BookedFieldRepository : IBookedFieldRepository
	{
		private WiredContext wiredContext;

		public BookedFieldRepository(WiredContext context)
		{
			this.wiredContext = context;
		}
		public void Add(BookedField bookedField)
		{
			this.wiredContext.BookedFields.Add(bookedField);
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public BookedField GetById(string id)
		{
			return wiredContext.BookedFields.FirstOrDefault(x => x.Id == id);
		}

		public List<BookedField> GetAll()
		{
			return wiredContext.BookedFields.ToList();
		}

		public void Update(BookedField bookedField)
		{
			wiredContext.Entry(bookedField).State = EntityState.Modified;
			wiredContext.SaveChanges();
		}
	}
}
