namespace sql_lite_example{
    public class Car{
        public int id; 
        public string model; 
        public int year;

        public Car(int id, string model, int year)
        {
            this.id = id;
            this.model = model;
            this.year = year;
        }

        public Car() {}

        public int GetId(){
            return id;
        }

        public void SetId(int id){
            this.id = id;
        }

        public string GetModel(){
            return model;
        }
        public void SetModel(string model){
            this.model = model;
        }

        public int GetYear(){
            return year;
        }
        public void SetYear(int year){
            this.year = year;
        }

        public override string ToString()
        {
            return $"Car: {id}, {model}, {year}";
        }
    }
}