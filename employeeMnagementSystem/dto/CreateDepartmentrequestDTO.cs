namespace WebApplication1.dto
{
    public class CreateDepartmentrequestDTO
    {
        public int DepartmentId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public string? Location { get; set; }

        public string? Depatment_Manager { get; set; }
    }
}
