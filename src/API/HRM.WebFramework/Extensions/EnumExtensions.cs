using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace HRM.WebFramework.Extensions;

public static class EnumExtensions
{
    public static IEnumerable<SelectListItem> ToSelectList<TEnum>(this TEnum enumObj) where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(e => new SelectListItem
        {
            Value = Convert.ToInt32(e).ToString(),
            Text = e.GetDisplayName()
        });
    }

    public static IEnumerable<SelectListItem> ToSelectList<TEnum>() where TEnum : Enum
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(e => new SelectListItem
        {
            Value = Convert.ToInt32(e).ToString(),
            Text = e.GetDisplayName()
        });
    }

    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = field?.GetCustomAttribute<DisplayAttribute>();
        return attribute?.Name ?? value.ToString();
    }
}
