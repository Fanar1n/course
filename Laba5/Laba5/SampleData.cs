using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Laba5.Models;

namespace Laba5
{
    public static class SampleData
    {
        public static void Initialize(RestaurantContext context)
        {
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee
                    {
                        FirstName = "Андрей",
                        LastName = "Кочугин",
                        Position = "Официант",
                    },
                    new Employee
                    {
                        FirstName = "Артём",
                        LastName = "Харкевич",
                        Position = "Стажёр",
                    },
                    new Employee
                    {
                        FirstName = "Максим",
                        LastName = "Шамигов",
                        Position = "Бармен",
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Dishes.Any())
            {
                context.Dishes.AddRange(
                    new Dish
                    {
                        NameDish = "Пюре с котлетами",
                        Price = 10,
                        CookTime = 25
            },
                    new Dish
                    {
                        NameDish = "Бешбармак",
                        Price = 15,
                        CookTime = 20
                    },
                    new Dish
                    {
                        NameDish = "Ничего",
                        Price = 0,
                        CookTime = 0
                    },
                    new Dish
                    {
                        NameDish = "Ленивая Лазанья",
                        Price = 15,
                        CookTime = 20
                    },
                    new Dish
                    {
                        NameDish = "Хачапури по-аджарски",
                        Price = 10,
                        CookTime = 25
                    },
                    new Dish
                    {
                        NameDish = "Апероль",
                        Price = 25,
                        CookTime = 5
                    }
                    );
                context.SaveChanges();
            }
            if (!context.Tables.Any())
            {
                context.Tables.AddRange(
                    new Table
                    {
                        NumberOfSeats = 4,
                        TableDeatures = "Столик у сцены"
                        
                    },
                    new Table
                    {
                        NumberOfSeats = 6,
                        TableDeatures = "Столик в центре зала"
                    },
                    new Table
                    {
                        NumberOfSeats = 2,
                        TableDeatures = "Столик со скрипачём "
                    },
                    new Table
                    {
                        NumberOfSeats = 8,
                        TableDeatures = "Столик для большой компании"
                    },
                    new Table
                    {
                        NumberOfSeats = 2,
                        TableDeatures = "Столик у окна"
                    },
                    new Table
                    {
                        NumberOfSeats = 4,
                        TableDeatures = "Столик для покера"
                    },
                    new Table
                    {
                        NumberOfSeats = 6,
                        TableDeatures = "Столик с игровой приставкой"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
