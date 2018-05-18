using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Pras.Shared.Enums.Extensions
{
    public static class EnumExtensions
    {
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new
                         {
                             Id = e,
                             Name = GetDescription((Enum)Enum.Parse(typeof(TEnum), e.ToString()))
                         };
            return new SelectList(values.OrderBy(p => p.Name), "Id", "Name", enumObj);
        }

        public static SelectList ToSelectList<TObject>(this TObject obj, Type type) where TObject : List<ISelectable>
        {
            var values = obj.Select(p => new
            {
                p.Id,
                p.Title
            });

            return new SelectList(values, "Id", "Title", obj);
        }

        public static SelectList ToNumberSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new
                         {
                             Id = e.ToInt32(CultureInfo.CurrentCulture),
                             Name = GetDescription((Enum)Enum.Parse(typeof(TEnum), e.ToString()))
                         };
            return new SelectList(values.OrderBy(p => p.Name), "Id", "Name", enumObj);
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            return value.ToString();
        }

        public static string GetLocalizedDescription(this Enum @enum)
        {
            if (@enum == null)
                return null;

            string description = @enum.ToString();

            FieldInfo fieldInfo = @enum.GetType().GetField(description);
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Any())
                return attributes[0].Description;

            return description;
        }
    }
}
