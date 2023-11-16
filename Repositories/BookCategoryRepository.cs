using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    
    /// <summary>
    /// Class này dùng để CRUD table Category - Thể loại Sách
    /// Thường thể loại sách hiếm khi thay đổi, chủ yếu là lấy ra
    /// danh sách đưa vào dropdown/combobox
    /// </summary>
    public class BookCategoryRepository
    {
        public List<BookCategory> GetAll()
        {
            //_context = new BookManagement2023DbContext();
            //return _context.BookCategories.ToList();
            return new BookManagement2023DbContext().BookCategories.ToList();
        }

        private BookManagement2023DbContext _context;
        public BookCategory? Get(int bookCategoryId)
        {
            _context = new BookManagement2023DbContext();
            //_context.Books; //tương đương SELECT * FROM
            //lấy 1 cuốn theo Id có 2 cách:
            //LINQ: FirstOrDefault(lamba - hàm - delegate trả về 1 object theo đk nào đó)
            //                                        Func<>
            //dùng hàm sẵn của List, hàm Find(theo key)

            return _context.BookCategories.Find(bookCategoryId);
        }

        /// <summary>
        /// Hàm này trả về tất cả các cuốn sách đang có trong table Book
        /// tức là return List<Book>. Cần gọi DbContext, đang nắm giữ 3 table
        /// Có 1 chuyện thú vị ở mối quan hệ 1-N TRONG TABLE Ở ĐÂY...
        /// 
        /// </summary>
        /// <returns></returns>
        public List<BookCategory> Search()
        {
            _context = new BookManagement2023DbContext();
            //return _context.Books.ToList(); //quá đã
            //CHỈ LOAD THÔNG TIN TABLE BOOK, KO LOAD TABLE CATEGORY
            //LÀM SAO LOAD ĐC INFO CỦA CATEGORY, ĐỂ SAU NÀY CÒN LẤY TÊN CATEGORY
            //GIỐNG NHƯ CÂU SELECT * FROM BOOK B, CATEGORY C WHERE B.CATID = C.CATID - JOIN

            //CÂU JOIN BẮT ĐẦU
            return _context.BookCategories.Include(cat => cat.BookCategoryId).ToList();
        }                                 //inner join sang table BookCategory
                                          //qua đặc tính/thuộc tính Category ở Book



        /// <summary>
        /// Hàm này tạo mới 1 cuốn sách, insert xuống DB qua gọi hành động
        /// của DbContext và đang đc chống lưng bởi Entity Framework
        /// Đầu vào cần là new Book(...) mới tinh nào đó
        /// </summary>
        /// <param name="book"></param>
        public void Create(BookCategory bookCategory)
        {
            _context = new BookManagement2023DbContext();
            _context.BookCategories.Add(bookCategory); //quá đã, INSERT INTO BOOK VALUES(...)
            _context.SaveChanges();
        }

        /// <summary>
        /// Hàm này sẽ cập nhật 1 cuốn sách đang có, với thông tin bên trong 
        /// cuốn sách đc điều chỉnh: giá mới, năm xb mới, tên gõ đúng chính tả...
        /// Vẫn cần đưa vào 1 cuốn sách, và phải gọi DbContext
        /// </summary>
        /// <param name="book"></param>
        public void Update(BookCategory bookCategory)
        {
            _context = new BookManagement2023DbContext();
            _context.BookCategories.Update(bookCategory);
            //quá đã, SQL: UPDATE BOOK SET NAME = 'TÊN MỚI CHO CUỐN SÁCH'... WHERE
            _context.SaveChanges();
        }

        /// <summary>
        /// Hàm này xoá 1 cuốn sách theo Id. TA CẦN WHERE THEO ID
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            //ta phải đi tìm cuốn sách rồi mới xoá nó
            //xài LINQ, hoặc GET() Ở TRÊN
            _context = new BookManagement2023DbContext();
            var bookCategory = _context.BookCategories.FirstOrDefault(b => b.BookCategoryId == id);
            //                                     nhận vào 1 delegate
            //                                     delegate(student) -> sv thoả tiêu chí
            if (bookCategory != null)
            {
                _context.BookCategories.Remove(bookCategory);
                _context.SaveChanges();
            }
        }
    }
}
