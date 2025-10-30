using AnotherTask.Enums;

namespace AnotherTask.BaseClasses
{
    abstract class Person
    {
        public Guid Id { get; set; } // Поле, содержащее ID
        public string Name { get; set; } // Поле содержащее имя
        public string Surname { get; set; } // Поле содержащее фамилию
        public JobPosition JobPosition { get; set; } // Поле содержащее позицию на работе
    }
}
