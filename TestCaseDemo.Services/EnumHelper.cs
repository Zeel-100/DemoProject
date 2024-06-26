
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TestCaseDemo.Models.DataModels;

namespace TestCaseDemo.Services
{
	public class LanguageEnum
	{
		public enum Language 
		{
			English = 1,
			Hindi = 2,
			Gujarati = 3
		}

		public static class LanguageValues
		{

			public static TEnum? GetEnumValueFromId<TEnum>(int id) where TEnum : Enum
			{
				var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
				foreach (var enumValue in enumValues)
				{
					if (Convert.ToInt32(enumValue) == id)
					{
						return enumValue;
					}
				}
				return default;
			}

			public static int GetIdFromEnumValue<TEnum>(TEnum enumValue) where TEnum : Enum
			{
				return Convert.ToInt32(enumValue);
			}
			public static TEnum? GetEnumValueFromName<TEnum>(string? name) where TEnum : Enum
			{
				var enumValues = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
				foreach (var enumValue in enumValues)
				{
					if (enumValue.ToString().Equals(name, StringComparison.OrdinalIgnoreCase))
					{
						return enumValue;
					}
				}
				return default;
			}
			public static int GetIdFromLanguageName(string? language)
			{
				
				LanguageEnum.Language languageEnumValue = GetEnumValueFromName<LanguageEnum.Language>(language);
			
				return GetIdFromEnumValue(languageEnumValue);
			}
		}
	}
}