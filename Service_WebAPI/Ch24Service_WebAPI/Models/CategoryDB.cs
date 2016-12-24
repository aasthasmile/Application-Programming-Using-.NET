using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// be sure to include these using directives
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel;

public class CategoryDB
{
    public List<Category> GetCategories()
    {
        List<Category> categoryList = new List<Category>();
        string sql = "SELECT CategoryID, ShortName, LongName "
            + "FROM Categories "
            + "ORDER BY LongName";
        using (SqlConnection con = new SqlConnection(GetConnectionString())) {
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Category category;
                while (dr.Read()) {
                    category = new Category();
                    category.CategoryID = dr["CategoryID"].ToString();
                    category.ShortName = dr["ShortName"].ToString();
                    category.LongName = dr["LongName"].ToString();
                    categoryList.Add(category);
                }
                dr.Close();
            }
        }
        return categoryList;
    }

    public Category GetCategoryById(string id)
    {
        Category category = new Category();
        string sql = "SELECT CategoryID, ShortName, LongName "
            + "FROM Categories "
            + "WHERE CategoryID = @CategoryID "
            + "ORDER BY LongName";
        using (SqlConnection con = new SqlConnection(GetConnectionString())) {
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("CategoryID", id);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read()) {
                    category = new Category();
                    category.CategoryID = dr["CategoryID"].ToString();
                    category.ShortName = dr["ShortName"].ToString();
                    category.LongName = dr["LongName"].ToString();
                }
                dr.Close();
            }
        }
        return category;
    }

    public IEnumerable<Category> GetCategoriesByShortName(string name)
    {
        List<Category> categoryList = new List<Category>();
        string sql = "SELECT CategoryID, ShortName, LongName "
            + "FROM Categories "
            + "WHERE ShortName = @ShortName"
            + "ORDER BY LongName";
        using (SqlConnection con = new SqlConnection(GetConnectionString())) {
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("ShortName", name);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                Category category;
                while (dr.Read()) {
                    category = new Category();
                    category.CategoryID = dr["CategoryID"].ToString();
                    category.ShortName = dr["ShortName"].ToString();
                    category.LongName = dr["LongName"].ToString();
                    categoryList.Add(category);
                }
                dr.Close();
            }
        }
        return categoryList;
    }

    public int InsertCategory(Category category)
    {
        System.Threading.Thread.Sleep(3000);
        string sql = "INSERT INTO Categories "
            + "(CategoryID, ShortName, LongName) "
            + "VALUES (@CategoryID, @ShortName, @LongName)";
        using (SqlConnection con = new SqlConnection(GetConnectionString())) {
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("ShortName", category.ShortName);
                cmd.Parameters.AddWithValue("LongName", category.LongName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public int DeleteCategory(Category category)
    {
        string sql = "DELETE FROM Categories "
            + "WHERE CategoryID = @CategoryID";
        using (SqlConnection con = new SqlConnection(GetConnectionString())) {
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("CategoryID", category.CategoryID);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

    public int UpdateCategory(Category category)
    {
        string sql = "UPDATE Categories "
            + "SET ShortName = @ShortName, "
            + "LongName = @LongName "
            + "WHERE CategoryID = @CategoryID";
        using (SqlConnection con = new SqlConnection(GetConnectionString())) {
            using (SqlCommand cmd = new SqlCommand(sql, con)) {
                cmd.Parameters.AddWithValue("CategoryID", category.CategoryID);
                cmd.Parameters.AddWithValue("ShortName", category.ShortName);
                cmd.Parameters.AddWithValue("LongName", category.LongName);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }

    private string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings
            ["HalloweenConnection"].ConnectionString;
    }

}
