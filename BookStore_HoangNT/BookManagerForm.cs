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
    public partial class BookManagerForm : Form
    {
        private int _roleId { get; set; }
        private string _username { get; set; }
        private string _role { get; set; }
        private BookService _bookService = new BookService();
        private BookCategoryService _categoryService = new BookCategoryService();

        public BookManagerForm(int roleId, string username, string role)
        {
            InitializeComponent();
            this._roleId = roleId;
            this._username = username;
            this._role = role;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BookManagerForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BookManagerForm_Load(object sender, EventArgs e)
        {
            lblUser.Text = "Welcome " + _username + " | " + _role;

            var result = _bookService.GetAllBooks();
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = result;

            cboCategory.DataSource = _categoryService.GetAllCategories();
            cboCategory.DisplayMember = "BookGenreType";
            cboCategory.ValueMember = "BookCategoryId";

            cboCategoryFilter.Text = "All";

            if (_roleId == 3)
            {
                btnDelete.Enabled = false;
            }
            else if (_roleId == 4)
            {
                btnDelete.Enabled = false;
                newBookToolStripMenuItem.Enabled = false;
                btnUpdate.Enabled = false;
                manageCategoryToolStripMenuItem.Enabled = false;
            }
        }

        private void dgvBookList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvBookList.Columns["BookCategory"].Index)
            {
                string categoryId = dgvBookList["BookCategoryId", e.RowIndex].Value.ToString();
                string bookGenreType = ((BookCategory)cboCategory.Items.Cast<BookCategory>().FirstOrDefault(item => item.BookCategoryId.ToString() == categoryId))?.BookGenreType;
                e.Value = bookGenreType;
                e.FormattingApplied = true;
            }
            dgvBookList.Columns["BookCategory"].HeaderText = "BookGenreType";
        }

        private void dgvBookList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookList.SelectedRows.Count > 0)
            {
                var selectedBook = (Book)dgvBookList.SelectedRows[0].DataBoundItem;

                txtId.Text = selectedBook.BookId.ToString();
                txtName.Text = selectedBook.BookName;
                txtDescription.Text = selectedBook.Description;
                dtpReleasedDate.Value = selectedBook.ReleaseDate;
                txtQuantity.Text = selectedBook.Quantity.ToString();
                txtPrice.Text = selectedBook.Price.ToString();
                cboCategory.SelectedValue = selectedBook.BookCategoryId;
                txtAuthor.Text = selectedBook.Author;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKeyword.Text))
            {
                MessageBox.Show("The search keyword is required!!!",
                    "Search keyword required",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = _bookService.SearchBooks(txtKeyword.Text.Trim());

            if (!result.Any())
            {
                MessageBox.Show("No book matches this keyword!",
                    "No result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvBookList.DataSource = null;
            dgvBookList.DataSource = result;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;

            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("The Book ID is invalid. Please input a number!!!",
                    "Invalid Book ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Book book = _bookService.GetABook(id);
            if (book == null)
            {
                MessageBox.Show("This book does not exist. Please select a row in the grid to edit or input a number!!!",
                    "Invalid Book ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            _bookService.DeleteABook(id);

            var result = _bookService.GetAllBooks();
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = result;

            txtId.Text = "";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("The Book ID is invalid. Please select a row in the grid to edit or input a number!!!",
                    "Invalid Book ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Book book = _bookService.GetABook(id);
            if (book == null)
            {
                MessageBox.Show("This book does not exist. Please select a row in the grid to edit or input a number!!!",
                    "Invalid Book ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            BookForm bookForm = new BookForm();
            bookForm.BookId = int.Parse(txtId.Text);
            bookForm.ShowDialog();

            var result = _bookService.GetAllBooks();
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = result;

            txtId.Text = "";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookForm bookForm = new BookForm();
            bookForm.BookId = null;
            bookForm.ShowDialog();

            var result = _bookService.GetAllBooks();
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = result;
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            BookCategoryForm bookCategoryForm = new BookCategoryForm(_roleId);
            bookCategoryForm.ShowDialog();

            cboCategory.DataSource = _categoryService.GetAllCategories();
            cboCategory.DisplayMember = "BookGenreType";
            cboCategory.ValueMember = "BookCategoryId";
        }

        private void cboCategoryFIlter_Click(object sender, EventArgs e)
        {
            BookCategory category = new BookCategory()
            {
                BookCategoryId = 0,
                BookGenreType = "All"
            };

            List<BookCategory> bookCategories = _categoryService.GetAllCategories();
            bookCategories.Add(category);
            cboCategoryFilter.DataSource = bookCategories;
            cboCategoryFilter.DisplayMember = "BookGenreType";
            cboCategoryFilter.ValueMember = "BookCategoryId";
        }

        private void cboCategoryFIlter_SelectionChangeCommitted(object sender, EventArgs e)
        {
            BookCategory category = (BookCategory)cboCategoryFilter.SelectedItem;
            string categoryId = category.BookCategoryId.ToString();

            if (category.BookGenreType.Equals("All"))
            {
                var result = _bookService.GetAllBooks();
                dgvBookList.DataSource = null;
                dgvBookList.DataSource = result;
            }
            else
            {
                var result = _bookService.SearchBooksByCategory(categoryId);
                dgvBookList.DataSource = null;
                dgvBookList.DataSource = result;
            }
        }

        private void btnSeeAll_Click(object sender, EventArgs e)
        {
            var result = _bookService.GetAllBooks();
            dgvBookList.DataSource = null;
            dgvBookList.DataSource = result;
        }
    }
}
