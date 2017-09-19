using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MembershipSystem.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ReservationStart { get; set; }
        public DateTime ReservationEnd { get; set; }
        public string PlayingField { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        [ForeignKey(nameof(Activity))]
        public int ActivityId { get; set; }
        public virtual User User { get; set; }
        public virtual Activity Activity { get; set; }
    }
}