using System;
using System.Collections.Generic;
using System.Linq;

namespace úkolovník
{
    class MakerHW : IHomeWork
    {
        public string Subject { get; set; }
        public DateTime Deadline { get; set; }
        public int Marking { get; set; }
        public int ID { get; set; }
        public string Topic { get; set; }
        public bool Bool1 { get; protected set; }

        public void ChangeBool1(bool b)
        {
            Bool1 = b;
        }
        public void FindNull(string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));

        }


        public void GetSubject(string subject)
        {

            Subject = subject;

        }
        public string GetTopic(string topic)
        {
            return Topic = topic;

        }
        public int GetID(int id)
        {
            return ID = id;
        }
        public DateTime GetDeadline(DateTime dateTime)
        {
            return Deadline = dateTime;
        }
        public int GetMarking(int marking)
        {

            return Marking = marking;
        }
        public DateTime GetDateTime(DateTime deadline)
        {
            return Deadline = deadline;
        }

        public void GetControlOfID(string id)
        {
            try
            {
                GetID(int.Parse(id));
                FindNull(id);
                Bool1 = true;
            }
            catch
            {
                Console.WriteLine("Nezadali jste správně ID, zkuste znovu:");
                Bool1 = false;
            }
        }

        public void GetControlOfMarking(string marking)
        {
            try
            {
                GetMarking(int.Parse(marking));
                Bool1 = false;
            }
            catch
            {
                Console.WriteLine("Nebylo zadáno bodování, jestli úkol nemá bodování, zadejte nulu anebo zkuste znovu:");
                Bool1 = true;

            }
        }

        public void GetControlOfSubject(string userSubject)
        {
            Subject = null;
            var listOfSchoolSubjects = Enum.GetValues(typeof(SchoolSubjects)).OfType<SchoolSubjects>().ToList();

            foreach (var subject in listOfSchoolSubjects)
            {

                if (subject.ToString() == userSubject)
                {

                    GetSubject(userSubject);

                }

            }
            try
            {
                FindNull(Subject);
                Bool1 = true;
            }
            catch
            {
                Console.WriteLine("Nebyl zadán správný předmět. Zkuste znovu:");
                Bool1 = false;
            }


        }
        public void ShowSchoolSubjects()
        {
            foreach (SchoolSubjects subjects in Enum.GetValues(typeof(SchoolSubjects)))
            {

                Console.WriteLine(subjects);

            }
        }

        public void GetControlOfTopic(string userTopic)
        {
            try
            {
                FindNull(userTopic);
                GetTopic(userTopic);
                Bool1 = false;
            }
            catch
            {
                Console.WriteLine("Nebylo zadané žádné téma. Zkuste znovu:");
                Bool1 = true;
            }

        }
        public void GetControlOfDeadLine(string deadline)
        {
            
            
            try
            {
                FindNull(deadline);
                string[] splitDeadline = deadline.Split(new char[] { '/', '.', ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);
                string pattern = "dd/M/yyyy";
                deadline = splitDeadline[0].ToString() + "/" + splitDeadline[1].ToString() + "/" + splitDeadline[2].ToString();
                GetDateTime(DateTime.ParseExact(deadline, pattern, null));
                if (Deadline>=DateTime.Now)
                {
                    Bool1 = true;
                }
                else
                {
                    Bool1 = false;
                    Console.WriteLine("Neplatné datum. Zkuste znovu:");
                }
            }
            catch
            {
                Console.WriteLine("Špatně zadané datum. Zkuste znovu:");
                Bool1 = false;
            }

        }
        
        public void MakeNewHW()
        {
            Bool1 = false;
            ShowSchoolSubjects();
            while (!Bool1)
            {
                GetControlOfSubject(Console.ReadLine());

            }
            Console.WriteLine("Zadejte téma:");
            while (Bool1)
            {
                GetControlOfTopic(Console.ReadLine());

            }
            Console.WriteLine("Zadejte ID domácího úkolu:");
            while (!Bool1)
            {
                GetControlOfID(Console.ReadLine());
            }
            Console.WriteLine("Zadejte bodování:");
            while (Bool1)
            {
                GetControlOfMarking(Console.ReadLine());
            }
            Console.WriteLine("Zadejte datum:");
            while (!Bool1)
            {
                GetControlOfDeadLine(Console.ReadLine());
            }
        }

    }
}

