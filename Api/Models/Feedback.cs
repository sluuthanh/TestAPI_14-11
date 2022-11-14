using System;
using System.Collections.Generic;

#nullable disable

namespace Api.Models
{
    public partial class Feedback
    {
        public int FeedbackId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
    }
}
