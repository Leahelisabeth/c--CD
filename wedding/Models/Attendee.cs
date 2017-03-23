using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace wedding.Models

{
    public class Attendee: BaseEntity
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Guest of...")]
        public string GuestOf {get; set;}

        public Event Event {get; set;}
        public int EventId {get; set;}
    }
}