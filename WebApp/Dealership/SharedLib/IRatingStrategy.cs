using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityClasses
{
    public interface IRatingStrategy
    {
        void SetRate(Rating rating);
    }
}
