namespace VegyesBolt.RestWpfUi.Logic
{
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class SignalRListener
    {
        // Declare the delegate (if using non-generic pattern).
        public delegate void SignalRChanged();

        // Declare the event.
        public event SignalRChanged SampleEvent;

        // Wrap the event in a protected virtual method
        // to enable derived classes to raise the event.
        protected virtual void SignalRRaise()
        {
            // Raise the event in a thread-safe manner using the ?. operator.

            SampleEvent?.Invoke();
        }
        public SignalRListener()
        {
            RestClient = new RestClient(new Uri("https://localhost:5001/hub/"));
        }

        private RestClient RestClient { get; }
    }
}
