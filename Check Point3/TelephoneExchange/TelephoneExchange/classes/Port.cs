using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TelephoneExchange
{
    public class Port : INotifyPropertyChanged
    {
        public  Guid Id { get; private set; }
        public Port (int id)
            {
                Id = Guid.NewGuid();
                PortStatus = PortState.on;
            }

        public PortState PortStatus { get; set; }
        public event EventHandler<CallingEventArgs> Calling;
        protected virtual void OnStartCalling(Object obj, CallingEventArgs args)
        {
           
            if (Calling != null)
            {
                Calling(this, args);
            }
            
        }
        public void Call(Object obj, CallingEventArgs args)
        {
            if (PortStatus != PortState.busy||PortStatus != PortState.off)
            {
                OnStartCalling(obj, args);
                PortStatus = PortState.busy;

            }

        }

        public event EventHandler StopCalling;
        protected virtual void OnStopCalling()
        {

            if (StopCalling != null)
            {
                StopCalling(this, EventArgs.Empty);
            }

        }
        public void StopCall()
        {
            if (PortStatus == PortState.busy)
            {
                OnStopCalling();
                PortStatus = PortState.on;
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }







    }
}
