using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace úkolovník
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine(@" 
                    _   _  _    __ _____   _   __     __
                   | | | || |  / //  _  \ | |  \ \   / /
                   | | | || |_/ / | | | | | |   \ \_/ /
                   | | | ||    /  | | | | | |     | |
                   | |_| || |\ \  | |_| | | |____ | |
                   \_____/\_| \_\ \_____/ \______||_|
                                          ");
            Console.ResetColor();
            ProgramManagemant programManagemant = new ProgramManagemant();
            MakerHW makerHW = new MakerHW();
            CommandsWorkingWithHWList commandsWorkingWithHWList = new CommandsWorkingWithHWList();
            Console.WriteLine(programManagemant.ShowMenu());  // Shows the menu of commands on the console.
            User user = new User("start");
            while (!programManagemant.FinishApp(user.UserResponse))  //It lasts until the end "konec" is written 
            {
                user.UserResponse = Console.ReadLine();
                
                    try
                    {
                        user.ChoseNumberUserResponse = int.Parse(user.UserResponse);
                         commandsWorkingWithHWList.ChangeHWExist(true);
                    }
                    catch
                    {
                        Console.WriteLine("Tenhle příkaz není k dispozici. Zkusit zadat znovu:");
                    commandsWorkingWithHWList.ChangeHWExist(false);

                }

                while (commandsWorkingWithHWList.HWExist)
                {
                    if (user.ChoseNumberUserResponse >7)
                    {

                            Console.WriteLine("Tenhle příkaz není k dispozici. Zkusit zadat znovu:");
                        commandsWorkingWithHWList.ChangeHWExist(false);

                    }
                    else
                    {
                        switch (user.ChoseNumberUserResponse)  // The console reads the number and selects the case to which it redirects the user
                        {


                            case 1:                                          //Here you set and add homework.
                                commandsWorkingWithHWList.Bool();
                                Console.WriteLine(new string('-', 45));
                                Console.WriteLine("Zadejte jeden z předmětů:");
                                makerHW.MakeNewHW();
                                HomeWork homeWork = new HomeWork(makerHW.Subject, makerHW.Topic, makerHW.Deadline, makerHW.Marking, makerHW.ID);
                                commandsWorkingWithHWList.AddHomeWork(homeWork);
                                Console.WriteLine(homeWork);
                                commandsWorkingWithHWList.ChangeHWExist(false);
                                break;
                            case 2:                                                 //Here, the status of the task changes to complete
                                commandsWorkingWithHWList.DoCase2AndFinishHWWithControls();
                                break;
                            case 3:                                               //This is where homework is removed
                                commandsWorkingWithHWList.DoCase3AndRemoveHWWithControls();

                                break;
                            case 4:                                           //Here is a list of homeworks
                                commandsWorkingWithHWList.DoCase4AndShowSeparateListHWWithControls();
                                break;
                            case 5:                                           //here you can change the properties of the homework

                                commandsWorkingWithHWList.DoCase5AndChangeHWWithControls();
                                break;
                            case 6:                                         //Here you can search for homework on user response
                                commandsWorkingWithHWList.DoCase6AndSearchingInHWWithControls();
                                break;
                            case 7:                                     //end of application
                                programManagemant.FinishApp();
                                commandsWorkingWithHWList.ChangeHWExist(false);
                                break;

                        }

                    }
                }

            }
            Environment.Exit(0);


        }
    }
}
