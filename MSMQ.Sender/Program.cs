using MSMQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MSMQ.Sender
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageMq message = new MessageMq
            {
                Content = "Hello world",
                Tag = "Messaage"
            };

            MessageQueue mq = null;
            if (MessageQueue.Exists(@".\Private$\MyQueue"))
                //creates an instance MessageQueue, which points 
                //to the already existing MyQueue
                mq = new MessageQueue(@".\Private$\MyQueue");
            else
                //creates a new private queue called MyQueue 
                mq = MessageQueue.Create(@".\Private$\MyQueue");

            mq.Label = "Title";
            mq.Send(message);

        }
    }
}
