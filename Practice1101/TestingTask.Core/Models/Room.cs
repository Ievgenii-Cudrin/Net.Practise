namespace TestingTask.Core.Models
{
    public class Room
    {
        public int Capacity { get; set; }

        public Group BookedBy { get; set; }
    }
}