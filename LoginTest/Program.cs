using LoginTest.Models;
using Newtonsoft.Json;
using System;
using System.Net;

namespace LoginTest
{
    class Program
    {
        static void Main(string[] args)
        {

            User user1 = new User();
            //FIRST MANNER
            //Console.WriteLine("Please type a UserName: ");
            //string un = Console.ReadLine();
            //Console.WriteLine("Please type a password: ");
            //string pas = Console.ReadLine();
            //SECOND MANER 123
            //Console.WriteLine("Please create a UserName");
            //var un = Console.ReadLine();
            //Console.WriteLine("Now please create a password");
            //Console.ForegroundColor = ConsoleColor.Black;
            //var pas = Console.ReadLine();
            //Console.ForegroundColor = ConsoleColor.White;

            // THIRD MANNER

            Console.WriteLine("Welcom!");
           
            string pas=null;
            int j = 0,c=0;
            fillim:
                Console.WriteLine("Please type UserName: ");
               string un = Console.ReadLine();
            //if no User name is typed no need to send request to the server
            int i = 0; 
               i = un.Length;
                if (i>0)
                { password:
                    Console.WriteLine("Please type password: ");
                   
                    while (true)
                    {
                        var key = Console.ReadKey(true);
                        if (key.Key == ConsoleKey.Enter)
                            break;
                        pas += key.KeyChar;
                   
                    }
                //if no password typed no need to send request to the server
                
               
                    if (pas!=null)
                        {
                            user1.username = un;
                            user1.password = pas;
                        }
                    else
                        {
                            c += 1;
                            if (c < 2)
                            {
                                Console.Write("You don't type any password! ");
                                goto password;
                            }
                            else
                                {                      
                                   Console.WriteLine("No password is typed for the second time!\n");                        
                                }
                        }
                }
                else 
                        {
                            j += 1;
                            if (j < 2)
                            {
                                Console.Write("You don't type any user name! ");
                                goto fillim;
                            }

                        }
                 if (j >= 2)
                    {
                        Console.WriteLine("No user name is typed for the second time!\n");
                    }
                 //request sended to the server. PASSWORD AND USER NAME IS SET. confirmed from var 'j' and 'c'
                  else if (j < 2 && c < 2)
                     {
                        string str = JsonConvert.SerializeObject(user1);
                        response resp = null;


                        using (var req = new WebClient())
                        {
                            string respStr = req.UploadString("http://2rmlab.com/api/financa/login.php", str);

                            resp = JsonConvert.DeserializeObject<response>(respStr);

                            int length = respStr.Length;
                        }


                        if (resp != null)
                        {
                            if (resp.status.code > 600)
                            {
                        Console.WriteLine();
                        Console.WriteLine(resp.status.message);
                        
                        Console.ReadLine();

                        }
                        else
                        {
                            User usr = resp.body[0];
                            Console.WriteLine();
                            printuser(usr);
                            Console.ReadLine();

                        }

                    }


                }
                
                
           
        }

        static void printuser(User usr)
        {
            Console.WriteLine("The date for this user are: \n");
            Console.WriteLine($"User name: {usr.username}");
            Console.WriteLine($"Password: {usr.password}");
            Console.WriteLine($"User ID: {usr.user_id}");
            Console.WriteLine($"Company Code : {usr.company_code}");
            Console.WriteLine($"Last login company code : {usr.last_login_company_code}");
            Console.WriteLine($"Default company code: {usr.default_company_code }");
            Console.WriteLine($"Is sales agent : {usr.is_sales_agent}");
            Console.WriteLine($"Is login alloved : {usr.is_login_allowed}");
            Console.WriteLine($"Mobile : {usr.mobile}");
            Console.WriteLine($"Allow mobile configurtion : {usr.allow_mobile_configuration}");
            Console.WriteLine($"Warehouse Id : {usr.warehouse_id}");
            Console.WriteLine($"Cash desc Id : {usr.cash_desk_id}");
            Console.WriteLine($"Name : {usr.name}");
            Console.WriteLine($"Surname : {usr.surname}");
            Console.WriteLine($"Email : {usr.email}");
            Console.WriteLine($"User group Id : {usr.user_group_id}");
            Console.WriteLine($"Xpire date : {usr.xpire_date}");
            Console.WriteLine($"Address : {usr.address}");
            Console.WriteLine($"View only own document : {usr.view_only_own_document}");
            Console.WriteLine($"Is cutomer edit alloved : {usr.is_customer_edit_allowed}");
            Console.WriteLine($"Is sales invoice price edit allowed : {usr.is_sales_invoice_price_edit_allowed}");
            Console.WriteLine($"Is qoutation print allowed : {usr.is_qoutation_print_allowed}");
        }

    }
}
