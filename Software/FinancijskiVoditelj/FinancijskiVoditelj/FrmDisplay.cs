using DBLayer;
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
    public partial class FrmDisplay : Form
    {
        private List<string> categories;
        private Cost cost;
        public FrmDisplay()
        {
            InitializeComponent();
            DB.SetConfiguration("IPS23_kkurtanje21", "kkurtanje21", "0Y&2qo/]");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmAddCost frmAddCost = new FrmAddCost();
            if (frmAddCost.ShowDialog() == DialogResult.OK)
            {
                dgvCosts.Refresh();
                ShowCosts();

            }
          

            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Cost selectedCost = dgvCosts.CurrentRow.DataBoundItem as Cost;
            if (selectedCost != null)
            {
                FrmUpdates frmUpdates = new FrmUpdates(selectedCost);
                frmUpdates.ShowDialog();

                dgvCosts.Refresh();
            }


        }

        private void FrmDisplay_Load(object sender, EventArgs e)
        {
            categories = CostRepository.GetCategories();
            cboSearch.DataSource = categories;
            ShowCosts();
           
        }
        private void ShowCosts()
        {
            List<Cost> costs = CostRepository.GetCosts();
            dgvCosts.DataSource = costs;

            dgvCosts.Columns["id"].DisplayIndex = 7;
            dgvCosts.Columns["CategoryCost"].DisplayIndex = 0;
            dgvCosts.Columns["categoryName"].DisplayIndex = 1;
             dgvCosts.Columns["TypeCost"].DisplayIndex = 2;
            dgvCosts.Columns["typeName"].DisplayIndex = 3;
            dgvCosts.Columns["description"].DisplayIndex = 6;
            dgvCosts.Columns["price"].DisplayIndex = 4;
            dgvCosts.Columns["date"].DisplayIndex = 5;

        }
 
  


        private void btnDelete_Click(object sender, EventArgs e)
        {
            Cost selectedCost = dgvCosts.CurrentRow.DataBoundItem as Cost;
            CostRepository.RemoveCost(selectedCost);
            MessageBox.Show("Obrisan je označeni trošak!","Obavijest",MessageBoxButtons.OK, MessageBoxIcon.Information);
            List<Cost> costs = CostRepository.GetCosts();
            dgvCosts.DataSource = costs;

            dgvCosts.Refresh();
        }

        private void cboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cboSearch.SelectedItem.ToString();
            List<Cost> searchedCosts = CostRepository.GetCostsByCategory(selectedCategory);
            dgvCosts.DataSource = searchedCosts;
        }

        private void txtSearchType_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSearchType.Text.Trim();
            List<Cost> filteredCosts = CostRepository.FilterDataBySearchText(searchText);
            dgvCosts.DataSource= filteredCosts;
        }
    }
}
