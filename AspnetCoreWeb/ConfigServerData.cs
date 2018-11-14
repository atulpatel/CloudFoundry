using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCoreWeb
{
    public class ConfigServerData
    {
        public Features Features { get; set; }
    }

    public class Features
    {
        public string WowFeature { get; set; }
    }
}
