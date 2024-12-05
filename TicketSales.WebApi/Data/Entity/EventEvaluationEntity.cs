using Aware.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicketSales.WebApi.Data.Entity
{
    public class EventEvaluationEntity : BaseEntity
    {
        public string Evaluator { get; set; }
        public string Comments { get; set; }
        public int Point { get; set; }

        [ForeignKey("Event")]
        public long EventId { get; set; }

        //Ref
        public virtual EventEntity Event { get; set; }
    }
}
