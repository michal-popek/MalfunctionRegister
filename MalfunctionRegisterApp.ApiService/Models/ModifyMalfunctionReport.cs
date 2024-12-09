using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MalfunctionRegisterApp.ApiService.Models
{
    public class ModifyMalfunctionReport : AddMalfunctionReport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
