using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WoW.Core;

namespace WoW.Tests.WoW.Core
{
    [TestFixture]
    class Core
    {
        [Test]
        public void TierTokenCounts()
        {
            Assert.True(TierTokens.Conqueror.Count() == 3);

            Assert.True(TierTokens.Protector.Count() == 4);

            Assert.True(TierTokens.Vanquisher.Count() == 4);
        }
    }
}
