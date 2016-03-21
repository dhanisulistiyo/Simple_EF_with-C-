using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    using Project;
    using System;

    class Program
    {
        
        static void Main(string[] args)
        {
            MainMenu1:
            Console.WriteLine("Aplikasi Test EF");
            Console.WriteLine("====================================================");
            Console.WriteLine("1. View Data \n");
            Console.WriteLine("2. Create Data \n");
            Console.WriteLine("3. Delete Data \n");
            Console.WriteLine("4. Update Data \n");
            Console.WriteLine("5. Exit \n");
            Console.WriteLine("Pilih Operasi yang diinginkan (Masukan Angka) !!! \n");
            string angka = Console.ReadLine(); Console.WriteLine();



            if (angka == "1")
            {
                Console.WriteLine("Tampilkan data : \n");
                LearnEFEntities entities = new LearnEFEntities();
                var result = from t in entities.TodoLists select t;
                foreach (var t in result)
                {
                    Console.WriteLine("{" + t.Id + "} {" + t.Todo + "} {" + t.Isdone + "}");
                    Console.ReadLine();
                }
                Console.ReadKey(true);
                Console.WriteLine("Data all Display");
                back:
                Console.WriteLine("Back to Main Menu? if to main menu input number 1 ");
                string back = Console.ReadLine();
                if (back == "1")
                {
                    Console.Clear();
                    goto MainMenu1;

                }
                else
                {
                    goto back;

                }


            }
            else if (angka == "2")
            {
                addTodo();
               
                Console.Clear();
                goto MainMenu1;
            }



            else if (angka == "3")
            {
                deleteTodo();
                Console.Clear();
                goto MainMenu1;
            }


            else if (angka == "4")
            {
                updateTodo();
                Console.Clear();
                goto MainMenu1;
            }

            else
            {
                Environment.Exit(0);
            }






        }



        public static void addTodo()
        {
            using (var db = new LearnEFEntities())
            {

                Console.WriteLine("Input Todo =");
                string input1 = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Input Is Done (yes or no) =");
                string input2 = Console.ReadLine();
                Console.WriteLine();
                bool Isdoneval = false;
                if (input2.ToLower() == "yes")
                {
                     Isdoneval = true;
                }
                else if (input2.ToLower() == "no")
                {
                     Isdoneval = false;
                }
                else
                {
                    Console.WriteLine(" Salah Input !!!!!");
                    Console.WriteLine("Is Done (yes or no) =");
                }            

                var todo = new TodoList
                {
                   Todo = input1,
                   Isdone = Isdoneval
                };
                Console.WriteLine("Data has been saved.");
                db.TodoLists.Add(todo);
                db.SaveChanges();
                
            }
        }

        public static void deleteTodo()
        {
                
                delete:
                Console.WriteLine("Input id table for deleted =");
                int inputid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                LearnEFEntities entities = new LearnEFEntities();
                TodoList todoToDelete = (from r in entities.TodoLists.Where
                                         (a => a.Id == inputid)
                                         select r).FirstOrDefault();
            try
            {
                
                entities.TodoLists.Remove(todoToDelete);
                Console.WriteLine("Data deleted. \n If delete data again press 1 : ");

                string back =Console.ReadLine();


                if (back == "1")
                {

                    goto delete;
                }
                else
                {
                    entities.SaveChanges();

                }
               


            }
            catch (Exception e)
            {
                Console.WriteLine("Data not found");
                goto delete;
            }
            
                
            }


        public static void updateTodo()
        {
            updateTodo:
            Console.WriteLine("Input id table for update =");
            int inputid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            LearnEFEntities entities = new LearnEFEntities();
            TodoList todoToModofy = (from r in entities.TodoLists.Where
                                         (a => a.Id == inputid)
                                     select r).FirstOrDefault();
            try
            {
                //update todo

                
                Console.WriteLine("Update Todo =");
            string input1 = Console.ReadLine();
            Console.WriteLine();


                //update ISDONE
                Start:
                Console.WriteLine("Input Is Done (yes or no) =");
                string input2 = Console.ReadLine();
                Console.WriteLine();
                bool Isdoneval = false;
                if (input2.ToLower() == "yes")
                {
                    Isdoneval = true;
                }
                else if (input2.ToLower() == "no")
                {
                    Isdoneval = false;
                }
                else
                {
                    Console.WriteLine(" Wrong Input !!!!!");
                    goto Start;
                }

                todoToModofy.Todo = input1;
                todoToModofy.Isdone = Isdoneval;
                Console.WriteLine(" Data has been updated !!!!!");


            }
            catch (Exception e)
            {
                Console.WriteLine("Data not found");
                goto updateTodo;
            }

            entities.SaveChanges();
        }




        




        



        }
}
