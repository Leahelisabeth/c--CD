using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace wedding.Models

{
    public class Event : BaseEntity
    {
        [Key]
        public int id { get; set; }
        [RequiredAttribute]
        public List<Attendee> Attendees { get; set; }
        public string Spouse { get; set; }//
        public string SpouseTitle { get; set; }//
        public string SndSpouse { get; set; }//
        public string SndSpouseTitle { get; set; }//
        public DateTime WedDay { get; set; }//
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}