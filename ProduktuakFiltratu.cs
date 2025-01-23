using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2taldea
{
    public partial class ProduktuakFiltratu : Form
    {
        private readonly Action<string> aplicarFiltro;

        public ProduktuakFiltratu(Action<string> aplicarFiltro)
        {
            InitializeComponent();
            this.aplicarFiltro = aplicarFiltro;
        }

        private void btnPrezioa_Click(object sender, EventArgs e)
        {
            aplicarFiltro("Prezioa");
            this.Close();
        }

        private void btnStocka_Click(object sender, EventArgs e)
        {
            aplicarFiltro("Stocka");
            this.Close();
        }
    }
}