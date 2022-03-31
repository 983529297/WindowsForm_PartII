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
    public class ModelTests
    {
        //test
        [TestMethod()]
        public void PressdPointerTest()
        {
            Model model = new Model();
            Shape item = new Rectangle(model);
            model.PressdPointer(10, 20, item);
            Assert.AreEqual(10, model._firstPointX);
            Assert.AreEqual(20, model._firstPointY);
        }

        //test
        [TestMethod()]
        public void MovedPointerTest()
        {
            Model model = new Model();
            Shape item = new Rectangle(model);
            model.PressdPointer(10, 20, item);
            model.MovedPointer(20, 20, item);
            Assert.AreEqual(10, model._firstPointX);
            Assert.AreEqual(20, model._firstPointY);
        }

        //test
        [TestMethod()]
        public void ReleasedPointerTest()
        {
            Model model = new Model();
            Shape item = new Rectangle(model);
            model.PressdPointer(10, 20, item);
            model.MovedPointer(20, 20, item);
            model.ReleasedPointer(20, 20, item);
            Assert.AreEqual(10, model._firstPointX);
            Assert.AreEqual(20, model._firstPointY);
        }

        //test
        [TestMethod()]
        public void ClearTest()
        {
            Model model = new Model();
            Shape item = new Rectangle(model);
            model.PressdPointer(10, 20, item);
            model.MovedPointer(20, 20, item);
            model.ReleasedPointer(20, 20, item);
            model.Clear();
            Assert.AreEqual(0, model.GetListNumber());
        }
    }
}