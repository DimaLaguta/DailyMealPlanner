namespace DailyMealPlanner.model.business
{
    public class UserInformation
    {
        private double weight;
        private int age;
        private double height;
        private double bmr;
        private double arm;


        public double Weight
        {
            get { return weight; }
            set { weight = value > 0 ? value : 1; }
        }

        public int Age
        {
            get { return age; }
            set { age = value > 0 ? value : 1; }
        }

        public double Height
        {
            get { return height; }
            set { height = value > 0 ? value : 1; }
        }

        public double Bmr
        {
            get { return bmr; }
            set { bmr = value > 0 ? value : 1; }
        }

        public double Arm
        {
            get { return arm; }
            set { arm = value > 0 ? value : 1; }
        }

        public UserInformation(double weight, int age, double height, double bmr, double arm)
        {
            Weight = weight;
            Age = age;
            Height = height;
            Bmr = bmr;
            Arm = arm;
        }
    }
}