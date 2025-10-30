using AnotherTask.Enums;

namespace AnotherTask.Classes
{
    class TaskForEmployee
    {
        public string Title { get; set; } // Название задачи
        public TypeOfTask Type { get; set; } // Тип задачи (System / Dev / Boss)
        public DepartmentType Department { get; set; } // Отдел, к которому относится
        public bool IsAssigned { get; set; } // Пометка назначена ли задача или нет (чтобы не назначить одну и ту же задачу несколько раз)

        public TaskForEmployee(string title, TypeOfTask type, DepartmentType department)
        {
            Title = title;
            Type = type;
            IsAssigned = false;
            Department = department;
        }

        public override string ToString() => Title;
    }
}
