using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using System.Collections.Generic;
using System.Diagnostics;
using Tracker.models.db;

namespace Tracker.Tests
{
    [TestClass]
   public class DbTests
    {
        [TestMethod]
        public  void Insert_InsertNewRow_Long0()
        {
            Db db = Db.connect("testa");
            var ret =  db.insert(new Route()).Result;
   
            Assert.IsInstanceOfType(ret, typeof(long));
            Assert.IsTrue( ret == 0);

        }
        [TestMethod]
        public  void Insert_InsertNewRowLongId()
        {
            Db db = Db.connect("test");
            var ret =  db.insert(new Route()).Result;
          
            Assert.IsInstanceOfType(ret, typeof(long));
            Assert.IsTrue(ret > 0);
        }
        [TestMethod]
        public  void Insert_UpdateRow_true()
        {
            Db db = Db.connect("test");
            var route = new Route { id = 1 };
            var ret =  db.update(route).Result;
            Assert.IsTrue(ret);
        }
        [TestMethod]
        public  void Insert_UpdateRow_false()
        {
            Db db = Db.connect("test");
            var route = new Route { id = 99 };
            var ret =  db.update(route).Result;
            Assert.IsFalse(ret);
        }
        [TestMethod]
        public void Insert_getRow_RouteObject()
        {
            Db db = Db.connect("test");

            var ret = db.getRow<Route>("SELECT * FROM Route WHERE id=1").Result;
          
            Assert.IsInstanceOfType(ret, typeof(Route));

        }

        [TestMethod]
        public void Insert_getRow_Null()
        {
            Db db = Db.connect("test");

            var ret = db.getRow<Route>("SELECT * FROM Route121").Result;
            Assert.IsNull(ret);
        }
        [TestMethod]
        public void Insert_getAll_ListOfRoutes()
        {
            Db db = Db.connect("test");

            var ret = db.getAll<Route>("SELECT * FROM Route").Result;
            Assert.IsInstanceOfType(ret, typeof(List<Route>));
        }
        [TestMethod]
        public void Insert_getAll_Null()
        {
            Db db = Db.connect("test");
            var ret = db.getAll<Route>("SELECT * FROM Route121").Result;
            Assert.IsNull(ret);
        }
    }
}
