using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Box.V2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Box.V2.Test.Integration
{
    [TestClass]
    public class BoxEventsManagerTestIntegration : BoxResourceManagerTestIntegration
    {
        [TestMethod]
        public async Task Events_LiveSession_StreamPosition()
        {
            long streamPosition = await _client.EventsManager.GetCurrentStreamPositionAsync();
            Assert.IsTrue(streamPosition > 0);
        }

        [TestMethod]
        public async Task Events_LiveSession_GetEventsDefaults()
        {
            BoxEvents events = await _client.EventsManager.GetEventsSinceAsync();
            Assert.IsTrue(events.NextStreamPositon > 0);
        }

        [TestMethod]
        public async Task Events_LiveSession_GetEventsSinceArbitrary()
        {
            BoxEvents events = await _client.EventsManager.GetEventsSinceAsync(1450204753452);
            Assert.IsTrue(events.NextStreamPositon > 0);
        }

        [TestMethod]
        public async Task Events_LiveSession_GetEventsSinceArbitraryWithFilter()
        {
            BoxEvents events = await _client.EventsManager.GetEventsSinceAsync(1450204753452, BoxEventFilter.SyncedFolderChanges );
            Assert.IsTrue(events.NextStreamPositon > 0);
        }

        [TestMethod]
        public async Task Events_LiveSession_GetEventsSimple()
        {
            long streamPosition = await _client.EventsManager.GetCurrentStreamPositionAsync();
            BoxEvents events = await _client.EventsManager.GetEventsSinceAsync(streamPosition);
            Assert.IsTrue(events.NextStreamPositon > 0);
        }
    }
}
