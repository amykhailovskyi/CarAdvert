using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Business
{
    public static class Mapper<TIn, TOut>
    {
        public static TOut Map(TIn source)
        {
            return AutomapperConfig.Mapper.Map<TOut>(source);
        }

        public static TIn Map(TOut source)
        {
            return AutomapperConfig.Mapper.Map<TIn>(source);
        }

        public static IList<TOut> Map(IList<TIn> source)
        {
            return source == null ? null : AutomapperConfig.Mapper.Map<IList<TOut>>(source);
        }

        public static IEnumerable<TOut> Map(IEnumerable<TIn> source)
        {
            return source == null ? null : AutomapperConfig.Mapper.Map<IEnumerable<TOut>>(source);
        }
    }
}
