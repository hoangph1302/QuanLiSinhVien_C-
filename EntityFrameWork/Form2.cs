using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameWork
{
    public partial class Form2 : Form
    {
        int idClass;
        StudentEntities db;
        public Form2()
        {
            InitializeComponent();
        }

        void saveData()
        {
            db.sinhviens.Add(new sinhvien() { student = textBoxName.Text, IDclass = idClass });
            db.SaveChanges();
            MessageBox.Show("Thêm thành công!");
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            db = new StudentEntities();

            switch (textBoxClass.Text)
            {
                case "1":
                    idClass = 1;
                    saveData();
                    break;

                case "2":
                    idClass = 2;
                    saveData();
                    break;

                case "3":
                    idClass = 3;
                    saveData();
                    break;

                case "4":
                    idClass = 4;
                    saveData();
                    break;

                default:
                    MessageBox.Show("Khai báo sai lớp!", "LỖI",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
            
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
