using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using BaiKiemTra.View;

namespace BaiKiemTra
{
    public partial class Form1 : Form
    {
        int manhom = 0;
        int masinhvien = 0;

        public Form1()
        {
            InitializeComponent();
            NapDanhSachNhom();
        }
        void NapDanhSachNhom()
        {
            var list = nhomView.GetList();
            dataGridNhom.DataSource = list;
        }
        void NapDanhSachNguoi(int id)
        {

            var list = nguoiView.GetListByID(id);
            dataGridNguoi.DataSource = list;
        }
        private void ShowForm2()
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm2));
            thread.Start();
            this.Close();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            if (manhom != 0)
            {
                var rs = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Chú ý", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    nhomView.XoaNhom(manhom);
                    NapDanhSachNhom();
                }
            }
        }
        private void ShowForm3()
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }
        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowForm3));
            thread.Start();
            this.Close();
        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            if (masinhvien != 0)
            {
                var rs = MessageBox.Show("Bạn có chắc chắn muốn xóa không? ?", "Chú ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (rs == DialogResult.OK)
                {
                    nguoiView.XoaNguoi(masinhvien);
                    NapDanhSachNhom();
                    NapDanhSachNguoi(manhom);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'kiemTraDataSet1.Nguoi' table. You can move, or remove it, as needed.
            this.nguoiTableAdapter.Fill(this.kiemTraDataSet1.Nguoi);
            // TODO: This line of code loads data into the 'kiemTraDataSet.Nhom' table. You can move, or remove it, as needed.
            this.nhomTableAdapter.Fill(this.kiemTraDataSet.Nhom);

        }

        private void dataGridNhom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridNhom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridNhom.Rows[e.RowIndex];
            string tennhom = Convert.ToString(row.Cells["TenNhom"].Value);
            var list = nhomView.GetList();
            int id = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TenNhom.Equals(tennhom))
                {
                    id = list[i].ID;
                    manhom = id;
                }
            }
            NapDanhSachNguoi(manhom);
        }

        private void dataGridNguoi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = new DataGridViewRow();
            row = dataGridNguoi.Rows[e.RowIndex];
            txtTenGoi.Text = Convert.ToString(row.Cells["TenGoi"].Value);
            txtEmail.Text = Convert.ToString(row.Cells["Email"].Value);
            txtSDT.Text = Convert.ToString(row.Cells["SDT"].Value);
            string email = Convert.ToString(row.Cells["Email"].Value);

            var list = nguoiView.GetListAll();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Email.Equals(email))
                {
                    txtDiaChi.Text = list[i].DiaChi;
                    masinhvien = list[i].ID;
                }
            }
        }
    }
}
