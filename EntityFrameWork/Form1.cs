using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EntityFrameWork
{
    public partial class Form1 : Form
    {
        StudentEntities db;

        public Form1()
        {
            InitializeComponent();
            loadData();

        }

        void loadData()
        {
            db = new StudentEntities();
            var result = from c in db.sinhviens

                         select new { id = c.ID ,Name = c.student,Class=c.Lop.@class };

            dataGridView1.DataSource = result.ToList();

        }

        void loadTextBox()
        {
            textBoxID.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "ID"));
            textBoxName.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "name"));
            textBoxClass.DataBindings.Add(new Binding("text", dataGridView1.DataSource, "Class"));
        }

        void deleteTextBox()
        {
            textBoxName.DataBindings.Clear();
            textBoxID.DataBindings.Clear();
            textBoxClass.DataBindings.Clear();

        }

        private void buttonWatch_Click(object sender, EventArgs e)
        {
            loadData();
            deleteTextBox();
            loadTextBox();

        }

        void runForm2()
        {
            Application.Run(new Form2());
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            ThreadStart threadForm2 = new ThreadStart(runForm2);
            Thread thrd = new Thread(threadForm2);
            thrd.Start();
            deleteTextBox();



        }

        void savedata()
        {
            db.SaveChanges();
            MessageBox.Show("Sửa Thành công");
            loadData();
            deleteTextBox();
            loadTextBox();

        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int idStudent = Convert.ToInt32(textBoxID.Text);
            sinhvien sv = db.sinhviens.Find(idStudent);
            sv.student = textBoxName.Text;
            
            switch (textBoxClass.Text)
            {
                case "classs 1":
                    sv.IDclass = 1;
                    savedata();
                    break;

                case "classs 2":
                    sv.IDclass = 2;
                    savedata();
                    break;

                case "classs 3":
                    sv.IDclass = 3;
                    savedata();
                    break;

                case "classs 4":
                    sv.IDclass = 4;
                    savedata();
                    break;

                default:
                    MessageBox.Show("Khai báo sai lớp!syntax: classs [1,2,3,4]", "LỖI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;

            }
           

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int idStudent = Convert.ToInt32(textBoxID.Text);
            sinhvien sv = db.sinhviens.Where(c => c.ID == idStudent).SingleOrDefault();
            db.sinhviens.Remove(sv);
            db.SaveChanges();
            loadData();
            deleteTextBox();
            loadTextBox();
        }

        private void buttonaExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
