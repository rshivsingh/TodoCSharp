using System;
using System.Collections.Generic;
using System.Text;

namespace TodoCSharp
{
    class TodoList
    {
        public int id { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public int priority { get; set; }
        public DateTime targetDate { get; set; }
        public DateTime Timestamp { get; set; }

        public TodoList() { }

        public TodoList(int id,string stats, string nm, string tit, string msg, int pri, DateTime td, DateTime ts)
        {
            this.id = id;
            status = stats;
            message = msg;
            priority = pri;
            targetDate = td;
            title = tit;
            name = nm;
            Timestamp = ts;
        }

    }
}
