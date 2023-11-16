using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{

    /// <summary>
    /// Class này cung cấp dữ liệu từ table Category cho UI, và ngược lại
    /// Class này sẽ xài CategoryRepo vừa tạo, Repo thì lại gọi đến DbContex
    /// </summary>
    public class BookCategoryService
    {

        private BookCategoryRepository _repo;
        public List<BookCategory> GetAllCategories()
        {
            _repo = new BookCategoryRepository();
            return _repo.GetAll();
        }

        public void DeleteACategory(int id)
        {
            _repo.Delete(id);
        }

        public BookCategory? GetACategory(int id)
        {
            return _repo.Get(id);
        }

        public void AddACategory(BookCategory bookCategory)
        {
            _repo.Create(bookCategory); //try-catch, trùng mã số, bỏ trống ô nhập
        }

        public void UpdateACategory(BookCategory bookCategory)
        {
            _repo.Update(bookCategory); //try-catch, validation
        }

        public List<BookCategory> SearchCategory(string keyword)
        {
            return _repo.GetAll().Where(b => b.BookGenreType.Contains(keyword) ||
                                            b.Description.Contains(keyword)).ToList();
        }

        public bool checkDuplicate(int id)
        {
            return _repo.Get(id) != null;
        }
    }
}
