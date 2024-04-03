using System.Data.SQLite;

namespace sql_lite_example{
    public class CarDatabase{
        
        private string cs = @"URI=file:car.db";
        SQLiteConnection con;

        public CarDatabase(){
            con = new SQLiteConnection(cs);
        }

        public void CheckDbVersion(){
            // Open the connection
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Write the SQL command
            cmd.CommandText = @"SELECT SQLITE_VERSION()";

            // Execute the command
            string version = cmd.ExecuteScalar().ToString();

            // Print the version
            System.Console.WriteLine($"SQLite version: {version}");

            // Close the connection
            con.Close();
        }

        public void CreateTable(){
            // Prepare the connection
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Remove the table if it exists
            cmd.CommandText = "DROP TABLE IF EXISTS cars";
            cmd.ExecuteNonQuery();

            // Creates the cars table
            cmd.CommandText = @"
                CREATE TABLE cars(
                        id INTEGER PRIMARY KEY, 
                        model TEXT, 
                        year INTEGER
                    )";

            // Execute the command
            cmd.ExecuteNonQuery();

            // Close the connection
            con.Close();
        }

        public void AddCar(string model, int year){
            // Prepare the connection
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Write the SQL command
            cmd.CommandText = "INSERT INTO cars (model, year) VALUES (@model, @year)";

            // Add the parameters
            cmd.Parameters.AddWithValue("@model", model);
            cmd.Parameters.AddWithValue("@year", year);

            // Prepare and execute the command
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            // Close the connection
            con.Close();
        }

        public int ReadCars(Car[] cars){
            int count = 0;

            // Prepare the connection
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Write the SQL command
            cmd.CommandText = "SELECT * FROM cars";


            // Execute the command and read the data to the cars array
            using(SQLiteDataReader rdr = cmd.ExecuteReader()){
                while(rdr.Read()){
                    cars[count] = new Car(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                    count++;
                }
            }

            // Close the connection
            con.Close();

            return count;
        }

        public void UpdateCar(Car car){
            // Prepare the connection
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Write the SQL command
            cmd.CommandText = "UPDATE cars SET model = @model, year = @year WHERE id = @id";

            // Add the parameters
            cmd.Parameters.AddWithValue("@model", car.GetModel());
            cmd.Parameters.AddWithValue("@year", car.GetYear());
            cmd.Parameters.AddWithValue("@id", car.GetId());

            // Prepare and execute the command
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            // Close the connection
            con.Close();
        }

    }
}