using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentAPI.Models; 
public class PaymentDetail {
    [Key]
    public int PaymentDetailId { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string CardOwnerName { get; set; } = null!;
    [Column(TypeName = "nvarchar(16)")]
    public string CardNumber { get; set; } = null!;

    // mm/yy format
    [Column(TypeName = "nvarchar(5)")]
    public string ExpirationDate { get; set; } = null!;

    [Column(TypeName = "nvarchar(3)")]
    public string SecurityCode { get; set; } = null!;    // CVV
}
