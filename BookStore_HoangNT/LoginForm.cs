using Microsoft.Extensions.Configuration;
using Repositories.Entities;
using Services;
using System.Configuration;

namespace BookStore_HoangNT
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text;
            string password = txtPassword.Text;
            BookManagementMemberService se = new BookManagementMemberService(); ;

            BookManagementMember account = se.CheckLogin(email, password);
            if (account == null)
            {
                MessageBox.Show("Login failed. Please check your credentials",
                                 "Wrong credentials", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }
            int roleId = account.MemberRole;
            string username = account.FullName;
            string role = null;
            if (roleId == 1)
            {
                role = "Admin";
            }
            else if (roleId == 2)
            {
                role = "Manager";
            }
            else if (roleId == 3)
            {
                role = "Staff";
            }
            else
            {
                role = "Memeber";
            }

            BookManagerForm bookMgt = new BookManagerForm(roleId, username, role);
            bookMgt.Show();
            this.Hide();
        }



    }
}