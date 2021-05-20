using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Design_Patterns
{

    public interface INotificationSystem
    {
        void Add(User observer);
        void Delete(User observer);
        void Send(string message);
    }

    public class User
    {
        public string Name { get; set; }
        public User(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class Notification : INotificationSystem
    {
        private List<User> users = new List<User>();
        public void Add(User observer)
        {
            users.Add(observer);
        }

        public void Delete(User observer)
        {
            users.Remove(observer);
        }

        public void Send(string message)
        {
            foreach (var user in users)
            {
                user.Send(message);
                Console.WriteLine($"{user.Name} kullanicisina bildirim gönderildi");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User dogukan = new User("dogukan");
            User ali = new User("ali");
            User mehmet = new User("mehmet");


            var notification = new Notification();

            notification.Add(dogukan);
            notification.Add(ali);
            notification.Add(mehmet);

            notification.Send("Yeni kampanya - 1");

            notification.Delete(ali);
            notification.Delete(mehmet);

            notification.Send("Yeni Kampanya - 2");

            notification.Delete(dogukan);

            notification.Send("Yeni Kampanya - 3");

            Console.ReadLine();
        }
    }
}
