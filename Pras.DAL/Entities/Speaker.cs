using System;
using Pras.Shared.Enums;

namespace Pras.DAL.Entities
{
    public class Speaker : Entity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Summary { get; set; }
        public string Image { get; set; }
        
        public string Demo { get; set; }
        public string DemoAdvertising { get; set; }
        public string DemoVoiceOver { get; set; }

        public SpeakerTypes Type { get; set; }
        public string VoiceDescription { get; set; }
        public string Params { get; set; }
        public VoiceAge VoiceAge { get; set; }

        public string Price30 { get; set; }
        public string Price90 { get; set; }
        public string PricePage { get; set; }
        public Currency Currency { get; set; }
        public PriceCategory PriceCategory { get; set; }
        public int Rating { get; set; }
        public string WorkingHours { get; set; }
        public string WorkingDays { get; set; }
        public DateTime VacationStartDate { get; set; }
        public DateTime VacationEndDate { get; set; }

        public string Languages { get; set; }
        public string Voices { get; set; }
        public string WorkTypes { get; set; }
        public string Industries { get; set; }
        public string Portfolio { get; set; }

        public float Terms { get; set; }
        public Gender Gender { get; set; }
        public bool CanDirect { get; set; }

        public string Comment { get; set; }
        public string Videos { get; set; }

        public string Nationality { get; set; }
        public string Country { get; set; }
        public SpeakerStatuses Status { get; set; }
        public bool IsNovelty { get; set; }
        public bool IsVip { get; set; }
        public DateTime Created { get; set; }
    }
}
