using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCaseDemo.Services;

namespace TestProject2
{
	public class EnumHelperTests
	{
		[Fact]
		public void GetEnumValueFromIdCorrectEnum()
		{
			int id = 2;

			var result = LanguageEnum.LanguageValues.GetEnumValueFromId<LanguageEnum.Language>(id);

			Assert.Equal(LanguageEnum.Language.Hindi, result);
		}

		[Fact]
		public void GetEnumValueFromIdNotFound()
		{
			int id = 5;

			var result = LanguageEnum.LanguageValues.GetEnumValueFromId<LanguageEnum.Language>(id);

			Assert.Equal(default(LanguageEnum.Language), result);
		}
		[Fact]
		public void GetIdFromEnumValue_Returns_Correct_Id()
		{
			var enumValue = LanguageEnum.Language.Gujarati;

			var result = LanguageEnum.LanguageValues.GetIdFromEnumValue(enumValue);

			Assert.Equal(3, result);
		}
		[Fact]
		public void GetEnumValueFromNameCorrectEnum()
		{
			string name = "Hindi";

			var result = LanguageEnum.LanguageValues.GetEnumValueFromName<LanguageEnum.Language>(name);

			Assert.Equal(LanguageEnum.Language.Hindi, result);
		}

		[Fact]
		public void GetEnumValueFromNameCaseInsensitive()
		{
			string name = "ENGLISH";

			var result = LanguageEnum.LanguageValues.GetEnumValueFromName<LanguageEnum.Language>(name);

			Assert.Equal(LanguageEnum.Language.English, result);
		}

		[Fact]
		public void GetEnumValueFromWrongName()
		{
			string name = "French";

			var result = LanguageEnum.LanguageValues.GetEnumValueFromName<LanguageEnum.Language>(name);

			Assert.Equal(default(LanguageEnum.Language), result);
		}
		[Fact]
		public void GetIdFromLanguageNamCorrectNameTest()
		{
			string language = "Gujarati";

			var result = LanguageEnum.LanguageValues.GetIdFromLanguageName(language);

			Assert.Equal(3, result);
		}
	}
}
