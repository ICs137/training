using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace TelephoneExchange
{
    public class Port : IPort
    {
        public  Guid Id { get; private set; }
        public Port ()
            {
                Id = Guid.NewGuid();
                portStatus = PortState.on;
            }

        private PortState portStatus;
        public PortState PortStatus 
            {
                get
                {
                    return portStatus;
                }

                set 
                {
                    if(portStatus==value)
                        {
                            return;
                        }
                    portStatus = value;
                    NotifyPropertyChanged();
                }
            }

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
            if (PortStatus == PortState.on ||PortStatus == PortState.blocked )
            {
                OnStartCalling(obj, args);
                PortStatus = PortState.call;
            }

        }

        public event EventHandler StopCalling;
        protected virtual void OnStopCalling()
        {

            if (StopCalling != null)
            {
                StopCalling(this,EventArgs.Empty);
            }

        }
        public void StopCall(Object obj, EventArgs args)
        {
            if (PortStatus == PortState.busy || PortStatus == PortState.call)
            {
                OnStopCalling();
                PortStatus = PortState.on;
            }
        }
        public void StopCall()
        {
            if (PortStatus == PortState.busy || PortStatus == PortState.call)
            {
                OnExternalStopCalling();
                PortStatus = PortState.on;
            }
        }
        public event EventHandler ExternalStopCalling;
        protected virtual void OnExternalStopCalling()
        {

            if (ExternalStopCalling != null)
            {
                ExternalStopCalling(this, EventArgs.Empty);
            }
        }


        public event EventHandler AnswerCalling;
        protected virtual void OnAnswerCall()
        {
            
            if (AnswerCalling != null)
            {
                AnswerCalling(this, EventArgs.Empty);
            }

        }
        public void AnswerCall(Object obj, EventArgs args)
        {
            if (PortStatus == PortState.busy )
            {
                OnAnswerCall();
                PortStatus = PortState.call;
            }
                       
        }

        public event EventHandler IncomingCalling;
        protected virtual void OnIncomingCalling()
            {

                if (IncomingCalling != null)
                {
                    IncomingCalling(this, EventArgs.Empty);
                }

            }
        public void IncomingCall()
            {
                if (PortStatus==PortState.on)
                    {
                        OnIncomingCalling();
                        PortStatus=PortState.busy;
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
