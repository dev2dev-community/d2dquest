using System;

namespace D2DQuest.ObjectDomain
{
    public class WordRegistration
    {
        public int Id { get; set; }

        public DateTime Time { get; set; }

        public virtual KeyWord Word { get; set; }

        public virtual Visiter Visiter { get; set; }
    }
}