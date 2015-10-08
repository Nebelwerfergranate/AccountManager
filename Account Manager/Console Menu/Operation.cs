using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Account_Manager
{
    public abstract class Operation
    {
        // Events
        public event MessageDelegate OnMessage;


        // Methods
        protected void SendMessage(string message)
        {
            if (OnMessage != null)
            {
                OnMessage.Invoke(message);
            }
        }
    }
}
