using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallInfo
    {
        public CallingEventArgs CallProperties { get;private set; }

        public CallInfo(CallingEventArgs properties)
        {
            CallProperties = properties;
            
        }
        public DateTime StartTimeCall { get;  set; }
        public void SetStartTimeCall()
        {
            StartTimeCall = DateTime.Now;
        }

        public DateTime StopTimeCall { get; set; }
        public void SetStopTimeCall()
        {
            StopTimeCall =  DateTime.Now;
        }

        public TimeSpan DurationCall 
        {
            get { return StopTimeCall - StartTimeCall; }
        }

        internal IPort PortTarget { get;  set; }
        internal IPort PortInitiator { get; set; }






    }
}
