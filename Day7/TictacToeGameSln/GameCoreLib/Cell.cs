using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib
{
    public class Cell
    {
        private MarkType _mark;

        public Cell()
        {
            _mark = MarkType.Empty;
        }

        public MarkType Mark
        {
            get { return _mark; }
            set { 
                if (_mark != MarkType.Empty)
                    throw new InvalidOperationException("Cell already marked");
                _mark = value;
            
            }
        }
    }
}
