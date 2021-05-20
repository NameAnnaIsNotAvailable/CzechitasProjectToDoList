using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace úkolovník
{
    class CommandsWorkingWithHWList : IHomeWork
    {
        public List<HomeWork> listHomeWork = new List<HomeWork>();
        public HomeWork HomeWork { get; protected set; }
        public string Subject { get; set; }
        public DateTime Deadline { get; set; }
        public int Marking { get; set; }
        public string Topic { get; set; }
        public int UserID { get; protected set; }
        public bool Bool1 { get; protected set; }
        public bool HWExist { get; protected set; }
        public int ID { get; set; }

        public bool ChangeHWExist(bool b)
        {
            return HWExist = b;
        }
        public bool Bool()
        {
            return Bool1 = false;
        }
        public void GetIDWhatUserWhant(string userID)
        {
            try
            {
                FindNull(userID);
                UserID = int.Parse(userID);

            }
            catch
            {
                Console.WriteLine("úkol nebyl nalezen. Zkuste zadat ID znovu:");

            }
        }
        public void FindNull(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));

        }

        public void AddHomeWork(HomeWork homework)
        {
            if (homework != null && !listHomeWork.Contains(homework))
            {

                listHomeWork.Add(homework);
            }
        }
        public void ShowHomeWorks()
        {
            foreach (HomeWork homeWork in listHomeWork)
            {
                
                    Console.WriteLine(homeWork);
         

            }
        }

        public void ShowCompletedHomeWorks()
        {
            foreach (HomeWork homeWork in listHomeWork)
            {
                if(homeWork.Status==true)
                { 
                    Console.WriteLine(homeWork); 
                }

            }

        }

        public void ShowNotCompletedHomeWorks()
        {
            foreach (HomeWork homeWork in listHomeWork)
            {
                if (homeWork.Status == false)
                { Console.WriteLine(homeWork); }

            }

        }
        public bool GetoCotnrolOfHW()
        {
            if (listHomeWork.Count==0)
            {
                return HWExist= false;
            }
            else
            {
                return HWExist = true;
            }
        }

        public void ShowSpecificHomeworks(List<HomeWork> listHW)
        {
            try
            {
                foreach (HomeWork homeWork in listHW)
                {

                    Console.WriteLine(homeWork);
                }
            }
            catch
            {

            }
        }

        public string WriteHomeWork(HomeWork homeWork)
        {
            return String.Format(homeWork.ID +
                " /Předmět: " + homeWork.Subject + " /Téma: " + homeWork.Topic + " /Uzávěrka: " + homeWork.Deadline + " /Bodování: " + homeWork.Marking + " /Status: " + homeWork.HomeWorkStatusInWords);
        }


        public void ChangeStatus(HomeWork homeWork)
        {
            homeWork.Status = true;

        }

        public void FinishHomeWork()
        {

            HomeWork = null;
            foreach (var homeWork in listHomeWork)
            {

                if (homeWork.ID == UserID)
                {

                    ChangeStatus(homeWork);
                    HomeWork = homeWork;
                }

            }
            try
            {
                FindNull(WriteHomeWork(HomeWork));
                Bool1 = true;
            }
            catch
            {
                Console.WriteLine("Nebylo zadáno správné ID. Zkuste znovu:");
                Bool1 = false;
            }

        }

        public void RemoveHomeWork()
        {
            foreach (var homeWork in listHomeWork)
            {

                if (homeWork.ID == UserID)
                {

                    HomeWork = homeWork;

                }
            }
            try
            {
                FindNull(WriteHomeWork(HomeWork));
                listHomeWork.Remove(HomeWork);
                Bool1 = true;
            }
            catch
            {
                Console.WriteLine("Nebylo zadáno správné ID. Zkuste znovu:");
                Bool1 = false;
            }
        }
        public void ShowSeparateHWList()
        {
            Console.WriteLine("Dokončené domácí úkoly:");
            ShowCompletedHomeWorks();
            Console.WriteLine("Nedokončené domácí úkoly:");
            ShowNotCompletedHomeWorks();
        }

        public void ChangeHomeWork()
        {
            HomeWork = null;
            MakerHW makerHW = new MakerHW();
            foreach (var homeWork in listHomeWork)
            {

                if (homeWork.ID == UserID)
                {

                    Console.WriteLine(
                     @"Chcete změnit:
                                   1. ID        4. Čas
                                   2. Předmět   5. Bodování
                                   3. Téma      ");
                    bool b;
                    int choseNumberUserResponse = 0;
                    try
                    {
                        choseNumberUserResponse = int.Parse(Console.ReadLine());
                        b = true;
                    }
                    catch
                    {
                        Console.WriteLine("Tenhle příkaz není k dispozici. Zkusit zadat znovu:");
                        b = false;

                    }
                    while (b)
                    {
                        switch (choseNumberUserResponse)
                        {
                            case 1:
                                makerHW.ChangeBool1(false);
                                Console.WriteLine("Zadejte nové ID:");
                                string response;
                                while (!makerHW.Bool1)
                                {
                                    response = Console.ReadLine();
                                    makerHW.GetControlOfID(response);

                                }

                                homeWork.ChangeID(makerHW.ID);
                                    b = false;
                                break;
                            case 2:
                                makerHW.ChangeBool1(false);
                                Console.WriteLine("Zadejte nový předmět:");
                                makerHW.ShowSchoolSubjects();
                                    while (!makerHW.Bool1)
                                    {
                                    response = Console.ReadLine();
                                    makerHW.GetControlOfSubject(response);

                                    }

                                    homeWork.ChangeSubject(makerHW.Subject);
                                b = false;

                                break;
                            case 3:
                                makerHW.ChangeBool1(true);
                                Console.WriteLine("Zadejte nové téma:");
                                 while (makerHW.Bool1)
                                    {
                                    response = Console.ReadLine();
                                    makerHW.GetControlOfTopic(response);
                                    }
                                    homeWork.ChangeTopic(makerHW.Topic);
                                    b = false;
                                
                                break;
                            case 4:
                            Console.WriteLine("Zadej nový čas:");
                                while (!makerHW.Bool1)
                                {
                                    response = Console.ReadLine();
                                    makerHW.GetControlOfDeadLine(response);

                                }
                                homeWork.ChangeDeadline(makerHW.Deadline);
                                break;
                            case 5:
                                makerHW.ChangeBool1(true);
                                Console.WriteLine("Zadejte nové bodování:");
                             
                                    while (makerHW.Bool1)
                                    {
                                    response = Console.ReadLine();
                                    makerHW.GetControlOfMarking(response);

                                    }
                                homeWork.ChangeMarking(makerHW.Marking);
                                b = false;
                                
                                break;
                        }
                    }
                    HomeWork = homeWork;
                }

            }
            try 
            {
                FindNull(WriteHomeWork(HomeWork));
                Console.WriteLine(WriteHomeWork(HomeWork));
                Bool1 = true;
            }
            catch
            {
                Console.WriteLine("Nebylo zadáno správné ID. Zkuste znovu:");
                Bool1 = false;
            }
        }

        public void SearchingInHW(string userResponse)
            {
         List<HomeWork> listHomeWorkUserWhant = new List<HomeWork>();
        foreach (var homeWork in listHomeWork)
            {

                if (WriteHomeWork(homeWork).IndexOf(userResponse)>0)
                {

                    listHomeWorkUserWhant.Add(homeWork);

                }
            }
            try 
            {
                FindNull(userResponse);
                ShowSpecificHomeworks(listHomeWorkUserWhant);
                Bool1 = true;
            }
            catch
            {
                Console.WriteLine("Nic se nenašlo.");
                Bool1 = true;
            }
        }

        public void DoCase3AndRemoveHWWithControls()
        {
            Bool();
            Console.WriteLine(new string('-', 45));
            ShowHomeWorks();
            GetoCotnrolOfHW();
            if (HWExist == true)
            {
                Console.WriteLine("Napište ID úkolu, který chcete odstranit: ");
                while (!Bool1)
                {
                    GetIDWhatUserWhant(Console.ReadLine());
                    RemoveHomeWork();
                }
                ChangeHWExist(false);
            }
            else
            {
                Console.WriteLine("Nejdříve úkol musíte vytvořit. Zadejte '1'.");
            }
           
    

        }
        public void DoCase2AndFinishHWWithControls()
        {
            Bool();
            Console.WriteLine(new string('-', 45));
            GetoCotnrolOfHW();
            ShowHomeWorks();
            if (HWExist == true)
            {
                Console.WriteLine("Napište ID úkolu, který chcete dokončit: ");
                while (!Bool1)
                {
                    GetIDWhatUserWhant(Console.ReadLine());
                    FinishHomeWork();
                }
                ShowHomeWorks();
                ChangeHWExist(false);
            }
            else
            {
                Console.WriteLine("Nejdříve úkol musíte vytvořit. Zadejte '1'.");
            }
        }

        public void DoCase4AndShowSeparateListHWWithControls()
        {
            Console.WriteLine(new string('-', 45));
            GetoCotnrolOfHW();
            if (HWExist == true)
            {
               ShowSeparateHWList();
               ChangeHWExist(false);
            }
            else
            {
                Console.WriteLine("Nejdříve úkol musíte vytvořit. Zadejte '1'.");
            }
        }

        public void DoCase5AndChangeHWWithControls()
        {
            Bool();
            Console.WriteLine(new string('-', 45));
            ShowHomeWorks();

            GetoCotnrolOfHW();
            if (HWExist == true)
            {
                Console.WriteLine("Napište ID úkolu, který chcete změnit: ");
                while (!Bool1)
                {
                    GetIDWhatUserWhant(Console.ReadLine());
                    ChangeHomeWork();
                }
               ChangeHWExist(false);
            }
            else
            {
                Console.WriteLine("Nejdříve úkol musíte vytvořit. Zadejte '1'.");
            }
        }

        public void DoCase6AndSearchingInHWWithControls()
        {
            Bool();
            Console.WriteLine(new string('-', 45));
           GetoCotnrolOfHW();
            if (HWExist == true)
            {
                Console.WriteLine("Napište co chcete vyhledat: ");
                while (!Bool1)
                {
                    SearchingInHW(Console.ReadLine());
                }
                ChangeHWExist(false);
            }
            else
            {
                Console.WriteLine("Nejdříve úkol musíte vytvořit. Zadejte '1'.");
            }
        }



    }
}
