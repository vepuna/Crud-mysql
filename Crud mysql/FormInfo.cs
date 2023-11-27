using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud_mysql
{
    public partial class FormInfo : Form
    {
        private readonly FormStudent _parent;
        public string id, name, reg, @class, section;

        public FormInfo(FormStudent parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Student";
            btnSave.Text = "Save";
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Student";
            btnSave.Text = "Update";
            txtName.Text = name;
            txtReg.Text = reg;
            txtClass.Text = @class;
            txtSection.Text = section;
            
        }

        public void Clear()
        {
            txtClass.Text = txtName.Text = txtReg.Text = txtSection.Text = string.Empty;
        }

        private void FormInfo_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Student Name  < 3");
                return;
            }
            if (txtReg.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student reg  < 1");
                return;
            }
            if (txtClass.Text.Trim().Length == 0)
            {
                MessageBox.Show("Student class  < 1");
                return;
            }
            if (txtSection.Text.Trim().Length == 1)
            {
                MessageBox.Show("Student section  < 1");
                return;
            }
            if (btnSave.Text == "Save")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.AddStudent(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Student std = new Student(txtName.Text.Trim(), txtReg.Text.Trim(), txtClass.Text.Trim(), txtSection.Text.Trim());
                DbStudent.UpdateStudent(std, id);
            }
            _parent.Display();

        }
        
    }
}
