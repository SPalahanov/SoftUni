﻿using StreamProgress.Models.Interfaces;

namespace StreamProgress.Models
{
    public class Music : IStreamType
    {
        private string artist;
        private string album;

        public Music(string artist, string album, int length, int bytesSent)
        {
            this.artist = artist;
            this.album = album;
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length { get; set; }

        public int BytesSent { get; set; }

        public override string ToString()
        {
            return $"Artist: {this.artist}, Album: {this.album}, Length: {Length}, BytesSent: {BytesSent}";
        }
    }
}
