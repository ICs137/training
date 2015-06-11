using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TelephoneExchange
{
    interface IPort: INotifyPropertyChanged
    {
        public  Guid Id { get; private set; }
        private PortState portStatus;
        public PortState PortStatus{get;set;}  

        public event EventHandler<CallingEventArgs> Calling;
        protected virtual void OnStartCalling(Object obj, CallingEventArgs args);
        public void Call(Object obj, CallingEventArgs args);

        public event EventHandler StopCalling;
        protected virtual void OnStopCalling();
        public void StopCall(Object obj, EventArgs e);

        public event EventHandler AnswerCalling;
        protected virtual void OnAnswerCall();
        public void AnswerCall(Object obj, EventArgs args);

        public event EventHandler<CallingEventArgs> IncomingCalling;
        protected virtual void OnIncomingCalling(Object obj, CallingEventArgs args);
        public void IncomingCall(CallingEventArgs args);
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged([CallerMemberName] String propertyName = "");
    }
}
