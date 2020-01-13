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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB5B
{   /// <summary>
    /// Main form contins logic for Reading and Showing data Approproately As per Combo box value selection 
    /// </summary>
    public partial class Form1 : Form
    {
        //Lists to store the data
        List<Doctor> doctors = new List<Doctor>();
        List<Companion> companions = new List<Companion>();
        List<Episode> episodes = new List<Episode>();
        /// <summary>
        /// Form Initialzation and setting defalut values for the  varialbes
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 1;
        }

        /// <summary>
        /// Exit button Activity ; Exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Logic contains for the opening file and Readig file
        /// Store data appropriately in lists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                String line;
                                                          
                // Displays an OpenFileDialog so the user can select a Cursor.  
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = ".txt Files|*.txt";
                openFileDialog1.Title = "Select a Text File";

                // Show the Dialog.  
                // If the user clicked OK in the dialog and  
                // a .CUR file was selected, open it.  
                if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    System.IO.StreamReader file = new
                    System.IO.StreamReader(openFileDialog1.FileName);
                    //MessageBox.Show(file.ReadToEnd());
                    while ((line = file.ReadLine()) != null)
                    { //spliting each line and store data in list
                        
                        string[] exploded = line.Split('|');

                        if (exploded[0].Trim() == "D")
                        {
                            doctors.Add(new Doctor(Convert.ToInt32(exploded[1].Trim()), exploded[2].Trim(), Convert.ToInt32(exploded[3].Trim()), Convert.ToInt32(exploded[4].Trim()), exploded[5].Trim()));
                        }

                        if (exploded[0].Trim() == "C")
                        {
                            companions.Add(new Companion(exploded[1].Trim(), exploded[2].Trim(), Convert.ToInt32(exploded[3].Trim()), exploded[4].Trim()));
                        }

                        if (exploded[0].Trim() == "E")
                        {
                            episodes.Add(new Episode(exploded[1].Trim(), Convert.ToInt32(exploded[2].Trim()), Convert.ToInt32(exploded[3].Trim()), exploded[4].Trim()));
                        }

                    }
                                     
                    file.Close(); //it's always good to close the file after operation
                                     
                    comboBox1.SelectedIndex = 0; //after reading file set index to 0
                                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Logic contains if the combo box index changes
        /// it does operation on stored list data
        /// on which LINQ operation is also used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //clearing the data containers before chnaging the data into them
            showDataListBox.Items.Clear();
            yearTextBox.Text = placedByTextBox.Text = seriesTextBox.Text = ageTextBox.Text =
                firstEpisodeTextBox.Text = String.Empty;
            
            //query to fetch doctor's data
            var query = (from doc in doctors
                         where doc.Ordinal.Equals(comboBox1.SelectedIndex)
                         select doc).ToList();

            //seting doctor's data to the right side group box
            foreach (var j in query)
            {
                
                yearTextBox.Text = j.Ordinal.ToString();
                
                placedByTextBox.Text = j.Actor.ToString();
                
                seriesTextBox.Text = j.Series.ToString();
                
                ageTextBox.Text = j.Age.ToString();
                
            }

            //query for getting data of episode and copanions
            var query1 = (from doc in doctors
                          join comp in companions
                          on doc.Debut equals comp.Debut
                          join epi in episodes
                          on comp.Debut equals epi.Story                   
                          where (doc.Ordinal.Equals(comboBox1.SelectedIndex) || comp.Doctor.Equals(comboBox1.SelectedIndex))
                          //doc.Ordinal.Equals(comp.Doctor))
                          select new { episodeName = comp.Name , Act = comp.Actor , titleOfPlay = epi.Title , yearOfPlay = epi.Year }).ToList();
            
            //sort list according to the year of the episode
            query1 = query1.OrderBy(x => x.Act).ToList();


            //adding data to the right hand side list box
            foreach(var i in query1)
            {
                firstEpisodeTextBox.Text = i.titleOfPlay.ToString();
                showDataListBox.Items.Add(String.Format($" {i.episodeName.ToString()} ({i.Act.ToString()}) "));
                showDataListBox.Items.Add(String.Format($" \" {i.titleOfPlay.ToString()} \"  ({i.yearOfPlay.ToString()})  "));
                
            }
            

        }

    }
}

