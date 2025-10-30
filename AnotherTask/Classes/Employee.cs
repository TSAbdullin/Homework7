using AnotherTask.BaseClasses;
using AnotherTask.Enums;

namespace AnotherTask.Classes
{
    internal class Employee : Person
    {
        public Employee Chief { get; set; } // прямой начальник
        public JobPosition[] TargetPosition { get; set; } // кому может давать работу
        public DepartmentType Department { get; set; } // отдел
        public List<TaskForEmployee> Tasks { get; set; } // список принятых задач


        public Employee(string name, string surname, JobPosition jobPosition, Employee chief, DepartmentType department, params JobPosition[] target)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            JobPosition = jobPosition;
            Department = department;
            Chief = chief;
            TargetPosition = target;
            Tasks = new List<TaskForEmployee>();
        }

        public Employee(string name, string surname, JobPosition jobPosition, DepartmentType department, params JobPosition[] target)
        {
            Id = Guid.NewGuid();
            Name = name;
            Surname = surname;
            JobPosition = jobPosition;
            Department = department;
            TargetPosition = target;
            Tasks = new List<TaskForEmployee>();
        }

        public override string ToString()
        {
            return $"ID: {Id}\nИмя: {Name}\nФамилия: {Surname}\nПозиция: {JobPosition}\n";
        }

        public void GiveWork(Employee target, TaskForEmployee task)
        {
            if (target is null)
                throw new ArgumentNullException("Target is null!");

            if (target.Chief != this)
            {
                Console.WriteLine($"{Name} не может дать задачу {target.Name} — не является его начальником.");
                return;
            }

            if (task.Department != target.Department)
            {
                Console.WriteLine($"{Name} не может дать задачу {task.Title} ({task.Department}) сотруднику {target.Name} ({target.Department}).");
                return;
            }

            bool isCanGiveJob = TargetPosition.Contains(target.JobPosition);

            if (isCanGiveJob)
            {
                Console.WriteLine($"От {Name} даётся задача {task.Title} для {target.Name}");
                target.Tasks.Add(task);
                task.IsAssigned = true;
                Console.WriteLine($"{target.Name} принял(а) задачу.\n");
            }
            else
            {
                Console.WriteLine($"От {Name} даётся задача {task.Title} для {target.Name}");
                Console.WriteLine($"{target.Name} не принимает задачу (не его должность).\n");
            }
        }
    }
}
