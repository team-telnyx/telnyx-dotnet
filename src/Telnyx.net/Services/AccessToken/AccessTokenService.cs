//using system;
//using system.collections.generic;
//using system.threading.tasks;
//using system.threading;
//using telnyx.net.entities.accesstoken;
//using telnyx.net.entities;

//namespace telnyx.net.services.accesstokens
//{
//    public class accesstokensservice : service<telnyxentity>
//    {

//        public accesstokensservice()
//           : base(null) { }

//        public accesstokensservice(string apikey)
//            : base(apikey) { }

//        public override string basepath => "/telephony_credentials";
//        public override string postpath => "/token";
//        public accesstokencreate createaccesstoken(string id, telnyxentity createoptions, requestoptions reqopts = null)
//        {
//            return this.createentity(id, this.postpath, createoptions, reqopts);
//        }

//        public async task<accesstokencreate> createaccesstokenasync(string id, telnyxentity createoptions, requestoptions reqopts = null, cancellationtoken ct = default)
//        {
//            return await this.createentityasync(id, this.postpath, createoptions, reqopts, ct);
//        }

//    }
//}
