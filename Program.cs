using System;
using System.Collections.Generic;

namespace TodoCSharp
{
    class Program
    {

        static void Main(string[] args)
        {
            bool flag = true, valid = false;
            string name, title, msg, status, input = "", prefix="*";
            int id;
            List<TodoList> lst = new List<TodoList>();

            try
            {
                while (flag)
                {
                    Console.WriteLine();
                    Console.WriteLine("Welcome to my TodoList");
                    Console.WriteLine();
                    Console.WriteLine("Choose among the following");
                    Console.WriteLine("1. Create New Task");
                    Console.WriteLine("2. View task by Id");
                    Console.WriteLine("3. View all tasks");
                    Console.WriteLine("4. Edit a task");
                    Console.WriteLine("5. Delete a task");
                    Console.WriteLine("6. Sort by Priority");
                    Console.WriteLine("7. Sort by Deadline");
                    Console.WriteLine("8. Modify list formating style");
                    Console.WriteLine("9. Exit Application.");

                    do
                    {
                        int num = 0;
                        Console.WriteLine();
                        Console.Write("Enter choice: ");
                        input = Console.ReadLine();
                        if (int.TryParse(input, out num))
                            break;
                        else
                            Console.WriteLine("Enter proper integer value...");

                    } while (!valid);
                    int choice = Int32.Parse(input);

                    switch (choice)
                    {
                        case 1:
                            /*do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.Write("Enter task Id: ");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                    break;
                                else
                                    Console.WriteLine("Enter proper integer value...");

                            } while (!valid);*/
                            Random rand = new Random();
                            id = rand.Next(100,10000000);
                            Console.WriteLine();
                            Console.Write("Enter task Name: ");
                            name = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter task Title: ");
                            title = Console.ReadLine();
                            Console.WriteLine();
                            Console.Write("Enter task Message: ");
                            msg = Console.ReadLine();
                            status = "Pending";

                            do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.Write("Enter Priority(0-3): ");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                {
                                    if (num <= 3 && num >= 0)
                                        break;
                                    else
                                        Console.WriteLine("Enter integer in proper range...");
                                }
                                else
                                    Console.WriteLine("Enter proper integer value...");

                            } while (!valid);
                            int pri = Int32.Parse(input);

                            do
                            {
                                DateTime dmy = new DateTime();
                                Console.WriteLine();
                                Console.Write("Enter Date (mm/dd/yyyy): ");
                                input = Console.ReadLine();
                                if (DateTime.TryParse(input, out dmy))
                                {
                                    if (dmy < DateTime.Now)
                                        Console.WriteLine("Enter correct date...");
                                    else
                                        break;
                                }
                                else
                                    Console.WriteLine("Enter date in proper format...");

                            } while (!valid);
                            DateTime day = DateTime.Parse(input);
                            
                            lst.Add(new TodoList(id, status, name, title, msg, pri, day, DateTime.Now));
                            Console.WriteLine("Item added to list successfully");
                            break;

                        case 2:
                            do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.Write("Enter task Id: ");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                    break;
                                else
                                    Console.WriteLine("Enter proper integer value...");

                            } while (!valid);
                            id = Int32.Parse(input);
                            bool check = false;
                            foreach(var lstItem in lst)
                            {
                                if(lstItem.id==id)
                                {
                                    Console.WriteLine("Task Details:-");
                                    Console.WriteLine($"\t{prefix}Id: {lstItem.id} | Name: {lstItem.name} | Title: {lstItem.title} | Message: {lstItem.message} | Status: {lstItem.status} | Priority: {lstItem.priority} | Deadline: {lstItem.targetDate} | Timestamp: {lstItem.Timestamp}");
                                    check = true;
                                    break;
                                }
                            }
                            if(!check)
                            {
                                Console.WriteLine("Entered Id not found");
                            }
                            break;

                        case 3:
                            Console.WriteLine();
                            Console.WriteLine("List Sorted according to Id...");
                            lst.Sort(delegate (TodoList x, TodoList y) {
                                return x.id.CompareTo(y.id);
                            });
                            Console.WriteLine();
                            foreach (var lstItem in lst)
                            {
                                Console.WriteLine($"\t{prefix}Id: {lstItem.id} | Name: {lstItem.name} | Title: {lstItem.title} | Message: {lstItem.message} | Status: {lstItem.status} | Priority: {lstItem.priority} | Deadline: {lstItem.targetDate} | Timestamp: {lstItem.Timestamp}");                   
                            }
                            break;

                        case 4:
                            do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.Write("Enter task Id: ");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                    break;
                                else
                                    Console.WriteLine("Enter proper integer value...");
                            } while (!valid);
                            id = Int32.Parse(input);
                            
                            do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.Write("Press 1 to edit message and 2 to edit status: ");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                {
                                    if(num==1 || num==2)
                                        break;
                                    else
                                        Console.WriteLine("Enter proper value in range...");
                                }
                                else
                                    Console.WriteLine("Enter proper integer value...");
                            } while (!valid);
                            int ent = Int32.Parse(input);
                            if(ent==1)
                            {
                                Console.Write("Enter modified task message: ");
                                string s = Console.ReadLine();
                                bool validate = false;
                                foreach(var entry in lst)
                                {
                                    if(entry.id==id)
                                    {
                                        entry.message = s;
                                        validate = true;
                                        break;
                                    }
                                }
                                if(!validate)
                                {
                                    Console.WriteLine("Entered id not found...");
                                }
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.Write("Enter task Status (Complete, Incomplete, Pending): ");
                                status = Console.ReadLine();
                                bool validate = false;
                                foreach (var entry in lst)
                                {
                                    if (entry.id == id)
                                    {
                                        entry.status = status;
                                        validate = true;
                                        break;
                                    }
                                }
                                if (!validate)
                                {
                                    Console.WriteLine("Entered id not found...");
                                }
                            }
                            Console.WriteLine("Data modified");
                            break;

