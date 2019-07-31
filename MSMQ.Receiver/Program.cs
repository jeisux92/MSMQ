using MSMQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ.Receiver
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageMq messageMq = new MessageMq();
            MessageQueue mq = null;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
                //creates an instance MessageQueue, which points 
                //to the already existing MyQueue
                mq = new MessageQueue(@".\Private$\MyQueue");
            else
                //creates a new private queue called MyQueue 
                mq = MessageQueue.Create(@".\Private$\MyQueue");


            mq.Formatter = new XmlMessageFormatter(new Type[] { typeof(MessageMq) });
            mq.ReceiveCompleted += new ReceiveCompletedEventHandler(MyReceiveCompleted);
            mq.BeginReceive();
            Console.ReadLine();
        }

        private static void MyReceiveCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            // Connect to the queue.
            MessageQueue mq = (MessageQueue)source;

            // End the asynchronous Receive operation.
            Message m = mq.EndReceive(asyncResult.AsyncResult);
            MessageMq messageMq = (MessageMq)m.Body;
            // Display message information on the screen.
            Console.WriteLine("Message: " + messageMq.Content);

            // Restart the asynchronous Receive operation.
            mq.BeginReceive();

            return;
        }
    }
}
