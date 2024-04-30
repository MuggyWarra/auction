using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auction.Tests
{
    public class SlotServesTest
    {
        [Fact]
        public void GetAllByQuery_WithTegs_CallsGetAllByTegs()
        {
            var slotReposStub = new Mock<ISlotRepos>();
            slotReposStub.Setup(x => x.GetAllByTeg(It.IsAny<string>()))
                .Returns(new[] { new Slot(1, "", "","", 0,0) });
            slotReposStub.Setup(x => x.GetAllByTitle(It.IsAny<string>()))
                .Returns(new[] { new Slot(2, "", "","", 0,0) });
            var slotServes = new SlotServes(slotReposStub.Object);
            var actual = slotServes.GetAllByQuery("#music");
            Assert.Collection(actual, slot => Assert.Equal(1, slot.Id));
        }
        [Fact]
        public void GetAllByQuery_WithTitle_CallsGetAllByTitle()
        {
            var slotReposStub = new Mock<ISlotRepos>();
            slotReposStub.Setup(x => x.GetAllByTeg(It.IsAny<string>()))
                .Returns(new[] { new Slot(1, "", "","", 0,0) });
            slotReposStub.Setup(x => x.GetAllByTitle(It.IsAny<string>()))
                .Returns(new[] { new Slot(2, "", "","", 0,0) });
            var slotServes = new SlotServes(slotReposStub.Object);
            var actual = slotServes.GetAllByQuery("music");
            Assert.Collection(actual, slot => Assert.Equal(2, slot.Id));
        }

    }
}
