using FinancijskiVoditelj.Models;
using FinancijskiVoditelj.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancijskiVoditelj
{
    public partial class FrmAddCost : Form
    {
        public bool AddedCost { get; private set; }
        private Cost cost;
        private List<string> categories;
        private List<string> types;
        public FrmAddCost()
        {
            
            InitializeComponent();
        }

        private void FrmAddCost_Load(object sender, EventArgs e)
        {
            categories = CostRepository.GetCategories();
            cboAddCategoryCost.DataSource = categories;
        
        }

        private void btnAddSaveCost_Click(object sender, EventArgs e)
        {
            string categoryCost = (string)cboAddCategoryCost.SelectedItem;
            string typeCost = (string)cboAddTypeCost.SelectedItem;
            string description = txtAddDescriptionCost.Text;
            var price = int.Parse(txtAddPriceCost.Text);
          

            Cost cost = new Cost
            {
                CategoryName = categoryCost,
                TypeName = typeCost,
                Description = description,
                Price = price,
               
            };

            CostRepository.AddCost(cost);

            DialogResult = DialogResult.OK;
            MessageBox.Show("Uspješno ste unijeli trošak!", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Close();
        }

        private void btnAddCancelCost_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboAddCategoryCost_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cboAddCategoryCost.SelectedItem.ToString();
            types = CostRepository.GetTypes(selectedCategory);
            cboAddTypeCost.DataSource = types;
        }
    }
}
