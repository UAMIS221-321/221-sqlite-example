using System.Data.SQLite;

namespace sql_lite_example{
    public class CarDatabase{
        
        private string cs = @"URI=file:car.db";
        SQLiteConnection con;

        public CarDatabase(){
            con = new SQLiteConnection(cs);
        }

        public void CheckDbVersion(){
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = @"SELECT SQLITE_VERSION()";
            string version = cmd.ExecuteScalar().ToString();
            System.Console.WriteLine($"SQLite version: {version}");
            con.Close();
        }

        public void CreateTable(){
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);

            // Remove the table if it exists
            cmd.CommandText = "DROP TABLE IF EXISTS books";
            cmd.ExecuteNonQuery();

            // Creates the cars table
            cmd.CommandText = @"
                CREATE TABLE cars(
                        id INTEGER PRIMARY KEY, 
                        model TEXT, 
                        year INTEGER
                    )";

            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void AddCar(Car car){
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "INSERT INTO cars (model, year) VALUES (@model, @year)";
            cmd.Parameters.AddWithValue("@model", car.GetModel());
            cmd.Parameters.AddWithValue("@year", car.GetYear());
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public Car[] ReadCars(){
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "SELECT * FROM cars";

            int count = 0;
            Car[] cars = new Car[100];

            using(SQLiteDataReader rdr = cmd.ExecuteReader()){
                while(rdr.Read()){
                    cars[count] = new Car(rdr.GetInt32(0), rdr.GetString(1), rdr.GetInt32(2));
                    count++;
                }
            }
            con.Close();

            return cars;
        }

        public void UpdateCar(Car car){
            con.Open();
            SQLiteCommand cmd = new SQLiteCommand(con);
            cmd.CommandText = "UPDATE cars SET model = @model, year = @year WHERE id = @id";
            cmd.Parameters.AddWithValue("@model", car.GetModel());
            cmd.Parameters.AddWithValue("@year", car.GetYear());
            cmd.Parameters.AddWithValue("@id", car.GetId());
            cmd.Prepare();
            cmd.ExecuteNonQuery();
            con.Close();
        }

    }
}