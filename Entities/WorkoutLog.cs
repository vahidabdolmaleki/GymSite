namespace Entities
{
    // 🔹 تمرینات انجام شده
    public class WorkoutLog : BaseEntity
    {
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }

        public int PersonId { get; set; }
        public Person Person { get; set; }

        public DateTime Date { get; set; }
        public bool Completed { get; set; }
    }
}






