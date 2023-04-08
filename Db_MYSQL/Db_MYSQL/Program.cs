using MySql.Data.MySqlClient;
using System;

namespace Db_MYSQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MySqlDataReader result;
            string resultInfo;
            int numberProduct;
            string nameProduct;
            int idUser;
            string nameUser;

            Console.WriteLine("SELECT USERS");
            Query mesRequetes = new Query();
            result = mesRequetes.SelectUser();
            
            while (result.Read())
            {
                Console.WriteLine(result["name"].ToString());
            }
            resultInfo = mesRequetes.DeleteProduct();
            Console.WriteLine(resultInfo);

            Console.WriteLine("Entrer le number de votre produit :");
            numberProduct = int.Parse(Console.ReadLine());
            Console.WriteLine("Entrer le nom de votre produit :");
            nameProduct = Console.ReadLine();

            resultInfo = mesRequetes.AddProduct(numberProduct, nameProduct);
            Console.WriteLine(resultInfo);

            Console.WriteLine("Entrer l'id de l'utilisateur pour modifier son nom :");
            idUser = int.Parse(Console.ReadLine());

            Console.WriteLine("Entrer le nouveau nom de l'utilisateur :");
            nameUser = Console.ReadLine();

            resultInfo = mesRequetes.ModifNameUserById(nameUser, idUser);

            Console.WriteLine(resultInfo);


            Console.ReadLine();
        }
    }
}
