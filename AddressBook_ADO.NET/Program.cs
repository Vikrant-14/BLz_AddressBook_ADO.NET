using System;

namespace AddressBook_ADO.NET
{
    public class Program
    {
        public static int MenuDriven()
        {
            int choice;
            Console.WriteLine("==================================");
            Console.WriteLine("Enter 0 to Exit the Application");
            Console.WriteLine("Enter 1 to Display the Records");
            Console.WriteLine("Enter 2 to Insert the Record");
            Console.WriteLine("Enter 3 to Update the Record");
            Console.WriteLine("Enter 4 to Delete the Record");
            Console.WriteLine("==================================");
            choice = Convert.ToInt32(Console.ReadLine());

            return choice;
        }

        public static void Main()
        {
            ContactLayer contactLayer = new ContactLayer();
           
            int choice;

            while((choice = MenuDriven()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        contactLayer.SelectRecord();
                        break;

                    case 2:
                        Contact contact = new Contact();
                        contact.AcceptContactRecord();
                        contactLayer.Insert(contact);
                        break;

                    case 3:
                        contactLayer.Update();
                        break;

                    case 4:
                        contactLayer.Delete();
                        break;
                }
            }
        }
    }
}
