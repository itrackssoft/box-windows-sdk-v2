using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box.V2.Managers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Box.V2.Test
{
    [TestClass]
    class BoxEventsManagerTests : BoxResourceManagerTest
    {
        protected BoxUsersManager _usersManager;

        public BoxEventsManagerTests()
        {
            _usersManager = new BoxUsersManager(_config.Object, _service, _converter, _authRepository);
        }
    }
}
