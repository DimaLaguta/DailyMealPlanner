using System.Globalization;
using System.Windows.Controls;

namespace DailyMealPlanner.validationRule
{
    public class MinimumCharacterRule:ValidationRule  
    {
        public int MinimumCharacters { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string charString = value as string;

            if(charString.Length < MinimumCharacters)
            {
                return new ValidationResult(false, $"Минимальное количество символов {MinimumCharacters}.");
            }

            return new ValidationResult(true, null);
        }

    }
}
