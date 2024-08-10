using System;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Tutorial_05
{
    public partial class Tutorial_05 : Form
    {
        private SqlConnection cnn;
        private string imageFile = ""; //image file path
        private const int pageSize = 10;
        private int currentPage = 1;
        public Tutorial_05()
        {
            InitializeComponent();
            string connectionString;
            connectionString = @"Data Source = PYAE_PHYO\SQLEXPRESS; Initial Catalog = EmployeeDB; Integrated Security = True";
            cnn = new SqlConnection(connectionString);
        }
        private void Tutorial_05_Load(object sender, EventArgs e)
        {
            LoadScreen();
            dgvEmployee.ReadOnly = true;
            cboEmployeeType.Items.Add("Full Time");
            cboEmployeeType.Items.Add("Part Time");

        }

        //LoadScreen
        private void LoadScreen()
        {
            try
            {
                cnn.Open();
                //string selectQuery = "SELECT * FROM Employees_tb";
                string selectQuery = $"SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY Name) AS RowNum, * FROM Employees_tb) AS Temp " +
                                 $"WHERE RowNum BETWEEN {(currentPage - 1) * pageSize + 1} AND {currentPage * pageSize}";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, cnn);
                DataTable employeeTable = new DataTable();
                adapter.Fill(employeeTable);
                dgvEmployee.DataSource = employeeTable;
                dgvEmployee.Columns["ID"].Visible = false;
                dgvEmployee.Columns["RowNum"].Visible = false;
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                cnn.Close();
            }

        }

        //Email Validation
        private bool ValidateEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            return Regex.IsMatch(email, pattern);
        }

        //check valitaion
        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || txtName.Text.Length > 20)
            {
                MessageBox.Show("Please enter a valid name (20 characters limit!).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!long.TryParse(txtPhNo.Text, out long phoneNumber) || phoneNumber <= 0 || txtPhNo.Text.Length > 15)
            {
                MessageBox.Show("Please enter a valid phone number (15 digits limit!).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPhNo.Focus();
                return false;
            }

            if (!ValidateEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }


            if (!rdoMale.Checked && !rdoFemale.Checked)
            {
                MessageBox.Show("Please select a gender.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            if (cboEmployeeType.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee type.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime currentDate = DateTime.Today;
            DateTime minYear = currentDate.AddYears(-18);
            DateTime selectedDate = dtpBirth.Value;

            if (selectedDate > minYear)
            {
                MessageBox.Show("You must be at least 18 years old to proceed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpBirth.Value = currentDate;
                return false;
            }


            if (string.IsNullOrWhiteSpace(txtAddress.Text) || txtAddress.Text.Length > 200)
            {
                txtAddress.Focus();
                MessageBox.Show("Please enter a valid Address (200 characters limit!).", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (imgBox.Image == null)
            {
                btnUpload.Focus();
                MessageBox.Show("Please upload a photo.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        //clearinput
        private void ClearInputs()
        {
            txtName.Clear();
            txtPhNo.Clear();
            txtEmail.Clear();
            cboEmployeeType.SelectedIndex = -1;
            rdoFemale.Checked = false;
            rdoMale.Checked = false;
            dtpBirth.Value = DateTime.Now;
            txtAddress.Clear();
            btnAdd.Text = "Add";
            imgBox.Image = null;
        }

        //Add
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            };

            //Update Data
            if (btnAdd.Text == "Update")
            {
                int rowID = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells["ID"].Value);
                try
                {
                    cnn.Open();
                    string updateQuery = "UPDATE Employees_tb SET Image = @Image ,Name = @Name, PhNo = @PhNo, Email = @Email, Gender = @Gender, EmployeeType = @EmployeeType, DateOfBirth = @DateOfBirth, Address = @Address WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(updateQuery, cnn))
                    {
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@PhNo", Convert.ToInt64(txtPhNo.Text));
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Gender", rdoMale.Checked ? "Male" : "Female");
                        command.Parameters.AddWithValue("@EmployeeType", cboEmployeeType.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@DateOfBirth", dtpBirth.Value.Date);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@ID", rowID);
                        string imagePath = SaveImageToDatabase(imgBox.Image);
                        command.Parameters.AddWithValue("@Image", imagePath);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Updated successfully!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                finally
                {
                    cnn.Close();
                }

                ClearInputs();
                LoadScreen();
            }

            //Add Data
            else
            {
                try
                {
                    cnn.Open();
                    string insertQuery = "INSERT INTO Employees_tb (Image, Name, PhNo, Email, Gender, EmployeeType, DateOfBirth, Address, UpdateData, DeleteData) " +
                                         "VALUES (@Image, @Name, @PhNo, @Email, @Gender, @EmployeeType, @DateOfBirth, @Address ,@UpdateData , @DeleteData)";
                    using (SqlCommand command = new SqlCommand(insertQuery, cnn))
                    {
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@PhNo", Convert.ToInt64(txtPhNo.Text));
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Gender", rdoMale.Checked ? "Male" : "Female");
                        command.Parameters.AddWithValue("@EmployeeType", cboEmployeeType.SelectedItem.ToString());
                        command.Parameters.AddWithValue("@DateOfBirth", Convert.ToString(dtpBirth.Value));
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);
                        command.Parameters.AddWithValue("@UpdateData", "Update");
                        command.Parameters.AddWithValue("@DeleteData", "Delete");
                        string imagePath = SaveImageToDatabase(imgBox.Image);
                        command.Parameters.AddWithValue("@Image", imagePath);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Added successfully!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                finally
                {
                    cnn.Close();
                }
                LoadScreen();
                ClearInputs();
            }
        }

        //clear
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearInputs();
        }


        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Update Data
            if (e.RowIndex >= 0 && e.ColumnIndex == 10)
            {
                DataGridViewRow row = dgvEmployee.Rows[e.RowIndex];
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtPhNo.Text = row.Cells["PhNo"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                if (row.Cells["Gender"].Value.ToString() == "Male")
                {
                    rdoMale.Checked = true;
                }
                else
                {
                    rdoFemale.Checked = true;
                }
                cboEmployeeType.SelectedItem = row.Cells["EmployeeType"].Value.ToString();
                dtpBirth.Value = DateTime.Parse(row.Cells["DateOfBirth"].Value.ToString());
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                btnAdd.Text = "Update";
            }

            //Delete Data
            if (e.RowIndex >= 0 && e.ColumnIndex == 11)
            {
                int rowId = Convert.ToInt32(dgvEmployee.SelectedRows[0].Cells["ID"].Value);
                try
                {
                    cnn.Open();
                    string deleteQuery = "DELETE FROM Employees_tb WHERE ID = @ID";
                    using (SqlCommand command = new SqlCommand(deleteQuery, cnn))
                    {
                        command.Parameters.AddWithValue("@ID", rowId);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Deleted successfully!");
                }
                catch (Exception error)
                {
                    MessageBox.Show(error.Message);
                }
                finally
                {
                    cnn.Close();
                }
                ClearInputs();
                LoadScreen();
            }
        }

        //Upload image
        private void btnUpload_Click(object sender, EventArgs e)
        {
            OpenFileDialog opnfd = new OpenFileDialog();
            opnfd.Filter = "Image Files (*.jpg;*.jpeg;.*.gif;)|*.jpg;*.jpeg;.*.gif";
            if (opnfd.ShowDialog() == DialogResult.OK)
            {
                imageFile = opnfd.FileName;
                imgBox.Image = Image.FromFile(imageFile);
            }
        }


        private string SaveImageToDatabase(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms, image.RawFormat);
            byte[] imageData = ms.ToArray();
            ms.Close();
            return Convert.ToBase64String(imageData);
        }


        //btnPrev
        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadScreen();

            }
        }

        //btnNext
        private void btnNext_Click(object sender, EventArgs e)
        {
            cnn.Open();
            string countQuery = "SELECT COUNT(*) FROM Employees_tb";
            SqlCommand countCommand = new SqlCommand(countQuery, cnn);
            int totalRecords = Convert.ToInt32(countCommand.ExecuteScalar());
            int totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            cnn.Close();
            if (currentPage < totalPages)
            {
                currentPage++;
            }
            LoadScreen();
        }



    }
}