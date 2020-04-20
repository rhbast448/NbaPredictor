namespace NBAPredictor
{
    public interface IFreeThrowToFieldGoalCalcuable
    {
        public decimal AttemptedFreeThrowsToFieldGoals { get; }
        public decimal FreeThrowsToFieldGoalsHome { get; }
        public decimal FreeThrowsToFieldGoalsAway { get; }
    }
}