/*
 * I, CHIRAG BARANDA, student number 000759867, 
 * certify that all code submitted is my own work; 
 * that I have not copied it from any other source.  
 * I also certify that I have not allowed my work to be copied by others.
 * 
 * Author: Chirag Baranda
 * Student Number: 000759867
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB5B
{
       /// <summary>
       /// prototype of Episode class
       /// </summary>
    class Episode
    {
        //Setting properties
        public string Story { get; }
        public int Season { get; }
        public int Year { get; }
        public string Title { get; }


        /// <summary>
        /// Constructr of Episode
        /// </summary>
        /// <param name="story"></param>
        /// <param name="season"></param>
        /// <param name="year"></param>
        /// <param name="title"></param>
        public Episode(string story, int season, int year, string title)
        {
            this.Story = story;
            this.Season = season;
            this.Year = year;
            this.Title = title;
        }

        public override string ToString() => $"{Story,-20}  {Season,-3}  {Year,-3}  {Title,-5}";
    }
}
