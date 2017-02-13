using System;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;
using Ekstrand.Text;

namespace StringOperationsTester
{
    [TestFixture]
    public class StringOperationTester
    {
        private const string StringSet1 = "a little this { and that } with a little dash of [ and @#&^ ] and a touch of %";
        private const string StringSet2 = "Jacuzzi"; // (7)

        #region String Center Test Sets

        [Test]
        public void StringCenterEvenPadding()
        {
            string result = StringSet2.PadCenter(9, '#');
            Console.WriteLine("Results: {0} ({1})", result,result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual('#', result[0]);
            Assert.AreEqual('#', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterOddPaddingbyOne()
        {
            string result = StringSet2.PadCenter(8,'*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(8, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterEvenPaddingDefinedChar()
        {
            string result = StringSet2.PadCenter(9, '#');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual('*', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterEvenOddDefinedChar()
        {
            string result = StringSet2.PadCenter(8, '$');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(8, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterCropNoCrop()
        {
            string result = StringSet2.PadCenter(7, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(7, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterEvenPaddingCropNoCrop()
        {
            string result = StringSet2.PadCenter(11, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(11, result.Length);
            Assert.AreEqual('*', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterOddPaddingCropNoCrop()
        {
            string result = StringSet2.PadCenter(10, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(10, result.Length);
            Assert.AreEqual('*', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterCropRight()
        {
            string result = StringSet2.PadCenterCrop(6, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(6, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('z', result[result.Length - 1]);
        }

        [Test]
        public void StringCenterCropBoth()
        {
            string result = StringSet2.PadCenterCrop(5, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(5, result.Length);
            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('z', result[result.Length - 1]);
        }

        #endregion

        #region String Pad Left Crop Test Sets

        [Test]
        public void StringPadLeftCropNoCrop()
        {
            string result = StringSet2.PadLeftCrop(9);
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual(' ', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        [Test]
        public void StringPadLeftCrop()
        {
            string result = StringSet2.PadLeftCrop(6,'*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(6, result.Length);
            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        #endregion

        #region String Pad Right Crop Test Sets

        [Test]
        public void StringPadRightCropNoCrop()
        {
            string result = StringSet2.PadLeftCrop(9, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual(' ', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        [Test]
        public void StringPadRightCrop()
        {
            string result = StringSet2.PadLeftCrop(6,'*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(6, result.Length);
            Assert.AreEqual('a', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        #endregion

        #region String Replace Test Sets

        [Test]
        public void StringReplaceOldCharArrayOnly()
        {
            char[] ch = new char[] { '{', '}', '[' };
            char chn = '*';
            string result = StringSet1.Replace(ch, chn);
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(-1, result.IndexOfAny(ch));

        }

        [Test]
        public void StringReplaceOldCharArrayAndNewCharArray()
        {
            char[] ch = new char[] { '{', '}', '[' };
            char[] ch2 = new char[] { '?', '!', '*' };
    
            string result = StringSet1.Replace(ch, ch2);
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(-1, result.IndexOfAny(ch));
            Assert.AreEqual(true, result.Contains("?"));
            Assert.AreEqual(true, result.Contains("!"));
            Assert.AreEqual(true, result.Contains("*"));
        }

        #endregion
    }
}
