using DBLayer;
using FinancijskiVoditelj.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancijskiVoditelj.Repositories
{
    public class CostRepository
    {

       /// <summary>
       /// Get all costs from database.
       /// </summary>
       /// <returns>List of all costs from database.</returns>
        public static List<Cost> GetCosts()
        {
            List<Cost> costs = new List<Cost>();
            string sql = "SELECT c.*, cat.CategoryName, tc.TypeName " +
                 "FROM Costs c " +
                 "JOIN CategoryCost cat ON c.ID_CategoryCost = cat.ID_CategoryCost " +
                 "JOIN TypeCost tc ON c.ID_TypeCost = tc.ID_TypeCost";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Cost cost = CreateObject(reader);
                costs.Add(cost);

            }
            reader.Close();
            DB.CloseConnection();
            return costs;
        }


        /// <summary>
        /// Create a new object type Cost with entered data.
        /// </summary>
        /// <param name="reader">SqlDataReader object,contains entered data for creating a new object</param>
        /// <returns>New object type Cost</returns>
        private static Cost CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID_Cost"].ToString());
            int categoryCost = int.Parse(reader["ID_CategoryCost"].ToString());
            int typeCost = int.Parse(reader["ID_TypeCost"].ToString());
            string description = reader["Description"].ToString();
            int price = int.Parse(reader["Cost"].ToString());
            DateTime date = (DateTime)reader["Date"];
            string typeName = reader["TypeName"].ToString();
            string categoryName = reader["CategoryName"].ToString();

            var cost = new Cost
            {
                Id = id,
                CategoryCost = categoryCost,
                TypeCost = typeCost,
                Description = description,
                Price = price,
                Date = date,
                TypeName = typeName,
                CategoryName = categoryName


            };
            return cost;
        }

        /// <summary>
        ///Get all cost categories.
        /// </summary>
        /// <returns>List with all cost categories.</returns>
        public static List<string> GetCategories()
        {
            List<string> categoryList = new List<string>();

            string sql = "SELECT DISTINCT CategoryName FROM CategoryCost";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                categoryList.Add(reader["CategoryName"].ToString());
            }
            reader.Close();
            DB.CloseConnection();
            return categoryList;
        }

        /// <summary>
        ///  Retrieve all expense types of the selected category.
        /// </summary>
        /// <param name="categoryName">The selected cost category by which its types are retrieved</param>
        /// <returns></returns>
        public static List<string> GetTypes(string categoryName)
        {
            List<string> typeList = new List<string>();
            string sql = $"SELECT tc.TypeName FROM TypeCost tc " +
                         $"JOIN CategoryCost cc ON tc.ID_CategoryCost = cc.ID_CategoryCost " +
                         $"WHERE cc.CategoryName = '{categoryName}'";

            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                typeList.Add(reader["TypeName"].ToString());
            }
            reader.Close();
            DB.CloseConnection();

            return typeList;
        }




        /// <summary>
        /// Update the marked cost. Change the cost values according to the entered data.
        /// </summary>
        /// <param name="cost">The cost to update</param>
        /// <param name="newCategory">The updated expense category</param>
        /// <param name="newType">Updated expense type</param>
        /// <param name="newDescription">Updated cost description</param>
        /// <param name="newPrice">The updated cost amount</param>
        /// <param name="newDate">Updated cost date</param>
        public static void UpdateCost(Cost cost, string newCategory, string newType, string newDescription, int newPrice, DateTime newDate)
        {
            string sql = $"UPDATE Costs " +
                         $"SET ID_CategoryCost = (SELECT ID_CategoryCost FROM CategoryCost WHERE CategoryName = '{newCategory}'), " +
                         $"    ID_TypeCost = (SELECT ID_TypeCost FROM TypeCost WHERE TypeName = '{newType}'), " +
                         $"    Description = '{newDescription}', " +
                         $"    Cost = {newPrice}, " +
                         $"    Date = '{newDate.ToString("yyyy-MM-dd")}' " +
                         $"WHERE ID_Cost = {cost.Id}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();

            cost.CategoryName = newCategory;
            cost.TypeName = newType;
            cost.Description = newDescription;
            cost.Price = newPrice;
            cost.Date = newDate;
        }


        /// <summary>
        /// Retrieve all costs according to the selected cost category.
        /// </summary>
        /// <param name="categoryName">The name of the category according to which the cost filter is made.</param>
        /// <returns>A list of costs according to the selected cost category.</returns>
        public static List<Cost> GetCostsByCategory(string categoryName)
        {
            List<Cost> searchedCosts = new List<Cost>();
            string sql = $"SELECT c.ID_Cost, cc.CategoryName, tc.TypeName, c.Description, c.Cost, c.Date, c.ID_CategoryCost, c.ID_TypeCost " +
                         $"FROM Costs c " +
                         $"JOIN CategoryCost cc ON c.ID_CategoryCost = cc.ID_CategoryCost " +
                         $"JOIN TypeCost tc ON c.ID_TypeCost = tc.ID_TypeCost " +
                         $"WHERE cc.CategoryName LIKE '%{categoryName}%'";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Cost searchedCost = CreateObject(reader);
                searchedCosts.Add(searchedCost);
            }
            reader.Close();
            DB.CloseConnection();
            return searchedCosts;
        }


        /// <summary>
        /// Cost search according to the entered word of the user
        /// </summary>
        /// <param name="searchText">Text entered by the user, based on which the database is searched</param>
        /// <returns> Returns a list of costs that have the cost type entered in searchText</returns>
        public static List<Cost> FilterDataBySearchText(string searchText)
        {
            List<Cost> filteredCosts = new List<Cost>();

            if (!string.IsNullOrEmpty(searchText))
            {
                List<Cost> allCosts = CostRepository.GetCosts();

                filteredCosts = allCosts.Where(cost =>
                    cost.TypeName.IndexOf(searchText, StringComparison.OrdinalIgnoreCase) >= 0
                ).ToList();
            }
            else filteredCosts = CostRepository.GetCosts();

            return filteredCosts;
        }

        /// <summary>
        /// Add a new cost to the database according to the data entered in the form.
        /// </summary>
        /// <param name="cost">The cost object, contains information about the new cost</param>
        public static void AddCost(Cost cost)
        {
            string getCategoryCostIdSql = $"SELECT ID_CategoryCost FROM CategoryCost WHERE CategoryName = '{cost.CategoryName}'";
            string getTypeCostIdSql = $"SELECT ID_TypeCost FROM TypeCost WHERE TypeName = '{cost.TypeName}'";

            string sql = $"INSERT INTO Costs (ID_CategoryCost, ID_TypeCost, Description, Cost, Date) " +
              $"VALUES (({getCategoryCostIdSql}), ({getTypeCostIdSql}), '{cost.Description}', {cost.Price}, GETDATE())";


            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();


        }

        /// <summary>
        /// Delete the marked cost from the database.
        /// </summary>
        /// <param name="cost">The cost object, contains data about the cost to be deleted</param>
        public static void RemoveCost(Cost cost)
        {
            string sql = $"DELETE FROM Costs WHERE ID_Cost = {cost.Id}";

            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
