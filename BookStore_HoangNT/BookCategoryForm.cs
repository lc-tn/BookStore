using Repositories.Entities;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookStore_HoangNT
{
    public partial class BookCategoryForm : Form
    {
        private int _roleId { get; set; }
        private BookCategoryService _categoryService = new BookCategoryService();
        public BookCategoryForm(int roleId)
        {
            InitializeComponent();
            _roleId = roleId;
        }

        private void BookCategoryForm_Load(object sender, EventArgs e)
        {
            var result = _categoryService.GetAllCategories();
            dgvBookCategoryList.DataSource = null;
            dgvBookCategoryList.DataSource = result;
            dgvBookCategoryList.Columns["Books"].Visible = false;

            if (_roleId == 3)
            {
                btnDelete.Enabled = false;
            }
        }

        private void dgvBookCategoryList_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvBookCategoryList.SelectedRows.Count > 0)
            {
                var selectedBook = (BookCategory)dgvBookCategoryList.SelectedRows[0].DataBoundItem;
                txtId.Text = selectedBook.BookCategoryId.ToString();
                txtName.Text = selectedBook.BookGenreType;
                txtDescription.Text = selectedBook.Description;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> validationErrors = new List<string>();
            if (!int.TryParse(txtId.Text.Trim(), out int bookCategoryId) || txtId.Text.Length == 0 ||
                _categoryService.checkDuplicate(int.Parse(txtId.Text)))
            {
                validationErrors.Add("This id has already existed");
            }

            // Validate the BookName field.
            string bookCategoryName = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(bookCategoryName) || bookCategoryName.Length < 5 || bookCategoryName.Length > 90)
            {
                validationErrors.Add("Category's name must have the lentgh from 5 - 90 characters.");
            }

            string description = txtDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(description))
            {
                validationErrors.Add("Description is required.");
            }
            else
            {
                // Check if each word in the Author starts with an uppercase letter.
                string[] authorWords = description.Split(' ');
                foreach (string word in authorWords)
                {
                    if (!char.IsLetterOrDigit(word[0]) || !word.All(char.IsLetterOrDigit))
                    {
                        validationErrors.Add("Each word in Description must start with an uppercase letter or a digit and not contain special characters.");
                        break;
                    }
                }
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
                BookCategory bookCategory = new()
                {
                    BookCategoryId = int.Parse(txtId.Text.Trim()),
                    BookGenreType = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                };
                _categoryService.AddACategory(bookCategory);
            }
            var result = _categoryService.GetAllCategories();
            dgvBookCategoryList.DataSource = null;
            dgvBookCategoryList.DataSource = result;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("The Book Category ID is invalid. Please select a row in the grid to edit or input a number!!!",
                    "Invalid Book Category ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            List<string> validationErrors = new List<string>();
            if (!int.TryParse(txtId.Text.Trim(), out int bookId) || txtId.Text.Length == 0 ||
                !_categoryService.checkDuplicate(int.Parse(txtId.Text)))
            {
                validationErrors.Add("This id does not existed");
            }

            // Validate the BookName field.
            string bookName = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(bookName) || bookName.Length < 5 || bookName.Length > 90)
            {
                validationErrors.Add("Book Category Name must have the lentgh from 5 - 90 characters.");
            }

            string description = txtDescription.Text.Trim();
            if (string.IsNullOrWhiteSpace(description))
            {
                validationErrors.Add("Description is required.");
            }
            else
            {
                // Check if each word in the Author starts with an uppercase letter.
                string[] authorWords = description.Split(' ');
                foreach (string word in authorWords)
                {
                    if (!char.IsLetterOrDigit(word[0]) || !word.All(char.IsLetterOrDigit))
                    {
                        validationErrors.Add("Each word in Description must start with an uppercase letter or a digit and not contain special characters.");
                        break;
                    }
                }
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
                BookCategory bookCategory = new()
                {
                    BookCategoryId = int.Parse(txtId.Text.Trim()),
                    BookGenreType = txtName.Text.Trim(),
                    Description = txtDescription.Text.Trim(),
                };
                _categoryService.UpdateACategory(bookCategory);
            }

            var result = _categoryService.GetAllCategories();
            dgvBookCategoryList.DataSource = null;
            dgvBookCategoryList.DataSource = result;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id;
            if (string.IsNullOrWhiteSpace(txtId.Text) || !int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("The Book Category ID is invalid. Please select a row in the grid to edit or input a number!!!",
                    "Invalid Book Category ID",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            _categoryService.DeleteACategory(id);

            //load cái danh sách Sách vào grid
            var result = _categoryService.GetAllCategories();
            dgvBookCategoryList.DataSource = null;    //vip, xoá lưới, lấy danh sách mới
            dgvBookCategoryList.DataSource = result;
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

            var result = _categoryService.SearchCategory(txtKeyword.Text.Trim());

            if (!result.Any())
            {
                MessageBox.Show("No category matches this keyword!",
                    "No result",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvBookCategoryList.DataSource = null;
            dgvBookCategoryList.DataSource = result;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
