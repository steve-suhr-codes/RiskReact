using System;
using System.Collections.Generic;
using System.Text;

namespace Risk
{
    public class Ledger
    {
        private StringBuilder _sb = new StringBuilder();

        public void Log(string info)
        {
            _sb.AppendLine(info);
        }

        public string ReadAll()
        {
            return _sb.ToString().Replace("\n", "<br />\n");
        }
    }
}
