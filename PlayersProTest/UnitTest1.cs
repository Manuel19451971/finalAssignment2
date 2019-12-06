

using System;
using PlayersProfile.Models;
using PlayersProfile.Controllers;
using Xunit;

namespace PlayersProfile
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var home = new HomeController();
            var ouput = home.Index();
            Assert.NotNull(ouput);

        }





        [Fact]
        public void Test2()
        {



            var home = new HomeController();
            var ouput = home.About();
            Assert.NotNull(ouput);
        }

        [Fact]
        public void Test3()
        {
            var home = new HomeController();
            var ouput = home.Contact();
            Assert.NotNull(ouput);
        }

        [Fact]
        public void Test4()
        {
            var home = new HomeController();
            var ouput = home.Privacy();
            Assert.NotNull(ouput);
        }


    }
}
