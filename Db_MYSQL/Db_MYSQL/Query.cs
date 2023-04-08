using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using MySql.Data.MySqlClient;


namespace Db_MYSQL
{
    internal struct Query
    {
        public string DefinirChemin()
        {
            return "Server=localhost;User Id=root;password=;Database=dbvisualstudio;Port=3306";
        }


        public MySqlDataReader SelectUser()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string querySelectUser = "SELECT * FROM users WHERE idUser = 1";
                MySqlCommand command = new MySqlCommand(querySelectUser, connection);
                connection.Open();
                MySqlDataReader reader = command.ExecuteReader();
                return reader;
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
        }

        public string DeleteProduct()
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string queryDeleteProduct = "DELETE FROM product where idProduct = 3";
                MySqlCommand command = new MySqlCommand(queryDeleteProduct, connection);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }
            return "Votre produit à bien été supprimer !";
        }

        public string AddProduct(int number, string nameProduct)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string queryAddProduct = "INSERT INTO product (number,nameProduct) values(@number,@nameProduct)";
                MySqlCommand command = new MySqlCommand(queryAddProduct, connection);
                command.Parameters.AddWithValue("@number", number);
                command.Parameters.AddWithValue("@nameProduct", nameProduct);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

            return "Votre produit à bien été ajouté dans la base de données";
        }

        public string ModifNameUserById(string name,int userId)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(DefinirChemin());
                string queryNameModif = "UPDATE users SET name = @name WHERE idUser = @userId";
                MySqlCommand command = new MySqlCommand(queryNameModif, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@userId", userId);

                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                throw;
            }

            return "Le nom de l'utilisateur à bien été modifié !";
        }


    }
}
