using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace úkolovník
{
    public class HomeWork
    {

       
        public string Subject { get; protected set; }  
        public DateTime Deadline { get; protected set; } 
        public int Marking { get; protected set; }
        public int ID { get;  set; }
        public string Topic { get; protected set; }
        public bool Status;
        public string HomeWorkStatusInWords { get; protected set; }
        public HomeWork(string subject, string topicOfHomework, DateTime deadline, int marking, int numberOfHomework) 
        {
            Subject = subject;
            Topic = topicOfHomework;
            Deadline = deadline;
            Marking = marking;
            Status = false;
            ID = numberOfHomework;
        }


        public string ShowHomeWorkStatusInWords(bool status)
        {
            Status = status;
            if(status==false)
            {
                return HomeWorkStatusInWords = "Nedokončený";
            }
            else
            {
                return HomeWorkStatusInWords = "Dokončený";
            }
        }

        public override string ToString()
        {
            ShowHomeWorkStatusInWords(Status);
            return String.Format(ID +
                " /Předmět: " + Subject + " /Téma: " + Topic + " /Uzávěrka: " + Deadline.ToShortDateString() + " /Bodování: " + Marking + " /Status: " + HomeWorkStatusInWords);
        }

        public string ChangeTopic(string topic)
        {
            return Topic = topic;
        }
        public int ChangeMarking(int marking)
        {
            return Marking = marking;
        }
        public int ChangeID(int id)
        {
            return ID = id;
        }
        public string ChangeSubject(string subject)
        {
            return Subject = subject;
        }
        public DateTime ChangeDeadline(DateTime deadline)
        {
            return Deadline = deadline;
        }   

    }
}
