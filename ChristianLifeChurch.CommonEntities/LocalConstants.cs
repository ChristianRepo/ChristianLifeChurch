using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChristianLifeChurch.CommonEntities
{
    public static class LocalConstants
    {

        public static string StringDateFormatNet = "dd.MM.yyyy";
            
        public const string Required = "*";

        public const string PleaseSelect = "...";

        public const string RequiredFieldError = "Поле '{0}' должно быть заполнено.";

        public const string RequiredFieldErrorFirstPart = "Поле '";

        public const string RequiredFieldErrorSecondPart = "' должно быть заполнено.";

        public const string DateFormat = "dd'.'MM'.'yyyy";

        public const string PhoneFormat =
            @"([(]\d\d\d[)] \d\d\d[-]\d\d[-]\d\d)|([(][_][_][_][)] [_][_][_][-][_][_][-][_][_])";

        public const string LinePhoneFormat = @"[0-9]{10}|[_][_][_][_][_][_][_][_][_][_]";
        
        public const string PhoneInvalidFormat = "Неправильный формат телефона";

        public const string EmailInvalidFormat = "Неверный формат E-mail. Пожалуйста, проверьте наличие символа “@” и правильность написания адреса.";

        public const string FioError = "Поле должно содержать не более 50 символов";

        public const string FioInvalidSymbols = "Допускаются только буквы русского алфавита или '-',данные должны начинаться с буквы";

        public const string PasswordInvalidFormat = "Пароль должен быть длиной от 6 до 20 символов и содержать только латинские буквы или цифры.";

        public const string InvalidDateFormat = "Пожалуйста введите дату в формате дд.мм.гггг, к примеру 21.11.1975";
    }
    
}
