using FluentValidation;

namespace NBAPredictor
{
    public class OffensiveReboundStatsValidator : AbstractValidator<HtmlAgilityPack.HtmlNode[]>
    {
        private const string percentageDecimalMatcher = @"\d+\.\d+%";

        public OffensiveReboundStatsValidator()
        {
            RuleFor(x => x[2].InnerText).Matches(percentageDecimalMatcher);
            RuleFor(x => x[5].InnerText).Matches(percentageDecimalMatcher);
            RuleFor(x => x[6].InnerText).Matches(percentageDecimalMatcher);
        }
    }
}
