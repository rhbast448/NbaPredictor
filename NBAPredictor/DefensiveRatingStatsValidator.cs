using FluentValidation;

namespace NBAPredictor
{ 
    public class DefensiveRatingStatsValidator : AbstractValidator<HtmlAgilityPack.HtmlNode[]>
    {
        public DefensiveRatingStatsValidator()
        {
            RuleFor(x => x[2].InnerText).Must(x => decimal.TryParse(x, out _));
            RuleFor(x => x[5].InnerText).Must(x => decimal.TryParse(x, out _));
            RuleFor(x => x[6].InnerText).Must(x => decimal.TryParse(x, out _));
        }
    }
}
