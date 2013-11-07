namespace Shikahama
{
    using Iriya.Libs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;

    class Program
    {

        /// <summary>site url</summary>
        private const string SITE_URL = "https://github.com/yasu-s/MsTestListWriter";

        /// <summary>argument prefix: Input File Path</summary>
        private const string ARGS_PREFIX_INPUT_PATH = "/in:";

        /// <summary>argument prefix: Output File Path</summary>
        private const string ARGS_PREFIX_OUTPUT_PATH = "/out:";

        /// <summary>argument prefix: Output File Type (XML)</summary>
        private const string ARGS_PREFIX_TYPE_XML = "/type:xml";

        /// <summary>argument prefix: Output File Type (CSV)</summary>
        private const string ARGS_PREFIX_TYPE_CSV = "/type:csv";

        /// <summary>argument prefix: Help</summary>
        private const string ARGS_HELP = "/?";

        /// <summary>
        /// Main process
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        static void Main(string[] args)
        {
            bool result = false;

            try
            {
                string[] paths = null;
                IList<Iriya.Libs.AttributeInfoData> data = AttributeUtil.GetAttributeInfoData(paths, new Type[] { typeof(TestClassAttribute) });


                result = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Environment.Exit((result) ? (0) : (1));
            }
        }

        /// <summary>
        /// Cosole Write Application Header.
        /// </summary>
        private static void ConsoleWriteHeader()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyCopyrightAttribute asmcpy = (AssemblyCopyrightAttribute)Attribute.GetCustomAttribute(asm, typeof(AssemblyCopyrightAttribute));
            Console.WriteLine("{0} [Version {1}]", asm.GetName().Name, asm.GetName().Version);
            Console.WriteLine(asmcpy.Copyright);
            Console.WriteLine("URL: {0}", SITE_URL);
        }

        /// <summary>
        /// Console Write Application Help.
        /// </summary>
        private static void ConsoleWriteHelp()
        {
            Console.WriteLine();

            if (System.Threading.Thread.CurrentThread.CurrentCulture.Name.IndexOf("ja") >= 0)
            {
                Console.WriteLine("/in:[ ファイルパス ] 入力対象のファイルパスを指定します。");
                Console.WriteLine("/out:[ ファイルパス ] 出力対象のファイルパスを指定します。");
                Console.WriteLine("/type:[ xml | csv ] 出力対象のファイル形式を指定します。");
                Console.WriteLine("/? ヘルプを表示します。");
            }
            else
            {
                Console.WriteLine("/in:[ file path ] specify a file path in which you want to enter.");
                Console.WriteLine("/out:[ file path ] specify the file path of the output target.");
                Console.WriteLine("/type:[ xml | csv ] specify the file format of the output target.");
                Console.WriteLine("/? Displays the help.");
            }
        }
    }
}
