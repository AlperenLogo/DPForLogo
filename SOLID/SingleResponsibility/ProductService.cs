namespace SingleResponsibility
{
    public class ProductService
    {

        // responsibility <==> object (multiple job....)
        public int AddProduct(string name, decimal price)
        {
            var connection = "Data Source=(localdb)\\Mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True";
            var Command = "INSERT into Products (ProductName, UnitPrice) values (@name,@price)";

            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@name", name);
            parameters.Add("@price", price);

            var rows = new SqlHelper(connection).Execute(Command, parameters);

            return rows;
        }

        public int UpdateProduct(string name)
        {
            return 1;
        }

        public void DeleteProduct()
        {
            //function <==> job
        }

    }
}
