using AnotherTask.Classes;
using AnotherTask.Enums;

class Start
{
    public static void Main(string[] args)
    {
        var timur = new Employee("Тимур", String.Empty, JobPosition.Генеральный_директор, DepartmentType.Начальство, JobPosition.Финансовый_директор, JobPosition.Директор_по_автоматизации);

        var rashid = new Employee("Рашид", String.Empty, JobPosition.Финансовый_директор, timur, DepartmentType.Финансовый, JobPosition.Главный_бухгалтер);
        var ilham = new Employee("О. Ильхам", String.Empty, JobPosition.Директор_по_автоматизации, timur, DepartmentType.Технический, JobPosition.Начальник_инф_систем, JobPosition.Зам_начальника_инф_систем);

        var orkadiy = new Employee("Оркадий", String.Empty, JobPosition.Начальник_инф_систем, ilham, DepartmentType.Технический, JobPosition.Главный_разработчиков, JobPosition.Главный_системщиков);
        var volodya = new Employee("Володя", String.Empty, JobPosition.Зам_начальника_инф_систем, ilham, DepartmentType.Технический, JobPosition.Главный_разработчиков, JobPosition.Главный_системщиков);

        var sergey = new Employee("Сергей", String.Empty, JobPosition.Главный_разработчиков, orkadiy, DepartmentType.Технический, JobPosition.Зам_главного_разработчиков);
        var lyaysan = new Employee("Ляйсан", String.Empty, JobPosition.Зам_главного_разработчиков, sergey, DepartmentType.Технический, JobPosition.Разработчики);

        var ilshat = new Employee("Ильшат", String.Empty, JobPosition.Главный_системщиков, orkadiy, DepartmentType.Технический, JobPosition.Зам_главного_системщиков);
        var ivanych = new Employee("Иваныч", String.Empty, JobPosition.Зам_главного_системщиков, ilshat, DepartmentType.Технический, JobPosition.Системщики);

        var dina = new Employee("Дина", String.Empty, JobPosition.Разработчики, lyaysan, DepartmentType.Технический);
        var marat = new Employee("Марат", String.Empty, JobPosition.Разработчики, lyaysan, DepartmentType.Технический);
        var ildar = new Employee("Ильдар", String.Empty, JobPosition.Разработчики, lyaysan, DepartmentType.Технический);
        var anton = new Employee("Антон", String.Empty, JobPosition.Разработчики, lyaysan, DepartmentType.Технический);
        var ilya = new Employee("Илья", String.Empty, JobPosition.Системщики, ivanych, DepartmentType.Технический);
        var vitia = new Employee("Витя", String.Empty, JobPosition.Системщики, ivanych, DepartmentType.Технический);
        var zhenya = new Employee("Женя", String.Empty, JobPosition.Системщики, ivanych, DepartmentType.Технический);
        var lukas = new Employee("Лукас", String.Empty , JobPosition.Главный_бухгалтер, rashid, DepartmentType.Финансовый);

        var tasks = new List<TaskForEmployee>
        {
            new TaskForEmployee("Настроить сеть", TypeOfTask.System, DepartmentType.Технический),
            new TaskForEmployee("Починить сервер", TypeOfTask.System, DepartmentType.Технический),
            new TaskForEmployee("Добавить кнопку в отчёте", TypeOfTask.Dev, DepartmentType.Технический),
            new TaskForEmployee("Исправить баг с авторизацией", TypeOfTask.Dev, DepartmentType.Технический),
            new TaskForEmployee("Сделать резервное копирование", TypeOfTask.System, DepartmentType.Технический),
            new TaskForEmployee("Оптимизировать SQL-запросы", TypeOfTask.Dev, DepartmentType.Технический),
            new TaskForEmployee("Подготовить финансовый отчёт", TypeOfTask.Chief, DepartmentType.Финансовый),
        };

        Console.WriteLine("Нажмите любую кнопку для начала распределения задач: ");
        Console.ReadKey();

        Console.BackgroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Распределение задач: ");
        Console.ResetColor();
        Random random = new Random();

        var developers = new List<Employee> { dina, marat, ildar, anton };
        var sysadmins = new List<Employee> { ilya, vitia, zhenya };

        foreach (var task in tasks)
        {
            if (task.Department.Equals(DepartmentType.Технический))
            {
                ilham.GiveWork(orkadiy, task);
                Thread.Sleep(1000);

                switch (task.Type)
                {
                    case TypeOfTask.System:
                        Thread.Sleep(1000);
                        orkadiy.GiveWork(ilshat, task);
                        Thread.Sleep(1000);
                        ilshat.GiveWork(ivanych, task);
                        Thread.Sleep(1000);

                        var sysTarget = sysadmins[random.Next(sysadmins.Count)];

                        ivanych.GiveWork(sysTarget, task);
                        Thread.Sleep(1000);
                        break;

                    case TypeOfTask.Dev:
                        Thread.Sleep(1000);
                        orkadiy.GiveWork(sergey, task);
                        Thread.Sleep(1000);
                        sergey.GiveWork(lyaysan, task);
                        Thread.Sleep(1000);

                        var devTarget = developers[random.Next(developers.Count)];

                        lyaysan.GiveWork(devTarget, task);
                        Thread.Sleep(1000);
                        break;

                    case TypeOfTask.Chief:
                        Thread.Sleep(1000);
                        orkadiy.GiveWork(volodya, task);
                        break;
                }
            }
            else if (task.Department.Equals(DepartmentType.Финансовый))
            {
                Thread.Sleep(1000);
                timur.GiveWork(rashid, task);
                Thread.Sleep(1000);
                rashid.GiveWork(lukas, task);
                Thread.Sleep(1000);
            }
        }

        var allEmployee = new List<Employee> { timur, rashid, ilham, orkadiy, volodya, sergey, lyaysan, ilshat, ivanych, lukas, dina, marat, ildar, anton, ilya, vitia, zhenya };

        Console.WriteLine(string.Join("\n", from employee in allEmployee select employee));
    }
}