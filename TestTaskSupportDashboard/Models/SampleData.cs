using System.Linq;

namespace TestTaskSupportDashboard.Models
{
    public static class SampleData
    {
        public static void Initialize(LoginContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.AddRange(
                    new Role { Name = "guest" },
                    new Role { Name = "observer" },
                    new Role { Name = "supportoperator" });
            }
            context.SaveChanges();
            Role roleGuest = context.Roles.FirstOrDefault(r => r.Name == "guest");
            Role roleObserver = context.Roles.FirstOrDefault(r => r.Name == "observer");
            Role roleSupportOperator = context.Roles.FirstOrDefault(r => r.Name == "supportoperator");
            if (!context.SupportOperators.Any())
            {
                context.SupportOperators.AddRange(
                    new SupportOperator
                    {
                        Email = "vasya@yandex.ru",
                        Name = "Вася",
                        Password = "12345",
                        Role = roleGuest,
                    },
                    new SupportOperator
                    {
                        Email = "masha@yandex.ru",
                        Name = "Маша",
                        Password = "123456",
                        Role = roleObserver,
                    },
                    new SupportOperator
                    {
                        Email = "igor@yandex.ru",
                        Name = "Игорь",
                        Password = "qwerty",
                        Role = roleObserver,
                    },
                    new SupportOperator
                    {
                        Email = "kot@yandex.ru",
                        Name = "Котик",
                        Password = "123qwe",
                        Role = roleSupportOperator,
                    });
                context.SaveChanges();
            }
        }
        public static void Initialize(MessageContext context)
        {
            if (!context.Messages.Any())
            {
                context.Messages.AddRange(
                    new Message
                    {
                        ChatId = "01",
                        Type = Enums.SenderType.Player,
                        IsRead = true,
                        Date = new System.DateTime(2022, 05, 01, 10, 11, 01),
                        Text = "У меня проблема с игрой"
                    },
                    new Message
                    {
                        ChatId = "01",
                        Type = Enums.SenderType.Player,
                        IsRead = true,
                        Date = new System.DateTime(2022, 05, 01, 10, 13, 01),
                        Text = "Она не запускается"
                    },
                    new Message
                    {
                        ChatId = "01",
                        Type = Enums.SenderType.SupportOperator,
                        IsRead = true,
                        Date = new System.DateTime(2022, 05, 01, 10, 14, 01),
                        Text = "Не волнуйтесьЮ сейчас пофиксим"
                    },
                    new Message
                    {
                        ChatId = "01",
                        Type = Enums.SenderType.Player,
                        IsRead = true,
                        Date = new System.DateTime(2022, 05, 01, 11, 14, 01),
                        Text = "Спасибо, до свидания"
                    },
                    new Message
                    {
                        ChatId = "01",
                        Type = Enums.SenderType.SupportOperator,
                        IsRead = true,
                        Date = new System.DateTime(2022, 05, 01, 11, 14, 05),
                        Text = "Всего доброго"
                    },
                    new Message
                    {
                        ChatId = "02",
                        Type = Enums.SenderType.Player,
                        IsRead = false,
                        Date = new System.DateTime(2022, 05, 01, 10, 14, 05),
                        Text = "не работает игра помогите"
                    },
                    new Message
                    {
                        ChatId = "03",
                        Type = Enums.SenderType.Player,
                        IsRead = false,
                        Date = new System.DateTime(2022, 05, 01, 10, 14, 06),
                        Text = "не работает игра спасите"
                    },
                    new Message
                    {
                        ChatId = "01",
                        Type = Enums.SenderType.Player,
                        IsRead = true,
                        Date = new System.DateTime(2022, 05, 02, 11, 14, 01),
                        Text = "Дайте промокод плз"
                    },
                    new Message
                    {
                        ChatId = "02",
                        Type = Enums.SenderType.Player,
                        IsRead = false,
                        Date = new System.DateTime(2022, 05, 02, 11, 14, 01),
                        Text = "Алло как слышно"
                    });
                context.SaveChanges();
            }
        }
    }
}
