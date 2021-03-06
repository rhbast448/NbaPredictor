﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBAPredictor
{
    public class TurnoverStatsValidator : AbstractValidator<HtmlAgilityPack.HtmlNode[]>
    {
        public TurnoverStatsValidator()
        {
            RuleFor(x => x[2].InnerText).Must(x => Decimal.TryParse(x, out _));
            RuleFor(x => x[5].InnerText).Must(x => Decimal.TryParse(x, out _));
            RuleFor(x => x[6].InnerText).Must(x => Decimal.TryParse(x, out _));
        }
    }
}
