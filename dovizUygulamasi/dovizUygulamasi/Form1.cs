using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace dovizUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugunKur = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var xmlDosya = new XmlDocument();
            xmlDosya.Load(bugunKur);

            string dolarAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'USD']/BanknoteBuying").InnerXml;
            lblDolarAlis.Text = dolarAlis;

            string dolarSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolarSatis;

            string euroAlis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euroAlis;

            string euroSatis = xmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = euroSatis;
        }

        private void btnDolarAlis_Click(object sender, EventArgs e)
        {
            txtBoxKur.Text = lblDolarAlis.Text;
        }

        private void btnDolarSatis_Click(object sender, EventArgs e)
        {
            txtBoxKur.Text = lblDolarSatis.Text;
        }

        private void btnEuroAlis_Click(object sender, EventArgs e)
        {
            txtBoxKur.Text = lblEuroAlis.Text;
        }

        private void btnEuroSatis_Click(object sender, EventArgs e)
        {
            txtBoxKur.Text = lblEuroSatis.Text;
        }

        private void btnİslemYap_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;  
            kur = Convert.ToDouble(txtBoxKur.Text);
            miktar = Convert.ToDouble(txtBoxMiktar.Text);
            tutar = kur * miktar;

            txtBoxTutar.Text = tutar.ToString();

        }

        private void txtBoxKur_TextChanged(object sender, EventArgs e)
        {
            txtBoxKur.Text = txtBoxKur.Text.Replace(".", ",");
        }

        private void btnBakiyeyeGore_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar, kalan;
            kur = Convert.ToDouble(txtBoxKur.Text);
            miktar = Convert.ToDouble(txtBoxMiktar.Text);
            tutar = miktar / kur;
            kalan = miktar % kur;
            txtBoxTutar.Text = tutar.ToString();

            txtBoxKalan.Text = kalan.ToString();

        }
    }
}
