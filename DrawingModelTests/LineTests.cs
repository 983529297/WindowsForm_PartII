using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingModel.Tests
{
    [TestClass()]
    public class LineTests
    {
        //test
        [TestMethod()]
        public void SetLeftUpTest()
        {
            Model model = new Model();
            Line rec = new Line(model);
            rec.SetLeftUp(10, 20);
            Assert.AreEqual(0, rec._x1);
            Assert.AreEqual(0, rec._y1);
        }

        //test
        [TestMethod()]
        public void SetRightDownTest()
        {
            Model model = new Model();
            Line rec = new Line(model);
            rec.SetRightDown(20, 10);
            Assert.AreEqual(20, rec._x2);
            Assert.AreEqual(10, rec._y2);
        }

        //test
        [TestMethod()]
        public void CheckContainTest()
        {
            Model model = new Model();
            Line rec = new Line(model);
            rec.SetLeftUp(10, 20);
            rec.SetRightDown(20, 30);

            Assert.AreEqual(true, rec.CheckContain(15, 25));
            Assert.AreEqual(false, rec.CheckContain(50, 50));
        }

        //test
        [TestMethod()]
        public void GetPositionTest()
        {
            Model model = new Model();
            Line rec = new Line(model);
            rec.SetLeftUp(10, 20);
            rec.SetRightDown(20, 30);
            Assert.AreEqual(0, rec.GetPosition()[0]);
            Assert.AreEqual(0, rec.GetPosition()[1]);
            Assert.AreEqual(20, rec.GetPosition()[2]);
            Assert.AreEqual(30, rec.GetPosition()[3]);
        }
    }
}