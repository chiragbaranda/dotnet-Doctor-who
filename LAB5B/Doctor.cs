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
    /// Doctor Class to make Prototype of data of Doctor
    /// </summary>
    class Doctor
    {
        //setting property for given Data type

        /// <summary>
        /// Ordinal is an doctor's number
        /// </summary>
        public int Ordinal { get; set; }
        /// <summary>
        /// name of the actor
        /// </summary>
        public String Actor { get; }
        /// <summary>
        /// name of the series
        /// </summary>
        public int Series { get; }

        /// <summary>
        /// age of an docor
        /// </summary>
        public int Age { get; }

        /// <summary>
        /// debut number
        /// </summary>
        public string Debut { get; }

        /// <summary>
        /// Constructo for Doctor
        /// </summary>
        /// <param name="ordinal">ordinal number</param>
        /// <param name="actor"> Name of actor</param>
        /// <param name="series">name of series</param>
        /// <param name="age">age of doctor</param>
        /// <param name="debut">debut number</param>
        public Doctor(int ordinal, string actor, int series, int age, string debut)
        {
            this.Ordinal = ordinal;
            this.Actor = actor;
            this.Series = series;
            this.Age = age;
            this.Debut = debut;
        }

        /// <summary>
        /// overrided tostring method
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Ordinal,5}  {Actor:-20}  {Series,-5}  {Age,3}  {Debut,-5}";
    }
}
