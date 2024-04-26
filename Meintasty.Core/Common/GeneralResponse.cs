using System;

namespace Meintasty.Core.Common
{
    public class GeneralResponse <T> : BaseResponse
    {
        public T Value { get; set; }
    }
}
