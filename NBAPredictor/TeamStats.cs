using System;
using System.Collections.Generic;
using System.Text;

namespace NBAPredictor
{
    public class TeamStats : IFreeThrowToFieldGoalCalcuable 
    {
        public string Name { get; set; }
        public DateTime ImportDate { get; set; }
        public decimal DefensiveRating { get; set; }
        public decimal DefensiveRatingAway { get; set; }
        public decimal DefensiveRatingHome { get; set; }
        public decimal DistanceTraveled { get; set; }
        public decimal FieldGoal { get; set; }
        public decimal FieldGoalAway { get; set; }
        public decimal FieldGoalHome { get; set; }
        public decimal WinLastSeven { get; set; }
        public decimal WinLastSevenAway { get; set; }
        public decimal WinLastSevenHome { get; set; }
        public decimal AttemptedFreeThrowsToFieldGoals { 
            get {
                    if (AttemptedFieldGoals == 0) throw new InvalidOperationException("Games with zero attempted field goals are not supported.");
                    return AttemptedFreeThrows / AttemptedFieldGoals; 
                } 
        }
        public decimal FreeThrowsToFieldGoalsAway
        {
            get
            {
                if (AttemptedFieldGoalsAway == 0) throw new InvalidOperationException("Games with zero attempted field goals are not supported.");
                return AttemptedFreeThrowsAway / AttemptedFieldGoalsAway;
            }
        }
        public decimal FreeThrowsToFieldGoalsHome
        {
            get
            {
                if (AttemptedFieldGoalsHome == 0) throw new InvalidOperationException("Games with zero attempted field goals are not supported.");
                return AttemptedFreeThrowsHome / AttemptedFieldGoalsHome;
            }
        }
        public decimal AttemptedFreeThrows { get; set; }
        public decimal AttemptedFreeThrowsAway { get; set; }
        public decimal AttemptedFreeThrowsHome { get; set; }
        public decimal AttemptedFieldGoals { get; set; }
        public decimal AttemptedFieldGoalsAway { get; set; }
        public decimal AttemptedFieldGoalsHome { get; set; }
        public decimal OffensiveRating { get; set; }
        public decimal OffensiveRatingAway { get; set; }
        public decimal OffensiveRatingHome { get; set; }
        public decimal OffensiveRebound { get; set; }
        public decimal OffensiveReboundAway { get; set; }
        public decimal OffensiveReboundHome { get; set; }
        public decimal Turnover { get; set; }
        public decimal TurnoverAway { get; set; }
        public decimal TurnoverHome { get; set; }

    }
}
