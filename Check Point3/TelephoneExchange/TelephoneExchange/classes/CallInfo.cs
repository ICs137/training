using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TelephoneExchange
{
    public class CallInfo
    {
        
        public CallingEventArgs CallProperties { get; private set; }
        public CallInfo(CallingEventArgs args)
        {
            this.CallProperties = args;
        }
        public int CostCall { get; set; }
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
            get 
            { 
                if(CallProperties.CallStatus==CallState.ConnectionSuccessful)
                {
                    return DateTime.Now - StartTimeCall;
                }
                      
                return StopTimeCall - StartTimeCall;
            }
        }
        internal IPort PortTarget { get;  set; }
        internal Port PortInitiator { get; set; }

    }
}
