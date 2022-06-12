﻿using System;
using System.Collections.Generic;

#nullable disable

namespace kolokwium.Models
{
    public partial class MusicianTrack
    {
        public int MusicianIdMusician { get; set; }
        public int TrackIdTrack { get; set; }

        public virtual Musician MusicianIdMusicianNavigation { get; set; }
        public virtual Track TrackIdTrackNavigation { get; set; }
    }
}
