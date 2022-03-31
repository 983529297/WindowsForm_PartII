using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingForm.presentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingForm.presentationModel.Tests
{
    [TestClass()]
    public class PresentationTests
    {
        //test
        [TestMethod()]
        public void PresentationTest()
        {
            DrawingForm.presentationModel.PresentationForm presentation = new DrawingForm.presentationModel.PresentationForm();
            Assert.AreEqual(false, presentation.Draw);
        }

        //test
        [TestMethod()]
        public void IsRectangleFalseTest()
        {
            DrawingForm.presentationModel.PresentationForm presentation = new DrawingForm.presentationModel.PresentationForm();
            presentation.IsRectangleFalse();
            Assert.AreEqual(false, presentation.IsRectangle);
            Assert.AreEqual(true, presentation.IsEllipse);
            Assert.AreEqual(true, presentation.IsLine);
        }

        //test
        [TestMethod()]
        public void IsEllipseFalseTest()
        {
            DrawingForm.presentationModel.PresentationForm presentation = new DrawingForm.presentationModel.PresentationForm();
            presentation.IsEllipseFalse();
            Assert.AreEqual(true, presentation.IsRectangle);
            Assert.AreEqual(true, presentation.IsLine);
            Assert.AreEqual(false, presentation.IsEllipse);
        }

        //test
        [TestMethod()]
        public void IsLineFalseTest()
        {
            DrawingForm.presentationModel.PresentationForm presentation = new DrawingForm.presentationModel.PresentationForm();
            presentation.IsLineFalse();
            Assert.AreEqual(true, presentation.IsRectangle);
            Assert.AreEqual(false, presentation.IsLine);
            Assert.AreEqual(true, presentation.IsEllipse);
        }

        //test
        [TestMethod()]
        public void IsAllTrueTest()
        {
            DrawingForm.presentationModel.PresentationForm presentation = new DrawingForm.presentationModel.PresentationForm();
            presentation.IsAllTrue();
            Assert.AreEqual(true, presentation.IsRectangle);
            Assert.AreEqual(true, presentation.IsLine);
            Assert.AreEqual(true, presentation.IsEllipse);
        }
    }
}