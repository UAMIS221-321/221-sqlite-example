using sql_lite_example;

CarDatabase db = new CarDatabase();

db.CheckDbVersion();

db.CreateTable();

db.AddCar("BMW", 2020);
db.AddCar("Audi", 2019);
db.AddCar("Mercedes", 2018);


Car[] cars = new Car[100];
int count = db.ReadCars(cars);
PrintCars(cars, count);

cars[0].SetModel("Toyota");

db.UpdateCar(cars[0]);


count = db.ReadCars(cars);
PrintCars(cars, count);


static void PrintCars(Car[] cars, int count){
    for(int i = 0; i < count; i++){
        System.Console.WriteLine(cars[i].ToString());
    }
}