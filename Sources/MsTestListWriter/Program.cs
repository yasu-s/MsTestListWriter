namespace Shikahama
{
    using Iriya.Libs;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Collections.Generic;
    using System.IO;
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
                // cosole write header.
                ConsoleWriteHeader();

                if (IsConsoleWriteHelp(args))
                {
                    ConsoleWriteHelp();
                    return;
                }

                string[] inputPaths = ConvertArgs(args, ARGS_PREFIX_INPUT_PATH);
                string outputPath   = ConvertArg(args, ARGS_PREFIX_OUTPUT_PATH);
                bool isFileTypeXml  = args.Contains(ARGS_PREFIX_TYPE_XML);

                foreach (string inputPath in inputPaths)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.WriteLine("input file not found. ({0})", inputPath);
                        return;
                    }

                    Console.WriteLine("input file: {0}", inputPath);
                }

                IList<AttributeInfoData> data = AttributeUtil.GetAttributeInfoData(inputPaths, new Type[] { typeof(TestClassAttribute) });

                if (isFileTypeXml)
                    WriteXmlFile(outputPath, data);
                else
                    WriteCsvFile(outputPath, data);

                result = true;

                Console.WriteLine("output success.");
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
        /// Convert Command Line Argument.
        /// </summary>
        /// <param name="args">Command Line Argument</param>
        /// <param name="prefix">target prefix</param>
        /// <returns></returns>
        public static string ConvertArg(string[] args, string prefix)
        {
            string[] values = ConvertArgs(args, prefix);
            return (values.Length > 0) ? values[0] : string.Empty;
        }

        /// <summary>
        /// Convert Command Line Argument.
        /// </summary>
        /// <param name="args">Command Line Argument</param>
        /// <param name="prefix">target prefix</param>
        /// <returns></returns>
        private static string[] ConvertArgs(string[] args, string prefix)
        {
            IList<string> values = new List<string>();

            if (args != null)
            {
                foreach (string arg in args)
                {
                    if ((arg != null) && arg.StartsWith(prefix))
                    {
                        values.Add(arg.Replace(prefix, string.Empty).Replace("\"", string.Empty));
                    }
                }
            }

            return values.ToArray();
        }

        /// <summary>
        /// check write help.
        /// </summary>
        /// <param name="args">Command Line Arguments</param>
        /// <returns>true:write help</returns>
        private static bool IsConsoleWriteHelp(string[] args)
        {
            if ((args == null) || (args.Length == 0))
                return true;

            foreach (string arg in args)
            {
                if (ARGS_HELP.Equals(arg))
                    return true;
            }

            return false;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="data"></param>
        private static void WriteCsvFile(string outputPath, IList<AttributeInfoData> data)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outputPath"></param>
        /// <param name="data"></param>
        private static void WriteXmlFile(string outputPath, IList<AttributeInfoData> data)
        {
        }
    }
}
