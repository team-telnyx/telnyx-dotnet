using System;
using System.Collections.Generic;
using System.Text;

namespace Telnyx.net.Services.Calls.CallCommands
{
    public class CallCommandService
    {
        private readonly CallControlDialService callControlDialService;
        private readonly CallControlSpeakService callControlSpeakService;

        public CallCommandService()
        {
            this.callControlDialService = new CallControlDialService();
            this.callControlSpeakService = new CallControlSpeakService();
        }

        public virtual CallDialResponse Dial(CallControlDialCreateOptions options, RequestOptions requestOptions = null)
        {
            return this.callControlDialService.Create(options, requestOptions);
        }

        public virtual CallSpeakResponse Speak(string id, CallControlSpeakCreateOptions options, string postFix = "actions/speak", RequestOptions requestOptions = null)
        {
            return this.callControlSpeakService.Create(id, options, postFix, requestOptions);
        }
    }
}
