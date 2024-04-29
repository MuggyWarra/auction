using System;
using Xunit;

namespace Auction.Tests
{
    public class BoolTests
    {
        [Fact]
        public void IsTest_withNull_ReturnFalse()
        {
            bool actual = Slot.IsTegs(null);
            Assert.False(actual);
        }
        [Fact]
        public void IsTest_WithBlankString_ReturnFalse()
        {
            bool actual = Slot.IsTegs("   ");
            Assert.False(actual);
        }
        [Fact]
        public void IsTest_WithInvalidTegs_ReturnFalse()
        {
            bool actual = Slot.IsTegs("# ");
            Assert.True(actual);
        }
        [Fact]
        public void IsTest_WithTrashStart_ReturnFalse()
        {
            bool actual = Slot.IsTegs("wed#");
            Assert.False(actual);
        }
        
    }
}