                        case 5:
                            do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.Write("Enter task Id: ");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                    break;
                                else
                                    Console.WriteLine("Enter proper integer value...");
                            } while (!valid);
                            id = Int32.Parse(input);
                            foreach (var items in lst)
                            {
                                if (items.id == id)
                                {
                                    lst.Remove(items);
                                    break;
                                }
                            }
                            Console.WriteLine("List modified...");
                            break;

                        case 6:
                            Console.WriteLine();
                            Console.WriteLine("List Sorted according to priority...");
                            lst.Sort(delegate (TodoList x, TodoList y) {
                                return y.priority.CompareTo(x.priority);
                            });
                            foreach (var lstItem in lst)
                            {
                                Console.WriteLine($"\t{prefix}Id: {lstItem.id} | Name: {lstItem.name} | Title: {lstItem.title} | Message: {lstItem.message} | Status: {lstItem.status} | Priority: {lstItem.priority} | Deadline: {lstItem.targetDate} | Timestamp: {lstItem.Timestamp}");

                            }
                            break;

                        case 7:
                            Console.WriteLine();
                            Console.WriteLine("List Sorted according to deadline...");
                            lst.Sort(delegate (TodoList x, TodoList y) {
                                return x.targetDate.CompareTo(y.targetDate);
                            });
                            foreach (var lstItem in lst)
                            {
                                Console.WriteLine($"\t{prefix}Id: {lstItem.id} | Name: {lstItem.name} | Title: {lstItem.title} | Message: {lstItem.message} | Status: {lstItem.status} | Priority: {lstItem.priority} | Deadline: {lstItem.targetDate} | Timestamp: {lstItem.Timestamp}");

                            }
                            break;

                        case 8:
                            do
                            {
                                int num = 0;
                                Console.WriteLine();
                                Console.WriteLine("\tPress 1 to degign in *" +
                                    "\n\tPress 2 to degign in #" +
                                    "\n\tPress 3 to degign in -");
                                Console.WriteLine();
                                Console.Write("Choose option:");
                                input = Console.ReadLine();
                                if (int.TryParse(input, out num))
                                {
                                    if (num >= 1 || num <=3)
                                        break;
                                    else
                                        Console.WriteLine("Enter proper value in range...");
                                }
                                else
                                    Console.WriteLine("Enter proper integer value...");
                            } while (!valid);
                            int key = Int32.Parse(input);
                            switch(key)
                            {
                                case 1:
                                    prefix = "*";
                                    break;

                                case 2:
                                    prefix = "#";
                                    break;

                                default:
                                    prefix = "-";
                                    break;
                            }
                            break;

                        case 9:
                            flag = false;
                            break;

                        default:
                            Console.WriteLine("Enter proper value....");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception encountered: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\n\t\tThanks for using TodoList...");
            }
                        
        }
    }
}
