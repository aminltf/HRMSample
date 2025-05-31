using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace HRM.Application.Extensions;

public static class CellStyleExtensions
{
    public static IContainer CellStyle(this IContainer container)
    {
        return container.PaddingVertical(5).PaddingHorizontal(5);
    }
}
