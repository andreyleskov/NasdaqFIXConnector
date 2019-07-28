using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TradeClient
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("=============");
            Console.WriteLine();
            Console.WriteLine("                                                    ! ! !");
            Console.WriteLine("              Test for NASDAQ UMS");
            Console.WriteLine("                                                    ! ! !");
            Console.WriteLine();
            Console.WriteLine("=============");

            string file = "./tradeclient.cfg";

            try
            {
                QuickFix.SessionSettings settings = new QuickFix.SessionSettings(file);
                TradeClientApp application = new TradeClientApp();
                QuickFix.IMessageStoreFactory storeFactory = new QuickFix.FileStoreFactory(settings);
                QuickFix.ILogFactory logFactory = new QuickFix.ScreenLogFactory(settings);
                QuickFix.Transport.SocketInitiator initiator = new QuickFix.Transport.SocketInitiator(application, storeFactory, settings, logFactory);

                application.Initiator = initiator;

                initiator.Start();
                application.Run();
                initiator.Stop();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            Environment.Exit(1);
        }
    }
}
