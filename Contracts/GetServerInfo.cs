using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Contracts
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GetServerInfo" in both code and config file together.
    public class GetServerInfo : IGetServerInfo
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public string GetServerTime()
        {
            return DateTime.Now.ToString();
        }

        public string GetServerName()
        {
            return "TestServer";
        }
    }
}
