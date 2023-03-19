﻿using FinanceManager.Application.Tags.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager.Application.Movements.Common
{
    public record MovementResult(
        string Id,
        string Concept,
        double Amount,
        bool IsIncoming,
        DateTime ExecutionDate,
        IEnumerable<TagResult> Tags,
        string AccountId);
}
