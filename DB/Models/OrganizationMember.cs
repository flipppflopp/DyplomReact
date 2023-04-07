using System.ComponentModel.DataAnnotations;

namespace DB.Models
{
    public class OrganizationMember
    {
        [Key]
        public int ID { get; set; }
        
        public int OrganizationID { get; set; }
        
        public int VolonteerInfoID { get; set; }
    }
}