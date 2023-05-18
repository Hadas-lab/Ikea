using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Data { get; set; }

        public int Sum { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();

    }
}
