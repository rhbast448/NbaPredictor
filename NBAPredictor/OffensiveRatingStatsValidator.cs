using FluentValidation;

namespace NBAPredictor
{
    public class OffensiveRatingStatsValidator : AbstractValidator<HtmlAgilityPack.HtmlNode[]>
    {
        public OffensiveRatingStatsValidator()
        {
            RuleFor(x => x[2].InnerText).Must(x => decimal.TryParse(x, out _));
            RuleFor(x => x[5].InnerText).Must(x => decimal.TryParse(x, out _));
            RuleFor(x => x[6].InnerText).Must(x => decimal.TryParse(x, out _));
        }
    }
}

