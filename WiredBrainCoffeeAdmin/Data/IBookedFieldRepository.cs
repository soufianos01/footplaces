using FootballField.Data.Models;

namespace FootballField.Data
{
	public interface IBookedFieldRepository
	{
		public void Add(BookedField bookedField);
		public void Update(BookedField bookedField);
		public BookedField GetById(string id);
		public List<BookedField> GetAll();
		public void Delete(int id);
	}
}
