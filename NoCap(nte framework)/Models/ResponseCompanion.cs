using System.Collections.Generic;

namespace Alexeev.Models
{
    public class ResponseCompanion
    {
        public Companion Answer { get; set; }
        public List<Companion> Context { get; set; }
    }
}
