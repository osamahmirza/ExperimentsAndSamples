using System;
using ANWO.Utility;


/// <summary>
/// Summary description for ICommon
/// </summary>
namespace ANWO.Presentation
{
    public interface ISessionBag
    {
        SessionStateBag SessionBag { get; }
    }
}