namespace JustTraceExamples
{
    using System;
    using System.Linq;

    public struct Event 
    {
        public Event(int id, int count)
            : this()
        {
            this.Id = id;
            this.Count = count;
        }

        public int Count { get; private set; }
        public int Id { get; private set; }
    }
}