using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalFootballLeague
{
    internal class Team
    {
        public int TeamId { get; set; }               
        public string TeamName { get; set; }         
        public string City { get; set; }              
        public string Stadium { get; set; }            
        public int FoundedYear { get; set; }          
        public string Coach { get; set; }           

        // Statistik göstəricilər
        public int Wins { get; set; }                 
        public int Draws { get; set; }                
        public int Losses { get; set; }             
        public int GoalsFor { get; set; }             
        public int GoalsAgainst { get; set; }        

        // Hesablanan dəyərlər
        public int Played => Wins + Draws + Losses;   
        public int GoalDifference => GoalsFor - GoalsAgainst;  
        public int Points => Wins * 3 + Draws;
    }
}
