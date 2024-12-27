using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DataAccessLayer;
using BusinessLayer;

namespace KatmanliMimari22
{
    public partial class Form1 : Form
    {
        private readonly Business businessLayer;
        public Form1()
        {
            InitializeComponent();
            businessLayer = new Business();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string uyeAdi = txtUyeAdi.Text.Trim();
                string uyeSoyadi = txtUyeSoyadi.Text.Trim();

                businessLayer.AddUye(uyeAdi, uyeSoyadi);
                LoadUyeler();

                txtUyeAdi.Clear();
                txtUyeSoyadi.Clear();

                MessageBox.Show("Üye başarıyla eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadUyeler()
        {
            List<Uyeler> uyelerList = businessLayer.GetUyeler();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = uyelerList;
        }
    }
}
