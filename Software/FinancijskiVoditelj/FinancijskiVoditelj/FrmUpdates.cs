using FinancijskiVoditelj.Models;
using FinancijskiVoditelj.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancijskiVoditelj
{
    public partial class FrmUpdates : Form
    {
        private Cost cost;
        private List<string> categories;
        private List<string> types;
        public FrmUpdates(Cost selectedCost)
        {
            InitializeComponent();
            cost = selectedCost;
        }

        private void FrmUpdates_Load(object sender, EventArgs e)
        {
            if (cost != null) {
                
                categories = CostRepository.GetCategories();
                
               // types = CostRepository.GetTypes(string categoryName);


                categories.Add(cost.CategoryName);
            //    types.Add(cost.TypeName);

 
                cboCategory.DataSource = categories;
                cboType.DataSource = types;

                txtDescription.Text = cost.Description;
                txtPrice.Text = cost.Price.ToString();
                txtDate.Text = cost.Date.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cost != null)
            {

                string newCategory = cboCategory.SelectedItem.ToString();
                string newType = cboType.SelectedItem.ToString();
                string newDescription = txtDescription.Text;
                int newPrice = int.Parse(txtPrice.Text);
                DateTime newDate = DateTime.Parse(txtDate.Text);

                CostRepository.UpdateCost(cost, newCategory, newType, newDescription, newPrice, newDate);
                MessageBox.Show("Uspješno ste ažurirali trošak!", "Obavijest", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.SelectedItem != null)
            {
                string selectedCategory = cboCategory.SelectedItem.ToString();
                types = CostRepository.GetTypes(selectedCategory);
                cboType.DataSource = types;
            }
        }
    }
}
