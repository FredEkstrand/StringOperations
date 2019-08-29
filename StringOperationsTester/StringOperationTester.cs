using System;
using NUnit.Framework;
using NUnit.VisualStudio.TestAdapter;
using Ekstrand.Text;
using System.Text;
using System.IO;

namespace StringOperationsTester
{
    [TestFixture]
    public class StringOperationTester
    {
        private const string StringSet1 = "a little this { and that } with a little dash of [ and @#&^ ] and a touch of %";
        private const string StringSet2 = "Jacuzzi"; // (7)
        private const string StringSet3 = "AsafeFileName.txt";
        private const string StringSet4 = "UnsafeFileName\"<>?|\\/:.cs";

        #region String Center Test Sets

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterEvenPadding()
        {
            string result = StringSet2.PadCenter(9, '#');
            Console.WriteLine("Results: {0} ({1})", result,result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual('#', result[0]);
            Assert.AreEqual('#', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterOddPaddingbyOne()
        {
            string result = StringSet2.PadCenter(8,'*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(8, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterEvenPaddingDefinedChar()
        {
            string result = StringSet2.PadCenter(9, '#');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual('#', result[0]);
            Assert.AreEqual('#', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterEvenOddDefinedChar()
        {
            string result = StringSet2.PadCenter(8, '$');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(8, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('$', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterCropNoCrop()
        {
            string result = StringSet2.PadCenter(7, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(7, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterEvenPaddingCropNoCrop()
        {
            string result = StringSet2.PadCenter(11, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(11, result.Length);
            Assert.AreEqual('*', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterOddPaddingCropNoCrop()
        {
            string result = StringSet2.PadCenter(10, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(10, result.Length);
            Assert.AreEqual('*', result[0]);
            Assert.AreEqual('*', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
        public void StringCenterCropRight()
        {
            string result = StringSet2.PadCenterCrop(6, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(6, result.Length);
            Assert.AreEqual('J', result[0]);
            Assert.AreEqual('z', result[result.Length - 1]);
        }

        [Test]
        [Category("String Center Test Sets")]
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
        [Category("String Pad Left Crop Test Sets")]
        public void StringPadLeftCropNoCrop()
        {
            string result = StringSet2.PadLeftCrop(9);
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual(' ', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        [Test]
        [Category("String Pad Left Crop Test Sets")]
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
        [Category("String Pad Right Crop Test Sets")]
        public void StringPadRightCropNoCrop()
        {
            string result = StringSet2.PadLeftCrop(9, '*');
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(9, result.Length);
            Assert.AreEqual(' ', result[0]);
            Assert.AreEqual('i', result[result.Length - 1]);
        }

        [Test]
        [Category("String Pad Right Crop Test Sets")]
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
        [Category("String Replace Test Sets")]
        public void StringReplaceOldCharArrayOnly()
        { // this version is for when there is no replacement
            char[] ch = new char[] { '{', '}', '[' };
            char chn = '*';
            string result = StringSet1.Replace(ch, chn);
            Console.WriteLine("Results: {0} ({1})", result, result.Length);

            Assert.AreEqual(-1, result.IndexOfAny(ch));

        }

        [Test]
        [Category("String Replace Test Sets")]
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

        #region Escape Illegal Chars

        [Test]
        [Category("Escape Illegal Chars")]
        public void NoEscapeIllegalChars()
        {         
            string StringSet5 = "UnsafeFileName.cs";
            string result = StringSet5.EscapeIllegalChars();

            Console.WriteLine("Results: {0} ({1}))", result, result.Length);
            string solution = "UnsafeFileName.cs";
            Assert.AreEqual(solution, result);
        }

        [Test]
        [Category("Escape Illegal Chars")]
        public void EscapeIlleagleChars()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 31; i++)
            {
                sb.Append((char)i);
            }

            string StringSet5 = sb.ToString() + StringSet4;
            string result = StringSet5.EscapeIllegalChars();

            Console.WriteLine("Results: {0} ({1}))", result, result.Length);
            string solution = "UnsafeFileName.cs";
            Assert.AreEqual(solution, result);


        }
        #endregion

        #region StringToStream

        [Test]
        [Category("StringToStream")]
        public void StringToStream()
        {
            String str = StringSet3;
            Stream sm = StringUtil.StringToStream(str);
            StreamReader sr = new StreamReader(sm,Encoding.Unicode);

            string result = sr.ReadToEnd();

            Assert.AreEqual(StringSet3, result);
        }

        #endregion

        #region StreamToString

        [Test]
        [Category("StreamToString")]
        public void StreamToString()
        {
            String str = StringSet3;
            Stream sm = StringUtil.StringToStream(str);
            string result = StringUtil.StreamToString(sm);

            Assert.AreEqual(StringSet3, result);
        }

        #endregion
    }
}
