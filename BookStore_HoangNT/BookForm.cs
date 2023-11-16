using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore_HoangNT
{
    public partial class BookForm : Form
    {

        //dùng 1 biến PUBLIC Book hoặc biến int id để lưu trạng thái form
        //nếu biến này == null thì Form ứng tạo mới
        //nếu biến này != null tức là id = ??? nào đó, thì ta Get() nó từ DB
        public int? BookId { get; set; }
        private BookService _bookService = new();
        private BookCategoryService _categoryService = new();

        public BookForm()
        {
            InitializeComponent();
        }

        private void BookForm_Load(object sender, EventArgs e)
        {

            cboCategory.DataSource = _categoryService.GetAllCategories();

            cboCategory.DisplayMember = "BookGenreType";
            cboCategory.ValueMember = "BookCategoryId";

            if (this.BookId != null)
            {

                var book = _bookService.GetABook((int)BookId);

                txtId.Text = book.BookId.ToString();
                txtName.Text = book.BookName;
                txtDescription.Text = book.Description;
                dtpReleasedDate.Value = book.ReleaseDate;
                txtQuantity.Text = book.Quantity.ToString();
                txtPrice.Text = book.Price.ToString();
                cboCategory.SelectedValue = book.BookCategoryId;
                txtAuthor.Text = book.Author;
                lblFormTitle.Text = "Update a Book...";
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<string> validationErrors = new List<string>();

            // Validate the BookId field.
            if (this.BookId != null)
            {
                if (!int.TryParse(txtId.Text.Trim(), out int bookId) || txtId.Text.Length == 0 ||
                    txtId.Text != BookId.ToString())
                {
                    validationErrors.Add("Invalid Book ID. Please enter a valid integer.");
                    txtId.Text = BookId.ToString();
                }
            }
            else
            {
                if (!int.TryParse(txtId.Text.Trim(), out int bookId) || txtId.Text.Length == 0 ||
                    _bookService.checkDuplicate(int.Parse(txtId.Text)))
                {
                    validationErrors.Add("This id has already existed");
                }
            }

            // Validate the BookName field.
            string bookName = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(bookName) || bookName.Length < 5 || bookName.Length > 90)
            {
                validationErrors.Add("Book's name must have the lentgh from 5 - 90 characters.");
            }

            // Validate the ReleaseDate field.
            DateTime releaseDate = dtpReleasedDate.Value.Date;

            // Validate the Author field.
            string author = txtAuthor.Text.Trim();
            if (string.IsNullOrWhiteSpace(author))
            {
                validationErrors.Add("Author is required.");
            }
            else
            {
                // Check if each word in the Author starts with an uppercase letter.
                string[] authorWords = author.Split(' ');
                foreach (string word in authorWords)
                {
                    if (!char.IsLetterOrDigit(word[0]) || !word.All(char.IsLetterOrDigit))
                    {
                        validationErrors.Add("Each word in Author must start with an uppercase letter or a digit and not contain special characters.");
                        break; // No need to continue checking if one word is invalid.
                    }
                }
            }

            // Validate the Quantity field.
            string quntityText = txtQuantity.Text.Trim();
            if (string.IsNullOrWhiteSpace(quntityText))
            {
                validationErrors.Add("Quantity is required.");
            }
            else if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity) || quantity < 0 || quantity > 4000000)
            {
                validationErrors.Add("Invalid Quantity. Please enter a valid quantiy.");
            }

            // Validate the Price field.
            string priceText = txtPrice.Text.Trim();
            if (string.IsNullOrWhiteSpace(priceText))
            {
                validationErrors.Add("Price is required.");
            }
            else if (!double.TryParse(txtPrice.Text.Trim(), out double price) || price <= 0)
            {
                validationErrors.Add("Invalid Price. Please enter a positive integer.");
            }


            // Check if there are any validation errors.
            if (validationErrors.Count > 0)
            {
                // Display error messages to the user.
                string errorMessage = string.Join("\n", validationErrors);
                MessageBox.Show(errorMessage, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //TODO: BTWS VALIDATION, IF CÁC Ô NHẬP THỎA HAY KHÔNG, KO THÌ CHỬI
                Book book = new Book()
                {
                    BookId = int.Parse(txtId.Text.Trim()),
                    BookName = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                    ReleaseDate = dtpReleasedDate.Value.Date,//chỉ lấy ngày, ko lấy giờ
                    Author = txtAuthor.Text.Trim(),
                    Quantity = int.Parse(txtQuantity.Text.Trim()),
                    Price = double.Parse(txtPrice.Text.Trim()),
                    BookCategoryId = int.Parse(cboCategory.SelectedValue.ToString()),
                };
                if (BookId != null)
                {
                    _bookService.UpdateABook(book);
                }
                else
                {
                    _bookService.AddABook(book);
                }
                Close();//đóng form khi save
            }
        }
    }
}
