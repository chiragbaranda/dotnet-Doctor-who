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
    /// Prototype of Companion Class
    /// </summary>
    class Companion
    {
        //Properties
        public string Name { get; }
        public string Actor { get; }
        public int Doctor { get; }
        public string Debut { get; }

        /// <summary>
        /// Constructor for companion
        /// </summary>
        /// <param name="name">name of companion</param>
        /// <param name="actor">name of actor</param>
        /// <param name="doctor">name of doctor</param>
        /// <param name="debut">name of debut</param>
        public Companion(string name, string actor, int doctor, string debut)
        {
            this.Name = name;
            this.Actor = actor;
            this.Doctor = doctor;
            this.Debut = debut;
        }

        /// <summary>
        /// overrided tostring method
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name,-20}  {Actor:-20}  {Doctor,-3}  {Debut,-5}";
    }
}
