using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ANWO.Common
{
    public delegate void AddKeywordAndDescription(object sender, KeywordAndDescriptionArgs args);
    public delegate void ControlError(object sender, ControlErrorArgs args);
}