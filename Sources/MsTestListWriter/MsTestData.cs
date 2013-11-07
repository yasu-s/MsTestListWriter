namespace Shikahama
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public sealed class MsTestData
    {
        public string TypeName
        {
            get;
            set;
        }

        public string MethodName
        {
            get;
            set;
        }

        public string[] Categories
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }
    }
}
