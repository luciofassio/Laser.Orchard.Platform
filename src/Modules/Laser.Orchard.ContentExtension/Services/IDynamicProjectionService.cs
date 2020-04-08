﻿using NHibernate;
using Orchard;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laser.Orchard.ContentExtension.Services {
    public interface IDynamicProjectionService : IDependency {
        int GetCount(IQuery query);
        IEnumerable GetResults(IQuery query, int skip = 0, int count = 0);
    }
}