using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCoreLib
{
    public class InvalidCellPositionException:ApplicationException
    {
        public InvalidCellPositionException(string message):base(message)
        {
        }
    }
}
