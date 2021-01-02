using System;
using System.Data;

namespace KampusStudioProto.Models.Services.Infrastructure
{
    public interface IDatabaseAccessor
    {
        DataSet Query(FormattableString query);
    }
}